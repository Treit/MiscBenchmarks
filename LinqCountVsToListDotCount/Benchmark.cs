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
    [Params(10, 1_000_000)]
    public int Count { get; set; }

    private List<SomeData> _items;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _items = new List<SomeData>(Count);

        // Use Count as the seed.
        var r = new Random(Count);

        for (int i = 0; i < Count; i++)
        {
            _items.Add(new SomeData($"Name {i}", r.Next(1000)));
        }
    }

    [Benchmark(Baseline = true)]
    public int LinqCount()
    {
        var tocount = _items;
        return tocount.Count(x => x.Score != 0);
    }

    [Benchmark]
    public int ToListDotCount()
    {
        var tocount = _items;
        return tocount.Where(x => x.Score != 0).ToList().Count;
    }
}
