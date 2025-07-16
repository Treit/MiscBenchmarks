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

            // Insert up to 20 duplicates randomly.
            for (int j = 0; j < 20; j++)
            {
                if (r.Next() % 2 == 0)
                {
                    _data.Add(i);
                }
            }
        }
    }

    [Benchmark(Baseline = true)]
    public long IterateListAfterCallingDistinct()
    {
        long result = 0;

        foreach (var val in _data.Distinct())
        {
            result += val;
        }

        return result;
    }

    [Benchmark]
    public long IterateListSkippingDuplicates()
    {
        long result = 0;

        int previous = int.MinValue;

        foreach (var val in _data)
        {
            if (val == previous)
            {
                continue;
            }

            previous = val;
            result += val;
        }

        return result;
    }
}
