namespace Test;
using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using System.Linq;

public class Benchmark
{
    [Params(1000, 100_000, 1_000_000)]
    public int Count { get; set; }

    private int[] _data;

    [GlobalSetup]
    public void GlobalSetup()
    {
        var l = new List<int>(Count);

        for (int i = 0; i < Count; i++)
        {
            l.Add(i);
        }

        _data = l.ToArray();
    }

    [Benchmark(Baseline = true)]
    public int LastElementViaArrayIndex()
    {
        return _data[_data.Length - 1];
    }

    [Benchmark]
    public int LastElementWithLinqLast()
    {
        return _data.Last();
    }

    [Benchmark]
    public int LastElementWithRangeIndex()
    {
        return _data[^1];
    }
}
