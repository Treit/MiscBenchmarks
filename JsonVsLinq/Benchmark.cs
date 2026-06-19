using System.Text.Json;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Test;

public class Model
{
    public string Prop01 { get; set; }
    public string Prop02 { get; set; }
    public string Prop03 { get; set; }
    public string Prop04 { get; set; }
    public string Prop05 { get; set; }
    public string Prop06 { get; set; }
    public string Prop07 { get; set; }
    public string Prop08 { get; set; }
    public string Prop09 { get; set; }
    public string Prop10 { get; set; }
    public string Prop11 { get; set; }
    public string Prop12 { get; set; }
    public string Prop13 { get; set; }
    public string Prop14 { get; set; }
    public string Prop15 { get; set; }
    public string Prop16 { get; set; }
    public string Prop17 { get; set; }
    public string Prop18 { get; set; }
    public string Prop19 { get; set; }
    public string Prop20 { get; set; }
}

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    private Model _model;
    private List<int> _items;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _model = new Model
        {
            Prop01 = "Hello",
            Prop02 = "World",
            Prop03 = "Foo",
            Prop04 = "Bar",
            Prop05 = "Baz",
            Prop06 = "Alpha",
            Prop07 = "Beta",
            Prop08 = "Gamma",
            Prop09 = "Delta",
            Prop10 = "Epsilon",
            Prop11 = "Zeta",
            Prop12 = "Eta",
            Prop13 = "Theta",
            Prop14 = "Iota",
            Prop15 = "Kappa",
            Prop16 = "Lambda",
            Prop17 = "Mu",
            Prop18 = "Nu",
            Prop19 = "Xi",
            Prop20 = "Omicron",
        };

        _items = Enumerable.Range(0, 100).ToList();
    }

    [Benchmark(Baseline = true)]
    public string JsonSerialize()
    {
        return JsonSerializer.Serialize(_model);
    }

    [Benchmark]
    public int LinqWhere()
    {
        var result = _items.Where(x => x % 2 == 0).ToList();
        return result.Count;
    }
}
