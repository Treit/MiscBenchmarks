namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

[MemoryDiagnoser]
public class Benchmark
{

    [Params(100)]
    public int Count { get; set; }

    private Dictionary<string, int> _dictionary;

    private string _key;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _dictionary = new Dictionary<string, int>(Count);
        for (int i = 0; i < Count; i++)
        {
            _dictionary.Add(i.ToString(), i);
        }

        _key = (Count - 1).ToString();
    }

    [Benchmark(Baseline = true)]
    public int IncrementUsingGetValueRefOrAddDefault()
    {
        return ++CollectionsMarshal.GetValueRefOrAddDefault(_dictionary, _key, out _);
    }

    [Benchmark]
    public int IncrementUsingTryGetValue()
    {
        if (_dictionary.TryGetValue(_key, out var value))
        {
            ++value;
            _dictionary[_key] = value;
            return value;
        }
        else
        {
            _dictionary[_key] = default;
            return default;
        }
    }

}
