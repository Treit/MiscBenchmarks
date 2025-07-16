namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using System;
using System.Collections.Generic;
using System.Linq;

[MemoryDiagnoser]
public class Benchmark
{
    [Params(10, 10_000)]
    public int Count { get; set; }

    private List<string> _left;
    private List<string> _right;

    [GlobalSetup]
    public void GlobalSetup()
    {
        Random r = new Random(Count);
        _left = new List<string>();
        _right = new List<string>();

        for (int i = 0; i < Count; i++)
        {
            _left.Add(r.Next(10).ToString());
            _right.Add(r.Next(10).ToString());
        }
    }

    [Benchmark(Baseline = true)]
    public int CountUsingLinqIntersect()
    {
        return _left.Intersect(_right).Count();
    }

    [Benchmark]
    public int CountUsingToHashSetIntersectToList()
    {
        return _left.ToHashSet().Intersect(_right).ToList().Count();
    }

    [Benchmark]
    public int CountUsingToHashSetIntersectWith()
    {
        var set = _left.ToHashSet();
        set.IntersectWith(_right);
        return set.Count;
    }
}
