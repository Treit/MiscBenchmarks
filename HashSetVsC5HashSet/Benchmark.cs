namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Jobs;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    [Params(100, 1_000_000)]
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
    public int[] DedupeUsingHashSet()
    {
        return new HashSet<int>(_array).ToArray();
    }

    [Benchmark]
    public int[] DedupeUsingC5HashSet()
    {
        var c5hashSet = new C5.HashSet<int>(Count, 0.6, EqualityComparer<int>.Default);
        c5hashSet.AddAll(_array);
        return c5hashSet.ToArray();
    }
}
