namespace Test;
using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Jobs;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    [Params(100, 1_000_000)]
    public int ListSize { get; set; }

    private List<KeyValuePair<string, int>> _keyValuePairs;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _keyValuePairs = new (ListSize);

        for (int i = 0; i < ListSize; i++)
        {
            _keyValuePairs.Add(new KeyValuePair<string, int>(i.ToString(), i));
        }
    }

    [Benchmark]
    public List<string> SelectDotToListDotGetRange()
    {
        return _keyValuePairs.Select(item => item.Key).ToList().GetRange(0, 5);
    }

    [Benchmark]
    public List<string> GetRangeDotSelectDotToList()
    {
        return _keyValuePairs.GetRange(0, 5).Select(item => item.Key).ToList();
    }

    [Benchmark]
    public List<string> SelectDotTakeDotToList()
    {
        return _keyValuePairs.Select(item => item.Key).Take(5).ToList();
    }

    [Benchmark]
    public List<string> TakeDotSelectDotToList()
    {
        return _keyValuePairs.Take(5).Select(item => item.Key).ToList();
    }

    [Benchmark(Baseline = true)]
    public List<string> NewListAndForLoop()
    {
        var result = new List<string>(5);
        for (int i = 0; i < 5; i++)
        {
            result.Add(_keyValuePairs[i].Key);
        }

        return result;
    }
}
