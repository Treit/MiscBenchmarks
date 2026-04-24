namespace ParquetNetDeserialization;

using BenchmarkDotNet.Attributes;
using Parquet;
using Parquet.Serialization;
using System;
using System.IO;
using System.Threading.Tasks;

[MemoryDiagnoser]
public class Benchmark
{
    private string _parquetFilePath = "";

    [GlobalSetup]
    public void GlobalSetup()
    {
        _parquetFilePath = Path.Combine(AppContext.BaseDirectory, "events.snappy.parquet");
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
            var quantities = (double?[])(await rgr.ReadColumnAsync(reader.Schema.DataFields[2])).Data;
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
}

class EventRow
{
    public string Id             { get; set; } = "";
    public string OrganizationId { get; set; } = "";
    public double? UsageQuantity  { get; set; }
    public string UsageEndTime   { get; set; } = "";
    public string TimeBucket     { get; set; } = "";
}
