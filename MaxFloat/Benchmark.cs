namespace Test;

using BenchmarkDotNet.Attributes;
using System;
using System.Numerics;

[MemoryDiagnoser]
public class Benchmark
{
    [Params(1_000, 100_000, 100_000_000)]
    public int IterationCount { get; set; } = 100_000;

    Random ran;
    float[] numbers;

    [GlobalSetup]
    public void GlobalSetup()
    {
        ran = new Random(1);
        numbers = new float[IterationCount];
        for (var i = 0; i < IterationCount; i++)
        {
            numbers[i] = ran.NextSingle();
        }
    }

    [Benchmark(Baseline = true)]
    public float OrdinaryMax()
    {
        var result = float.MinValue;
        foreach (var n in numbers)
        {
            result = Math.Max(n, result);
        }
        return result;
    }

    [Benchmark]
    public float IfMax()
    {
        var result = float.MinValue;
        foreach (var n in numbers)
        {
            if (n > result)
            {
                result = n;
            }
        }
        return result;
    }

    [Benchmark]
    public float TernaryMax()
    {
        var result = float.MinValue;
        foreach (var n in numbers)
        {
            result = (n > result) ? n : result;
        }
        return result;
    }

    [Benchmark]
    public float VectorMax() //https://github.com/CBGonzalez/SIMDIntro
    {
        var result = float.MinValue;
        var vResult = new Vector<float>(float.MinValue);
        var length = numbers.Length;
        var vectorCount = 8; //Vector<double>.Count == 4?;
        var remaining = length % vectorCount;
        var i = 0;
        for (; i < length - remaining; i += vectorCount)
        {
            var v1 = new Vector<float>(numbers, i);
            vResult = Vector.Max(v1, vResult);
        }

        for (; i < numbers.Length; i++)
        {
            result = (numbers[i] > result) ? numbers[i] : result;
        }

        for (var j = 0; j < vectorCount; j++)
        {
            result = (vResult[j] > result) ? vResult[j] : result;
        }

        return result;
    }
}