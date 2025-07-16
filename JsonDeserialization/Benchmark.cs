using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Test;
public record MyType(string Name, int Age);

[JsonSourceGenerationOptions(WriteIndented = false)]
[JsonSerializable(typeof(List<MyType>))]
internal partial class SourceGenerationContext : JsonSerializerContext
{
}

[MemoryDiagnoser]
public class Benchmark
{
    private List<MyType> _data = new List<MyType>();

    [Params(100)]
    public int Count { get; set; }

    private JsonSerializerOptions _options;
    private string _json;

    [GlobalSetup]
    public void GlobalSetup()
    {
        for (int i = 0; i < Count; i++)
        {
            _data.Add(new MyType($"SomeName{i}", i));
        }
        _options = new JsonSerializerOptions { WriteIndented = false };
        _json = JsonSerializer.Serialize(_data, _options);
}

    private string GetJson() => _json;

[Benchmark]
public List<MyType> DeserializeWithJsonDocument()
{
    var json = GetJson();
    using var doc = JsonDocument.Parse(json);
    var result = new List<MyType>(Count);
    foreach (var element in doc.RootElement.EnumerateArray())
    {
        result.Add(new MyType(
            element.GetProperty("Name").GetString(),
            element.GetProperty("Age").GetInt32()));
    }
    return result;
}

[Benchmark]
public List<MyType> DeserializeWithJsonNode()
{
    var json = GetJson();
    var node = JsonNode.Parse(json);
    var result = new List<MyType>(Count);
    foreach (var item in node.AsArray())
    {
        result.Add(new MyType(
            item["Name"].GetValue<string>(),
            item["Age"].GetValue<int>()));
    }
    return result;
}

[Benchmark]
public List<MyType> DeserializeWithJsonSerializer()
{
    var json = GetJson();
    return JsonSerializer.Deserialize<List<MyType>>(json, _options);
}

[Benchmark]
public List<MyType> DeserializeWithSourceGen()
{
    var json = GetJson();
    return JsonSerializer.Deserialize(json, SourceGenerationContext.Default.ListMyType);
}
}
