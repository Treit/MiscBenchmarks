namespace Test;
using BenchmarkDotNet.Attributes;
using System;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using BenchmarkDotNet.Jobs;

[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]

public class Benchmark
{
    [Params(10, 10_000)]
    public int Count { get; set; }

    private static List<int> RandomInts;

    [GlobalSetup]
    public void GlobalSetup()
    {
        RandomInts = new List<int>(Count);

        // Use Count as the seed.
        var r = new Random(Count);

        for (int i = 0; i < Count; i++)
        {
            RandomInts.Add(r.Next(16));
        }
    }

    [Benchmark(Baseline = true)]
    public List<double> ConvertAll()
    {
        var doubles = RandomInts.ConvertAll(x => (double)x);
        return doubles;
    }

    [Benchmark]
    public List<double> SelectAndToList()
    {
        var doubles = RandomInts.Select(x => (double)x).ToList();
        return doubles;
    }
}
