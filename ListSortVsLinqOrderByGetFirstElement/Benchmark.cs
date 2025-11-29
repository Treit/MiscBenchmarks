namespace Test;
using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Jobs;

public record SomeData(string Name, int Score);

[MemoryDiagnoser]
[MemoryRandomization]
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    [Params(8, 100, 100_000, 1_000_000)]
    public int Count { get; set; }

    private List<SomeData> _values;
    private List<SomeData> _listToSortA;
    private List<SomeData> _listToSortB;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _values = new List<SomeData>(Count);

        var r = new Random(Count);

        for (int i = 0; i < Count; i++)
        {
            _values.Add(new SomeData($"Name {i}", r.Next(1000)));
        }
    }

    [IterationSetup]
    public void IterationSetup()
    {
        _listToSortA = new List<SomeData>(_values);
        _listToSortB = new List<SomeData>(_values);
    }

    [Benchmark(Baseline = true)]
    public SomeData ListSort()
    {
        var tosort = _listToSortA;
        tosort.Sort((x, y) => x.Score.CompareTo(y.Score));
        return tosort[0];
    }

    [Benchmark]
    public SomeData LinqOrderBy()
    {
        var tosort = _listToSortB;
        return tosort.OrderBy(x => x.Score).First();
    }
}
