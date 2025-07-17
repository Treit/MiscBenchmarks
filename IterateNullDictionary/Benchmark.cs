namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using System.Collections.Generic;

[MemoryDiagnoser]
public class Benchmark
{
    private Dictionary<int, string> _dictionary;
    private Dictionary<int, string> _nullDictionary;

    [Params(10, 1000)]
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

        for (var i = 0; i < Count; i++)
        {
            foreach (var kvp in _nullDictionary ?? new Dictionary<int, string>())
            {
                count++;
            }
        }

        return count;
    }

    [Benchmark(Baseline = true)]
    public int NullCheck()
    {
        var count = 0;

        for (var i = 0; i < Count; i++)
        {
            if (_nullDictionary != null)
            {
                foreach (var kvp in _nullDictionary)
                {
                    count++;
                }
            }
        }

        return count;
    }
}
