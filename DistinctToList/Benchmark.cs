namespace Test;
using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;

[MemoryDiagnoser]
public class Benchmark
{
    [Params(10, 1_000_000)]
    public int Count { get; set; }

    private List<int> _data;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _data = new List<int>(Count);

        var r = new Random(Count);

        for (int i = 0; i < Count; i++)
        {
            _data.Add(i);

            if (r.Next() % 2 == 0)
            {
                _data.Add(i);
            }
        }
    }

    [Benchmark(Baseline = true)]
    public long ToListThenDistinct()
    {
        return _data.ToList().Distinct().Count();
    }

    [Benchmark]
    public long DistinctThenToList()
    {
        return _data.Distinct().ToList().Count();
    }

    [Benchmark]
    public long DistinctOnly()
    {
        return _data.Distinct().Count();
    }
}
