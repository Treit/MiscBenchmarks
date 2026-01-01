namespace CsvVsParquet
{
    using BenchmarkDotNet.Attributes;
    using CsvHelper;
    using CsvHelper.Configuration;
    using Parquet;
    using Parquet.Schema;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;

    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(1000, 100_000)]
        public int RowCount { get; set; }

        private string _csvFilePath;
        private string _parquetFilePath;
        private string _tempDir;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _tempDir = Path.Combine(Path.GetTempPath(), "CsvVsParquetBenchmark");
            Directory.CreateDirectory(_tempDir);

            _csvFilePath = Path.Combine(_tempDir, $"data_{RowCount}.csv");
            _parquetFilePath = Path.Combine(_tempDir, $"data_{RowCount}.parquet");

            // Generate test data if files don't exist
            if (!File.Exists(_csvFilePath) || !File.Exists(_parquetFilePath))
            {
                var records = GenerateTestData(RowCount);
                WriteCsvFile(records);
                WriteParquetFile(records);
            }
        }

        [GlobalCleanup]
        public void GlobalCleanup()
        {
            // Optionally clean up temp files
            // if (Directory.Exists(_tempDir))
            //     Directory.Delete(_tempDir, true);
        }

        private List<SampleRecord> GenerateTestData(int count)
        {
            var random = new Random(42); // Fixed seed for reproducibility
            var records = new List<SampleRecord>(count);

            for (int i = 0; i < count; i++)
            {
                records.Add(new SampleRecord
                {
                    Id = i,
                    Name = $"Person_{i}",
                    Age = random.Next(18, 80),
                    Salary = Math.Round(random.NextDouble() * 100000 + 30000, 2),
                    IsActive = random.Next(2) == 1,
                    JoinDate = DateTime.Now.AddDays(-random.Next(1, 3650))
                });
            }

            return records;
        }

        private void WriteCsvFile(List<SampleRecord> records)
        {
            using var writer = new StreamWriter(_csvFilePath);
            using var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture));
            csv.WriteRecords(records);
        }

        private void WriteParquetFile(List<SampleRecord> records)
        {
            var schema = new ParquetSchema(
                new DataField<int>("Id"),
                new DataField<string>("Name"),
                new DataField<int>("Age"),
                new DataField<double>("Salary"),
                new DataField<bool>("IsActive"),
                new DataField<DateTime>("JoinDate"));

            var ids = records.Select(r => r.Id).ToArray();
            var names = records.Select(r => r.Name).ToArray();
            var ages = records.Select(r => r.Age).ToArray();
            var salaries = records.Select(r => r.Salary).ToArray();
            var isActives = records.Select(r => r.IsActive).ToArray();
            var joinDates = records.Select(r => r.JoinDate).ToArray();

            using var fs = File.Create(_parquetFilePath);
            using var writer = ParquetWriter.CreateAsync(schema, fs).GetAwaiter().GetResult();
            using var rgw = writer.CreateRowGroup();

            rgw.WriteColumnAsync(new Parquet.Data.DataColumn(schema.DataFields[0], ids)).GetAwaiter().GetResult();
            rgw.WriteColumnAsync(new Parquet.Data.DataColumn(schema.DataFields[1], names)).GetAwaiter().GetResult();
            rgw.WriteColumnAsync(new Parquet.Data.DataColumn(schema.DataFields[2], ages)).GetAwaiter().GetResult();
            rgw.WriteColumnAsync(new Parquet.Data.DataColumn(schema.DataFields[3], salaries)).GetAwaiter().GetResult();
            rgw.WriteColumnAsync(new Parquet.Data.DataColumn(schema.DataFields[4], isActives)).GetAwaiter().GetResult();
            rgw.WriteColumnAsync(new Parquet.Data.DataColumn(schema.DataFields[5], joinDates)).GetAwaiter().GetResult();
        }

        [Benchmark(Baseline = true)]
        public List<SampleRecord> ReadCsv()
        {
            using var reader = new StreamReader(_csvFilePath);
            using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture));
            return csv.GetRecords<SampleRecord>().ToList();
        }

        [Benchmark]
        public List<SampleRecord> ReadParquet()
        {
            using var fs = File.OpenRead(_parquetFilePath);
            using var pqr = ParquetReader.CreateAsync(fs).GetAwaiter().GetResult();
            var schema = pqr.Schema;

            var records = new List<SampleRecord>(RowCount);

            for (int rgIndex = 0; rgIndex < pqr.RowGroupCount; rgIndex++)
            {
                using var rgr = pqr.OpenRowGroupReader(rgIndex);

                var idColumn = rgr.ReadColumnAsync(schema.DataFields[0]).GetAwaiter().GetResult();
                var nameColumn = rgr.ReadColumnAsync(schema.DataFields[1]).GetAwaiter().GetResult();
                var ageColumn = rgr.ReadColumnAsync(schema.DataFields[2]).GetAwaiter().GetResult();
                var salaryColumn = rgr.ReadColumnAsync(schema.DataFields[3]).GetAwaiter().GetResult();
                var isActiveColumn = rgr.ReadColumnAsync(schema.DataFields[4]).GetAwaiter().GetResult();
                var joinDateColumn = rgr.ReadColumnAsync(schema.DataFields[5]).GetAwaiter().GetResult();

                var ids = (int[])idColumn.Data;
                var names = (string[])nameColumn.Data;
                var ages = (int[])ageColumn.Data;
                var salaries = (double[])salaryColumn.Data;
                var isActives = (bool[])isActiveColumn.Data;
                var joinDates = (DateTime[])joinDateColumn.Data;

                for (int i = 0; i < ids.Length; i++)
                {
                    records.Add(new SampleRecord
                    {
                        Id = ids[i],
                        Name = names[i],
                        Age = ages[i],
                        Salary = salaries[i],
                        IsActive = isActives[i],
                        JoinDate = joinDates[i]
                    });
                }
            }

            return records;
        }
    }

    public class SampleRecord
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double Salary { get; set; }
        public bool IsActive { get; set; }
        public DateTime JoinDate { get; set; }
    }
}
