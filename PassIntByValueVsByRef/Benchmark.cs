namespace Test;
using System;
using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    [Params(1000, 100_000)]
    public int Count { get; set; }

    private int[] _data;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _data = new int[Count];
        var rng = new Random(42);
        for (var i = 0; i < Count; i++)
        {
            _data[i] = rng.Next();
        }
    }

    [Benchmark(Baseline = true)]
    public long PassByValue()
    {
        var sum = 0L;
        for (var i = 0; i < _data.Length; i++)
        {
            sum += AcceptByValue(_data[i]);
        }
        return sum;
    }

    [Benchmark]
    public long PassByRef()
    {
        var sum = 0L;
        for (var i = 0; i < _data.Length; i++)
        {
            sum += AcceptByRef(ref _data[i]);
        }
        return sum;
    }

    [Benchmark]
    public long PassByIn()
    {
        var sum = 0L;
        for (var i = 0; i < _data.Length; i++)
        {
            sum += AcceptByIn(in _data[i]);
        }
        return sum;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static long AcceptByValue(int value) => value * 2L;

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static long AcceptByRef(ref int value) => value * 2L;

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static long AcceptByIn(in int value) => value * 2L;
}
