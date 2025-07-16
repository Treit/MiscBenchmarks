namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using System.Collections.Generic;
using System.Text;

[MemoryDiagnoser]
public class Benchmark
{
    List<string> _strings;

    [Params(1, 100, 100_000)]
    public int Count { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        _strings = new List<string>(Count);
        for (var i = 0; i < Count; i++)
        {
            _strings.Add(i.ToString());
        }
    }

    [Benchmark(Baseline = true)]
    public string ConcatAllStringsDirectly()
    {
        var result = new StringBuilder();

        foreach (var str in _strings)
        {
            result.Append(str);
        }

        return result.ToString();
    }

    [Benchmark]
    public string ConcatAllStringsWithRedundantToString()
    {
        var result = new StringBuilder();

        foreach (var str in _strings)
        {
            result.Append(str.ToString());
        }

        return result.ToString();
    }
}
