namespace Test;
using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Jobs;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    [Params(10_000)]
    public int Count { get; set; }

    private List<nuint> _valueTypesToAdd;
    private List<string> _referenceTypesToAdd;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _valueTypesToAdd = new List<nuint>();
        _referenceTypesToAdd = new List<string>();

        for (int i = 0; i < Count; i++)
        {
            _valueTypesToAdd.Add((nuint)i);
            _referenceTypesToAdd.Add($"Item_{i}");
        }
    }

    [Benchmark(Baseline = true)]
    public long AddValueTypesWithForEach()
    {
        var list = new List<nuint>();

        foreach (var item in _valueTypesToAdd)
        {
            list.Add(item);
        }

        return list.Count;
    }

    [Benchmark]
    public long AddReferenceTypesWithForEach()
    {
        var list = new List<string>();

        foreach (var item in _referenceTypesToAdd)
        {
            list.Add(item);
        }

        return list.Count;
    }

    [Benchmark]
    public long AddValueTypesPresetCapacity()
    {
        var list = new List<nuint>(Count);

        foreach (var item in _valueTypesToAdd)
        {
            list.Add(item);
        }

        return list.Count;
    }

    [Benchmark]
    public long AddReferenceTypesPresetCapacity()
    {
        var list = new List<string>(Count);

        foreach (var item in _referenceTypesToAdd)
        {
            list.Add(item);
        }

        return list.Count;
    }

    [Benchmark]
    public long AddValueTypesWithAddRange()
    {
        var list = new List<nuint>();
        list.AddRange(_valueTypesToAdd);

        return list.Count;
    }

    [Benchmark]
    public long AddReferenceTypesWithAddRange()
    {
        var list = new List<string>();
        list.AddRange(_referenceTypesToAdd);

        return list.Count;
    }

    [Benchmark]
    public long ValueTypesToListWithConstructor()
    {
        var list = new List<nuint>(_valueTypesToAdd);
        return list.Count;
    }

    [Benchmark]
    public long ReferenceTypesToListWithConstructor()
    {
        var list = new List<string>(_referenceTypesToAdd);
        return list.Count;
    }
}
