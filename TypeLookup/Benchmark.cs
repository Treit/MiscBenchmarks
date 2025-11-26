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
    Dictionary<string, string> _stringKeyDict;
    Dictionary<Type, string> _typeKeyDict;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _stringKeyDict = new Dictionary<string, string>();
        _typeKeyDict = new Dictionary<Type, string>();
        _stringKeyDict.Add(typeof(string).Name, "Some Value");
        _typeKeyDict.Add(typeof(string), "Some Value");
    }

    [Benchmark(Baseline = true)]
    public long LookupByType()
    {
        var result = 0L;

        for (int i = 0; i < 1000; i++)
        {
            if (_stringKeyDict.TryGetValue(typeof(string).Name, out var val))
            {
                result++;
            }
        }

        return result;
    }

    [Benchmark]
    public long LookupByName()
    {
        var result = 0L;

        for (int i = 0; i < 1000; i++)
        {
            if (_typeKeyDict.TryGetValue(typeof(string), out var val))
            {
                result++;
            }
        }

        return result;
    }
}
