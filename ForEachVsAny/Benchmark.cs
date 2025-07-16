namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[MemoryDiagnoser]
public class Benchmark
{
    [Params(100_000)]
    public int Count { get; set; }

    private List<int> _data;

    [GlobalSetup]
    public void GlobalSetup()
    {
        Random r = new Random();

        _data = new List<int>(Count);

        for (int i = 0; i < Count; i++)
        {
            _data.Add(r.Next());
        }
    }

    [Benchmark]
    public bool SearchUsingAny()
    {
        var toSearch = _data;

        return toSearch.Any(x => x == int.MaxValue);
    }

    [Benchmark(Baseline = true)]
    public bool SearchUsingForEach()
    {
        var toSearch = _data;

        foreach (int x in toSearch)
        {
            if (x == int.MaxValue)
            {
                return true;
            }
        }

        return false;
    }
}
