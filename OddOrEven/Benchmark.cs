namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using System;
using System.Collections.Generic;
using BenchmarkDotNet.Jobs;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    [Params(10, 1000, 100_000)]
    public int Count { get; set; }

    List<int> _values = new();

    [GlobalSetup]
    public void GlobalSetup()
    {
        var r = new Random(Count);

        for (int i = 0; i < Count; i++)
        {
            _values.Add(r.Next(0, 100_000_000));
        }
    }

    [Benchmark(Baseline = true)]
    public int CountOddUsingMod()
    {
        int result = 0;

        foreach (var k in _values)
        {
            int ck = k % 2 == 0 ? 1 : -1;

            if (ck == -1)
            {
                result++;
            }
        }

        return result;
    }

    [Benchmark]
    public int CountOddUsingBranchless()
    {
        int result = 0;

        foreach (var k in _values)
        {
            int ck = (k << 31 >> 30) + 1;
            if (ck == -1)
            {
                result++;
            }
        }

        return result;
    }
}
