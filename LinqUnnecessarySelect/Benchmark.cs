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
    public ICollection<string> FilterWithJustWhere()
    {
        return _data.Where(x => x.Length < 20).ToList();
    }

    [Benchmark]
    public ICollection<string> FilterWithUnnecessarySelectFirst()
    {
        return _data.Select(x => x).Where(x => x.Length < 20).ToList();
    }
}
