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
    [Params(50_000, 500_000)]
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

            var orgIds    = (string[]) (await rgr.ReadColumnAsync(reader.Schema.DataFields[0])).Data;
            var quantities = (double?[])(await rgr.ReadColumnAsync(reader.Schema.DataFields[1])).Data;
            var buckets   = (string[]) (await rgr.ReadColumnAsync(reader.Schema.DataFields[2])).Data;

            totalRows += orgIds.Length;

            _ = orgIds[0];
            _ = quantities[0];
            _ = buckets[0];
        }

        return totalRows;
    }

    private static async Task WriteTestFile(string path, int rowCount)
    {
        var rng = new Random(42);
        var rows = Enumerable.Range(0, rowCount).Select(i => new EventRow
        {
            OrganizationId = $"org-{i % 10_000:D5}",
            UsageQuantity  = Math.Round(rng.NextDouble() * 1000, 2),
            TimeBucket     = $"2026-04-{(i % 28) + 1:D2}T{(i % 24):D2}-00-00",
        });

        using var fs = File.Create(path);
        await ParquetSerializer.SerializeAsync(rows, fs);
    }
}

class EventRow
{
    public string OrganizationId { get; set; } = "";
    public double? UsageQuantity { get; set; }
    public string TimeBucket { get; set; } = "";
}
