namespace Test;
using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Jobs;

[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]

public class Benchmark
{
    [Params(1000, 1_000_000)]
    public int ListSize { get; set; }

    [Params(10, 500)]
    public int N { get; set; }

    private List<int> _data;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _data = new List<int>(ListSize);

        for (int i = 0; i < ListSize; i++)
        {
            _data.Add(i);
        }
    }

    [Benchmark]
    public IList<int> LinqTake()
    {
        return _data.Take(N).ToList();
    }

    [Benchmark(Baseline = true)]
    public IList<int> RangeWithMathDotMin()
    {
        return _data[..Math.Min(_data.Count, N)];
    }

    [Benchmark]
    public IList<int> HandWrittenLoop()
    {
        var result = new List<int>(N);
        for (int i = 0; i < N; i++)
        {
            result.Add(_data[i]);
        }

        return result;
    }
}
