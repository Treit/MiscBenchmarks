namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Jobs;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    [Params(10, 100_000)]
    public int Count { get; set; }

    private List<string> _data;

    [GlobalSetup]
    public void GlobalSetup()
    {
        Random r = new Random();
        _data = new List<string>(Count);

        for (int i = 0; i < this.Count; i++)
        {
            _data.Add(i.ToString());
        }
    }

    [Benchmark(Baseline = true)]
    public bool SingleAnyWithMatch()
    {
        return _data.Any(x => x.Length == 100 || x.Length > 1);
    }

    [Benchmark]
    public bool SingleAnyWithNoMatch()
    {
        return _data.Any(x => x.Length == 100 || x.Length > 50);
    }

    [Benchmark]
    public bool MultipleCallsToAnyWithMatch()
    {
        return _data.Any(x => x.Length == 100) || _data.Any(x => x.Length > 1);
    }

    [Benchmark]
    public bool MultipleCallsToAnyWithNoMatch()
    {
        return _data.Any(x => x.Length == 100) || _data.Any(x => x.Length > 50);
    }
}
