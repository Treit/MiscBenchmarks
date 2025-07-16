namespace Test;
using BenchmarkDotNet.Attributes;
using System.Collections.Generic;

[MemoryDiagnoser]
public class Benchmark
{
    [Params(4, 10, 100, 1024, 100_000)]
    public int Count { get; set; }

    private LinkedList<int> _linkedList;

    private List<int> _list;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _linkedList = CreateLinkedList();
        _list = CreateList();
    }

    [Benchmark]
    public LinkedList<int> CreateLinkedList()
    {
        var list = new LinkedList<int>();

        for (int i = 0; i < Count; i++)
        {
            list.AddLast(i);
        }

        return list;
    }

    [Benchmark]
    public List<int> CreateList()
    {
        var list = new List<int>();

        for (int i = 0; i < Count; i++)
        {
            list.Add(i);
        }

        return list;
    }

    [Benchmark]
    public long IterateLinkedList()
    {
        int sum = 0;

        foreach (var val in _linkedList)
        {
            sum += val;
        }

        return sum;
    }

    [Benchmark(Baseline = true)]
    public long IterateList()
    {
        int sum = 0;

        foreach (var val in _list)
        {
            sum += val;
        }

        return sum;
    }
}
