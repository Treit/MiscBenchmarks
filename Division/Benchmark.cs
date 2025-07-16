namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using System;
using System.Collections.Generic;

[MemoryDiagnoser]
public class Benchmark
{
    [Params(100, 100_000)]
    public int Count { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
    }

    [Benchmark(Baseline = true)]
    public float DivideUsingFloat()
    {
        float result = int.MaxValue;

        for (int i = 0; i < Count; i++)
        {
            result /= 2f;
        }

        return result;
    }

    [Benchmark]
    public double DivideUsingDouble()
    {
        double result = int.MaxValue;

        for (int i = 0; i < Count; i++)
        {
            result /= 2d;
        }

        return result;
    }

    [Benchmark]
    public decimal DivideUsingDecimal()
    {
        decimal result = int.MaxValue;

        for (int i = 0; i < Count; i++)
        {
            result /= 2m;
        }

        return result;
    }

    [Benchmark]
    public int DivideUsingInt()
    {
        int result = int.MaxValue;

        for (int i = 0; i < Count; i++)
        {
            result /= 2;
        }

        return result;
    }
}
