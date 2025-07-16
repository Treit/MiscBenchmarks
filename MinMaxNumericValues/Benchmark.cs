namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Benchmark
{
    static Random random;

    List<int> intvals;
    List<long> longvals;
    List<float> floatvals;
    List<double> doublevals;

    [Params(10, 100, 100_000)]
    public int Count { get; set; }


    [GlobalSetup]
    public void GlobalSetup()
    {
        random = new Random(Count);
        intvals = new List<int>(Count);
        longvals = new List<long>(Count);
        floatvals = new List<float>(Count);
        doublevals = new List<double>(Count);

        var buff = new byte[sizeof(long)];

        for (int i = 0; i < Count; i++)
        {
            intvals.Add(random.Next());
            longvals.Add(random.NextInt64());
            floatvals.Add(random.NextSingle());
            doublevals.Add(random.NextDouble());
        }
    }

    [Benchmark(Baseline = true)]
    public (int, int) MinAndMaxInts()
    {
        int min = int.MaxValue;
        int max = int.MinValue;

        for (int i = 0; i < Count; i++)
        {
            if (intvals[i] < min)
            {
                min = intvals[i];
            }

            if (intvals[i] > max)
            {
                max = intvals[i];
            }
        }

        return (min, max);
    }

    [Benchmark]
    public (long, long) MinAndMaxLongs()
    {
        long min = int.MaxValue;
        long max = int.MinValue;

        for (int i = 0; i < Count; i++)
        {
            if (longvals[i] < min)
            {
                min = longvals[i];
            }

            if (longvals[i] > max)
            {
                max = longvals[i];
            }
        }

        return (min, max);
    }

    [Benchmark]
    public (float, float) MinAndMaxFloats()
    {
        float min = int.MaxValue;
        float max = int.MinValue;

        for (int i = 0; i < Count; i++)
        {
            if (floatvals[i] < min)
            {
                min = floatvals[i];
            }

            if (floatvals[i] > max)
            {
                max = floatvals[i];
            }
        }

        return (min, max);
    }

    [Benchmark]
    public (double, double) MinAndMaxDoubles()
    {
        double min = int.MaxValue;
        double max = int.MinValue;

        for (int i = 0; i < Count; i++)
        {
            if (doublevals[i] < min)
            {
                min = doublevals[i];
            }

            if (doublevals[i] > max)
            {
                max = doublevals[i];
            }
        }

        return (min, max);
    }
}
