namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;

[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]

public class Benchmark
{
    [Params(100, 1_000_000)]
    public int Count { get; set; }

    private List<int> _data;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _data = new List<int>(Count);

        for (int i = 0; i < Count; i++)
        {
            _data.Add(i);
        }
    }

    [Benchmark(Baseline = true)]
    public long ForLoopInteger()
    {
        long result = 0;

        for (int i = 0; i < Count; i++)
        {
            result += _data[i];
        }

        return result;
    }

    [Benchmark]
    public long ForLoopFloat()
    {
        long result = 0;

        for (float i = 0F; i < Count; i++)
        {
            result += _data[(int)i];
        }

        return result;
    }

    [Benchmark]
    public long ForLoopDouble()
    {
        long result = 0;

        for (double i = 0D; i < Count; i++)
        {
            result += _data[(int)i];
        }

        return result;
    }

    [Benchmark]
    public long ForLoopDecimal()
    {
        long result = 0;

        for (decimal i = 0M; i < Count; i++)
        {
            result += _data[(int)i];
        }

        return result;
    }

}
