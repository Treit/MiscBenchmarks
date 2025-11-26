using System.Text;

namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Jobs;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    [Params(10, 1000, 100_000)]
    public int Count { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
    }

    [Benchmark(Baseline = true)]
    public int IEnumerableCount()
    {
        return Values().Count();
    }

    [Benchmark]
    public int ToListCount()
    {
        return Values().ToList().Count;
    }

    private IEnumerable<int> Values()
    {
        for (int i = 0; i < Count; i++)
        {
            yield return i;
        }
    }
}
