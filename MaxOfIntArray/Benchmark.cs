namespace Test;

using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Jobs;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    [Params(1_000, 1_000_000)]
    public int Count { get; set; } = 100_000;

    Random ran;
    int[] _numbers;

    [GlobalSetup]
    public void GlobalSetup()
    {
        ran = new Random(1);
        _numbers = new int[Count];
        for (var i = 0; i < Count; i++)
        {
            _numbers[i] = ran.Next();
        }
    }

    [Benchmark]
    public int MaxWithLoop()
    {
        var result = int.MinValue;
        foreach (var n in _numbers)
        {
            result = Math.Max(n, result);
        }

        return result;
    }

    [Benchmark(Baseline = true)]
    public int EnumerableMax()
    {
        IEnumerable<int> numbers = _numbers;
        return numbers.Max();
    }
}