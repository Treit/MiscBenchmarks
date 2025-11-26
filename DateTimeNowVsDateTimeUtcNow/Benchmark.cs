namespace Test;
using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using BenchmarkDotNet.Jobs;

[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]

public class Benchmark
{
    [Params(100_000)]
    public int Count { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
    }

    [Benchmark]
    public IList<DateTime> DateTimeNow()
    {
        var result = new List<DateTime>();

        for (int i = 0; i < Count; i++)
        {
            result.Add(DateTime.Now.AddDays(i));
        }

        return result;
    }

    [Benchmark(Baseline = true)]
    public IList<DateTime> DateTimeUtcNow()
    {
        var result = new List<DateTime>();

        for (int i = 0; i < Count; i++)
        {
            result.Add(DateTime.UtcNow.AddDays(i));
        }

        return result;
    }

    [Benchmark]
    public IList<string> DateTimeNowToString()
    {
        var result = new List<string>();

        for (int i = 0; i < Count; i++)
        {
            result.Add(DateTime.Now.AddDays(i).ToString());
        }

        return result;
    }

    [Benchmark]
    public IList<string> DateTimeUtcNowToString()
    {
        var result = new List<string>();

        for (int i = 0; i < Count; i++)
        {
            result.Add(DateTime.UtcNow.AddDays(i).ToString());
        }

        return result;
    }
}
