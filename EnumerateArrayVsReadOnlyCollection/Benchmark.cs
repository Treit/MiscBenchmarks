namespace Test;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Jobs;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net70)]
[SimpleJob(RuntimeMoniker.Net80)]
[SimpleJob(RuntimeMoniker.Net90, baseline: true)]
public class Benchmark
{
    private string[] _array;
    private ReadOnlyCollection<string> _readOnlyCollection;

    [Params(100)]
    public int Count { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        _array = new string[Count];
        for (int i = 0; i < Count; i++)
        {
            var str = i.ToString();
            _array[i] = str;
        }

        _readOnlyCollection = new ReadOnlyCollection<string>(_array);
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

    [Benchmark(Baseline = true)]
    public int EnumerateReadOnlyCollection()
    {
        return Enumerate(_readOnlyCollection);
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
