namespace Test;
using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;

public class Benchmark
{
    [Params(10, 1000, 100_000)]
    public int Count { get; set; }

    private Dictionary<int, int> _dict;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _dict = new Dictionary<int, int>(Count);

        var r = new Random(Count);

        for (int i = 0; i < Count; i++)
        {
            _dict[i] = r.Next();
        }
    }

    [Benchmark]
    public long IterateAndLookupUsingKeys()
    {
        long result = 0;

        foreach (var key in _dict.Keys)
        {
            result += _dict[key];
        }

        return result;
    }

    [Benchmark]
    public long IterateUsingKeyValuePairs()
    {
        long result = 0;

        foreach (var kvp in _dict)
        {
            result += kvp.Value;
        }

        return result;
    }

    [Benchmark(Baseline = true)]
    public long IterateUsingValues()
    {
        long result = 0;

        foreach (var v in _dict.Values)
        {
            result += v;
        }

        return result;
    }
}
