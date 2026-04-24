namespace ParquetNetDeserialization;

using BenchmarkDotNet.Attributes;
using Parquet;
using Parquet.Serialization;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

[MemoryDiagnoser]
public class Benchmark
{
    [Params(50_000, 500_000, 2_621_470)]
    public int RowCount { get; set; }

    private string _parquetFilePath = "";
    private string _tempDir = "";

    [GlobalSetup]
    public async Task GlobalSetup()
    {
        _tempDir = Path.Combine(Path.GetTempPath(), "ParquetNetDeserializationBenchmark");
        Directory.CreateDirectory(_tempDir);
        _parquetFilePath = Path.Combine(_tempDir, $"events_{RowCount}.snappy.parquet");

        if (!File.Exists(_parquetFilePath))
        {
            await WriteTestFile(_parquetFilePath, RowCount);
        }
    }

    [Benchmark(Baseline = true)]
    public async Task<int> SerializerDeserialize()
    {
        using var fs = File.OpenRead(_parquetFilePath);
        var rows = await ParquetSerializer.DeserializeAsync<EventRow>(fs);
        return rows.Count;
    }

    [Benchmark]
    public async Task<int> ColumnApiDeserialize()
    {
        using var fs = File.OpenRead(_parquetFilePath);
        using var reader = await ParquetReader.CreateAsync(fs);

        int totalRows = 0;

        for (int rg = 0; rg < reader.RowGroupCount; rg++)
        {
            using var rgr = reader.OpenRowGroupReader(rg);

            var ids        = (string[]) (await rgr.ReadColumnAsync(reader.Schema.DataFields[0])).Data;
            var orgIds     = (string[]) (await rgr.ReadColumnAsync(reader.Schema.DataFields[1])).Data;
            var quantities = (double[]) (await rgr.ReadColumnAsync(reader.Schema.DataFields[2])).Data;
            var endTimes   = (string[]) (await rgr.ReadColumnAsync(reader.Schema.DataFields[3])).Data;
            var buckets    = (string[]) (await rgr.ReadColumnAsync(reader.Schema.DataFields[4])).Data;

            totalRows += ids.Length;

            _ = ids[0];
            _ = orgIds[0];
            _ = quantities[0];
            _ = endTimes[0];
            _ = buckets[0];
        }

        return totalRows;
    }

    private static async Task WriteTestFile(string path, int rowCount)
    {
        var rng = new Random(42);
        var baseTime = new DateTime(2026, 4, 23, 13, 0, 0);
        var rows = Enumerable.Range(0, rowCount).Select(i =>
        {
            var t = baseTime.AddSeconds(i % 3617);
            var endTime   = t.ToString("yyyy-MM-ddTHH:mm:ss");
            var timeBucket = t.ToString("yyyy-MM-ddTHH-mm-ss");
            return new EventRow
            {
                Id             = $"{(ulong)i:x32}",
                OrganizationId = $"00000000-0000-0000-0000-{(i % 2000) + 1:D12}",
                UsageQuantity  = Math.Round(rng.NextDouble() * 10, 4),
                UsageEndTime   = endTime,
                TimeBucket     = timeBucket,
            };
        });

        using var fs = File.Create(path);
        await ParquetSerializer.SerializeAsync(rows, fs);
    }
}

class EventRow
{
    public string Id             { get; set; } = "";
    public string OrganizationId { get; set; } = "";
    public double UsageQuantity  { get; set; }
    public string UsageEndTime   { get; set; } = "";
    public string TimeBucket     { get; set; } = "";
}
