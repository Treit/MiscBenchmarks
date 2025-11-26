namespace Test;
using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using BenchmarkDotNet.Jobs;

[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]

public class Benchmark
{
    [Params(10_000, 1_000_000)]
    public int Count { get; set; }

    private List<int> _list;
    private int[] _array;
    private List<int> _populatedList;
    private int[] _populatedArray;

    [IterationSetup]
    public void IterationSetup()
    {
        _list = new List<int>(Count);
        _array = new int[Count];
        _populatedList = new List<int>(Count);
        _populatedArray = new int[Count];

        for (int i = 0; i < Count; i++)
        {
            _populatedList.Add(i);
            _populatedArray[i] = i;
        }

    }

    [Benchmark]
    public List<int> PopulateList()
    {
        var list = _list;

        for (int i = 0; i < Count; i++)
        {
            list.Add(i);
        }

        return list;
    }

    [Benchmark]
    public int[] PopulateArray()
    {
        var array = _array;

        for (int i = 0; i < Count; i++)
        {
            _array[i] = i;
        }

        return _array;
    }

    [Benchmark]
    public long SumList()
    {
        var list = _populatedList;
        long sum = 0;

        for (int i = 0; i < Count; i++)
        {
            sum += list[i];
        }

        return sum;
    }

    [Benchmark(Baseline = true)]
    public long SumArray()
    {
        var array = _populatedArray;
        long sum = 0;

        for (int i = 0; i < Count; i++)
        {
            sum += array[i];
        }

        return sum;
    }
}
