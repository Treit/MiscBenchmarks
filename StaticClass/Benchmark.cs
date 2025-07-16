namespace Test;
using System;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;

static class StaticClass
{
    public static int Add(int a, int b)
    {
        return a + b;
    }
}

class NonStaticClass
{
    public static int Add(int a, int b)
    {
        return a + b;
    }
}

[MemoryDiagnoser]
public class Benchmark
{
    private int[] _array;

    [Params(100, 100_000)]
    public int Count { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        _array = new int[Count];
        var r = new Random(Count);

        for (int i = 0; i < _array.Length; i++)
        {
            _array[i] = r.Next(32, 127);
        }
    }

    [Benchmark]
    public long CallStaticMethodOnStaticClass()
    {
        var result = 0L;

        foreach (var pair in _array.Chunk(2))
        {
            result += StaticClass.Add(pair[0], pair[1]);
        }

        return result;
    }

    [Benchmark]
    public long CallStaticMethodOnNonStaticClass()
    {
        var result = 0L;

        foreach (var pair in _array.Chunk(2))
        {
            result += NonStaticClass.Add(pair[0], pair[1]);
        }

        return result;
    }
}
