namespace Test;
using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;

[MemoryDiagnoser]
public class Benchmark
{
    [Params(5, 50, 10_000)]
    public int Count { get; set; }

    private List<int> _list;
    private int _valToAdd;

    [GlobalSetup]
    public void GlobalSetup()
    {
        var random = new Random(Count);
        _list = new List<int>(Count);
        _valToAdd = random.Next();

        for (int i = 0; i < Count; i++)
        {
            _list.Add(random.Next());
        }
    }

    [Benchmark(Baseline = true)]
    public IList<int> AddWithSpreadOperator()
    {
        return [.. _list, _valToAdd];
    }

    [Benchmark]
    public IList<int> AddWithAppendAndToList()
    {
        return _list.Append(_valToAdd).ToList();
    }

    [Benchmark]
    public IList<int> CopyListWithNewThenAdd()
    {
        var result = new List<int>(_list);
        result.Add(_valToAdd);
        return result;
    }

    [Benchmark]
    public IList<int> CopyListWithToListThenAdd()
    {
        var result = _list.ToList();
        result.Add(_valToAdd);
        return result;
    }

    [Benchmark]
    public IList<int> CopyListWithAppendingNewArrayThenToList()
    {
        return _list.Concat(new[] { _valToAdd }).ToList();
    }
}
