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
    [Params(1000, 100_000, 1_000_000)]
    public int Count { get; set; }

    private int[] _array;

    [GlobalSetup]
    public void GlobalSetup()
    {
        Random r = new Random();

        _array = new int[Count];

        for (int i = 0; i < Count; i++)
        {
            _array[i] = r.Next(0, 100);
        }
    }

    [Benchmark(Baseline = true)]
    public int[] DedupeUsingLinqDistinct()
    {
        return _array.Distinct().ToArray();
    }

    [Benchmark]
    public int[] DedupeUsingHashSet()
    {
        return new HashSet<int>(_array).ToArray();
    }
}
