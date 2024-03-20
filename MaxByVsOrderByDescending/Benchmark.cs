namespace Test;

using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using SuperLinq;

public record MyClass(int Id, string Name);

[MemoryDiagnoser]
public class Benchmark
{
    List<MyClass> _data;

    [Params(100, 100_000)]
    public int Count { get; set; } = 100_000;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _data = new List<MyClass>(Count);
        var random = new Random(Count);

        for (var i = 0; i < Count; i++)
        {
            var id = random.Next();
            var name = Guid.NewGuid().ToString();
            _data.Add(new MyClass(id, name));
        }
    }

    [Benchmark(Baseline = true)]
    public MyClass MaxBy()
    {
        return _data.MaxBy(x => x.Id);
    }

    [Benchmark]
    public MyClass OrderByDescendingFirst()
    {
        return _data.OrderByDescending(x => x.Id).FirstOrDefault();
    }

    [Benchmark]
    public MyClass OrderByDescendingFirstWithUnnecessaryToList()
    {
        return _data.OrderByDescending(x => x.Id).ToList().FirstOrDefault();
    }

    [Benchmark]
    public MyClass SuperLinqPartialSortByDescendingFirst()
    {
        return _data.PartialSortBy(1, x => x.Id, OrderByDirection.Descending).FirstOrDefault();
    }
}