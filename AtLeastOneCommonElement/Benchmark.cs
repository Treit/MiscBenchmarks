namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Jobs;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    [Params(10, 1000)]
    public int Count { get; set; }

    private List<int> _listToCheck;
    private List<int> _listWithOneOverlappingElement;

    private HashSet<int> _hashSetWithOneOverlappingElement;

    private FrozenSet<int> _frozenSetWithOneOverlappingElement;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _listToCheck = new List<int>(Count);
        _listWithOneOverlappingElement = new List<int>(Count);

        for (int i = 0; i < Count; i++)
        {
            _listToCheck.Add(i);
            _listWithOneOverlappingElement.Add(i + 1 * 1000);
        }

        _listWithOneOverlappingElement[Count - 1] = _listToCheck[Count / 2];

        _hashSetWithOneOverlappingElement = new HashSet<int>(_listWithOneOverlappingElement);
        _frozenSetWithOneOverlappingElement = new HashSet<int>(_listWithOneOverlappingElement).ToFrozenSet();
    }

    [Benchmark]
    public bool ListAnyListContains()
    {
        return _listToCheck.Any(x => _listWithOneOverlappingElement.Contains(x));
    }

    [Benchmark]
    public bool ListAnyHashSetContains()
    {
        return _listToCheck.Any(x => _hashSetWithOneOverlappingElement.Contains(x));
    }

    [Benchmark]
    public bool ListAnyFrozenSetContains()
    {
        return _listToCheck.Any(x => _frozenSetWithOneOverlappingElement.Contains(x));
    }

    [Benchmark]
    public bool LinqIntersectListThenAny()
    {
        return _listToCheck.Intersect(_listWithOneOverlappingElement).Any();
    }

    [Benchmark]
    public bool HashSetOverlapsListMethod()
    {
        return _hashSetWithOneOverlappingElement.Overlaps(_listToCheck);
    }

    [Benchmark(Baseline = true)]
    public bool FrozenSetOverlapsListMethod()
    {
        return _frozenSetWithOneOverlappingElement.Overlaps(_listToCheck);
    }
}
