namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using System;
using System.Collections.Generic;
using System.Linq;

[MemoryDiagnoser]
public class Benchmark
{
    [Params(100_000)]
    public int Count { get; set; }

    List<int> _values;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _values = new(Count);
        var r = new Random(Count);

        for (int i = 0; i < Count; i++)
        {
            _values.Add(r.Next());
        }
    }

    [Benchmark(Baseline = true)]
    public long FlipSignUsingMultiplyByMinusOne()
    {
        long total = 0;

        foreach (int v in _values)
        {
            total += FlipSign(v);
        }

        return total;

        static int FlipSign(int a) => a * -1;
    }

    [Benchmark]
    public long FlipSignUsingPrefixDecrementAndBinaryNot()
    {
        long total = 0;

        foreach (int v in _values)
        {
            total += FlipSign(v);
        }

        return total;

        static int FlipSign(int a) => ~--a;
    }

    [Benchmark]
    public long FlipSignUsingMinusOneAndBinaryNot()
    {
        long total = 0;

        foreach (int v in _values)
        {
            total += FlipSign(v);
        }

        return total;

        static int FlipSign(int a) => ~(a - 1);
    }
}
