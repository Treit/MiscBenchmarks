namespace Test;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;

[MemoryDiagnoser]
public class Benchmark
{
    private string[] _array;
    private List<string> _list;
    private ReadOnlyCollection<string> _readOnlyCollection;
    private ImmutableArray<string> _immutableArray;
    private IReadOnlyList<string> _readOnlyList;
    private ArraySegment<string> _arraySegment;
    private LinkedList<string> _linkedList;

    [Params(100)]
    public int Count { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        _array = new string[Count];
        _list = new List<string>(Count);

        for (int i = 0; i < Count; i++)
        {
            var str = i.ToString();
            _array[i] = str;
            _list.Add(str);
        }

        _readOnlyCollection = new ReadOnlyCollection<string>(_array);
        _immutableArray = [.. _array];
        _readOnlyList = _list.AsReadOnly();
        _arraySegment = new ArraySegment<string>(_array);

        _linkedList = new LinkedList<string>();
        foreach (var item in _array)
        {
            _linkedList.AddLast(item);
        }
    }

    [Benchmark]
    public int EnumerateArray()
    {
        return Enumerate(_array);
    }

    [Benchmark]
    public int EnumerateArrayAsEnumerable()
    {
        return Enumerate(_array.AsEnumerable());
    }

    [Benchmark]
    public int EnumerateList()
    {
        return Enumerate(_list);
    }

    [Benchmark(Baseline = true)]
    public int EnumerateReadOnlyCollection()
    {
        return Enumerate(_readOnlyCollection);
    }

    [Benchmark]
    public int EnumerateImmutableArray()
    {
        return Enumerate(_immutableArray);
    }

    [Benchmark]
    public int EnumerateReadOnlyList()
    {
        return Enumerate(_readOnlyList);
    }

    [Benchmark]
    public int EnumerateArraySegment()
    {
        return Enumerate(_arraySegment);
    }

    [Benchmark]
    public int EnumerateLinkedList()
    {
        return Enumerate(_linkedList);
    }

    private int Enumerate(IEnumerable<string> items)
    {
        int count = 0;

        foreach (var item in items)
        {
            count++;
        }

        return count;
    }
}
