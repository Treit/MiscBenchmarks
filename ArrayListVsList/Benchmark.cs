namespace Test;
using BenchmarkDotNet.Attributes;
using System.Collections;
using System.Collections.Generic;
using BenchmarkDotNet.Jobs;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    [Params(100_000)]
    public int Count { get; set; }

    private ArrayList _arrayList;
    private ArrayList _arrayListObject;

    private List<int> _list;
    private List<object> _listObject;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _arrayList = CreateArrayListOfInt();
        _list = CreateListOfInt();
        _arrayListObject = CreateArrayListOfObject();
        _listObject = CreateListOfObject();
    }

    [Benchmark]
    public ArrayList CreateArrayListOfInt()
    {
        var list = new ArrayList();

        for (int i = 0; i < Count; i++)
        {
            list.Add(i);
        }

        return list;
    }

    [Benchmark]
    public List<int> CreateListOfInt()
    {
        var list = new List<int>();

        for (int i = 0; i < Count; i++)
        {
            list.Add(i);
        }

        return list;
    }

    [Benchmark]
    public ArrayList CreateArrayListOfObject()
    {
        var list = new ArrayList();

        for (int i = 0; i < Count; i++)
        {
            list.Add((object)i.ToString());
        }

        return list;
    }

    [Benchmark]
    public List<object> CreateListOfObject()
    {
        var list = new List<object>();

        for (int i = 0; i < Count; i++)
        {
            list.Add((object)i.ToString());
        }

        return list;
    }

    [Benchmark]
    public long IterateArrayListOfInt()
    {
        int sum = 0;

        foreach (var val in _arrayList)
        {
            sum += (int)val;
        }

        return sum;
    }

    [Benchmark(Baseline = true)]
    public long IterateListOfInt()
    {
        int sum = 0;

        foreach (var val in _list)
        {
            sum += val;
        }

        return sum;
    }

    [Benchmark]
    public long IterateArrayListOfObject()
    {
        int sum = 0;

        foreach (var val in _arrayListObject)
        {
            sum += ((string)val).Length;
        }

        return sum;
    }

    [Benchmark]
    public long IterateListOfObject()
    {
        int sum = 0;

        foreach (var val in _listObject)
        {
            sum += ((string)val).Length;
        }

        return sum;
    }
}
