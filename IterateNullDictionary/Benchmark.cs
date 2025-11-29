namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Jobs;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    private Dictionary<int, string> _dictionary;
    private Dictionary<int, string> _nullDictionary;

    [Params(1000)]
    public int Count { get; set; } = 1000;
    [GlobalSetup]
    public void GlobalSetup()
    {
        _dictionary = new Dictionary<int, string>();
        for (int i = 0; i < Count; i++)
        {
            _dictionary[i] = $"Value {i}";
        }

        _nullDictionary = null;
    }

    [Benchmark]
    public int NewDictionary()
    {
        var count = 0;

        foreach (var kvp in _nullDictionary ?? new Dictionary<int, string>())
        {
            count++;
        }

        return count;
    }

    [Benchmark]
    public int EmptyCollectionLiteral()
    {
        var count = 0;

        foreach (var kvp in _nullDictionary ?? [])
        {
            count++;
        }

        return count;
    }

    [Benchmark]
    public int EnumerableDotEmpty()
    {
        var count = 0;

        foreach (var kvp in _nullDictionary ?? Enumerable.Empty<KeyValuePair<int, string>>())
        {
            count++;
        }

        return count;
    }

    [Benchmark(Baseline = true)]
    public int NullCheck()
    {
        var count = 0;

        if (_nullDictionary != null)
        {
            foreach (var kvp in _nullDictionary)
            {
                count++;
            }
        }

        return count;
    }
}
