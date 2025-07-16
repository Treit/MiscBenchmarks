namespace Test;
using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using System.Linq;

[MemoryDiagnoser]
public class Benchmark
{
    [Params(100)]
    public int Count { get; set; }

    private IList<int> _itemsToAppend;

    [GlobalSetup]
    public void GlobalSetup()
    {
        var temp = new List<int>();

        for (int i = 0; i < Count; i++)
        {
            temp.Add(i);
        }

        _itemsToAppend = temp;
    }

    [Benchmark]
    public long AddToListWithForEachLoop()
    {
        var list = new List<int>();

        foreach (var i in _itemsToAppend)
        {
            list.Add(i);
        }

        return list.Count;
    }

    [Benchmark]
    public long AddToListPresetCapacity()
    {
        var list = new List<int>(Count);

        foreach (var i in _itemsToAppend)
        {
            list.Add(i);
        }

        return list.Count;
    }

    [Benchmark]
    public long AddToListWithToListDotForEach()
    {
        var list = new List<int>();

        _itemsToAppend.ToList().ForEach(i => list.Add(i));

        return list.Count;
    }

    [Benchmark]
    public long AddToListWithAddRange()
    {
        var list = new List<int>();
        list.AddRange(_itemsToAppend);

        return list.Count;
    }

    [Benchmark]
    public long AddToListPresetCapacityAddRange()
    {
        var list = new List<int>(Count);
        list.AddRange(_itemsToAppend);

        return list.Count;
    }

    [Benchmark]
    public long ToList()
    {
        var list = _itemsToAppend.ToList();
        return list.Count;
    }

    [Benchmark(Baseline = true)]
    public long AddToListWithConstructor()
    {
        var list = new List<int>(_itemsToAppend);
        return list.Count;
    }
}
