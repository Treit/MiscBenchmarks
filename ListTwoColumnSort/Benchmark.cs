namespace Test;
using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;

public record SomeData(string Name, int Score);

[MemoryDiagnoser]
[MemoryRandomization]
public class Benchmark
{
    [Params(100, 100_000)]
    public int Count { get; set; }

    private List<SomeData> _values;
    private List<SomeData> _listToSort;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _values = new List<SomeData>(Count);

        // Use Count as the seed.
        var r = new Random(Count);

        for (int i = 0; i < Count; i++)
        {
            _values.Add(new SomeData($"Name {i}", r.Next(10)));
        }
    }

    [IterationSetup]
    public void IterationSetup()
    {
        _listToSort = new List<SomeData>(_values);
    }

    [Benchmark]
    public SomeData ListSortByTwoColumns()
    {
        var tosort = _listToSort;
        tosort.Sort(Compare);
        return tosort[^1];

        static int Compare(SomeData x, SomeData y)
        {
            int cmp = x.Score.CompareTo(y.Score);
            if (cmp != 0)
            {
                return cmp;
            }

            return x.Name.CompareTo(y.Name);
        }
    }

    [Benchmark(Baseline = true)]
    public SomeData LinqOrderByThenBy()
    {
        var tosort = _listToSort;
        var sorted = tosort.OrderBy(x => x.Score).ThenBy(x => x.Name);
        return sorted.Last();
    }

    [Benchmark]
    public SomeData LinqOrderByThenByWithToList()
    {
        var tosort = _listToSort;
        var sorted = tosort.OrderBy(x => x.Score).ThenBy(x => x.Name).ToList();
        return sorted[^1];
    }
}
