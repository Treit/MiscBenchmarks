using System.Text;

namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using System;
using System.Collections.Generic;
using BenchmarkDotNet.Jobs;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    [Params(3, 50, 1000, 100_000)]
    public int Count { get; set; }

    List<int> intList;
    Dictionary<int, int> intDictionary;

    [GlobalSetup]
    public void GlobalSetup()
    {
        intList = new List<int>(Count);
        intDictionary = new Dictionary<int, int>(Count);

        // Use Count as the seed.
        var r = new Random(Count);

        for (int i = 0; i < Count; i++)
        {
            int v = r.Next(16);
            intList.Add(v);
            while (true)
            {
                if (!intDictionary.ContainsKey(v))
                {
                    intDictionary.Add(v, v);
                    break;
                }

                v += 1;
            }
        }
    }

    [Benchmark(Baseline = true)]
    public long IterateList()
    {
        long result = 0;

        foreach (var i in intList)
        {
            result += i;
        }

        return result;
    }

    [Benchmark]
    public long IterateDictionaryKeys()
    {
        long result = 0;

        foreach (var i in intDictionary.Keys)
        {
            result += i;
        }

        return result;
    }

    [Benchmark]
    public long IterateDictionaryValues()
    {
        long result = 0;

        foreach (var i in intDictionary.Values)
        {
            result += i;
        }

        return result;
    }

    [Benchmark]
    public long IterateDictionaryKeyValuePairs()
    {
        long result = 0;

        foreach (var kvp in intDictionary)
        {
            result += kvp.Value;
        }

        return result;
    }
}
