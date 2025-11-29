namespace Test;
using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Jobs;

[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]

public class Benchmark
{
    [Params(10_000, 1_000_000)]
    public int Count { get; set; }

    private List<int> _list;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _list = new List<int>(Count);
        var r = new Random(Count);

        for (int i = 0; i < Count; i++)
        {
            if (r.Next() % 2 == 0)
            {
                _list.Add(i);
            }
            else
            {
                _list.Add(-1);
            }
        }
    }

    [Benchmark]
    public int LookupElementsWithIndexing()
    {
        var list = _list;
        int count = 0;

        for (int i = 0; i < Count; i++)
        {
            if (list[i] == i)
            {
                count++;
            }
        }

        return count;
    }

    [Benchmark]
    public int LookupElementsWithElementAt()
    {
        var list = _list;
        int count = 0;

        for (int i = 0; i < Count; i++)
        {
            if (list.ElementAt(i) == i)
            {
                count++;
            }
        }

        return count;
    }
}
