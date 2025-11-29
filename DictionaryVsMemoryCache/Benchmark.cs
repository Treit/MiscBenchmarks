namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using BenchmarkDotNet.Jobs;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    [Params(1000)]
    public int Count { get; set; }

    private Dictionary<string, string> _dictionary;
    private ConcurrentDictionary<string, string> _concurrentDictionary;
    private MemoryCache _memCache;
    private string _key;

    [GlobalSetup]
    public void GlobalSetup()
    {
        int len = Count;

        _dictionary = new Dictionary<string, string>(len);
        _concurrentDictionary = new ConcurrentDictionary<string, string>();
        var cachePolicy = new CacheItemPolicy { SlidingExpiration = TimeSpan.FromMinutes(1) };
        _memCache = new MemoryCache("Test");

        for (int i = 0; i < len; i++)
        {
            var val = i.ToString();
            _dictionary.Add(val, val);
            _concurrentDictionary.TryAdd(val, val);
            _memCache.Add(val, val, cachePolicy);
        }

        _key = _dictionary.Keys.Skip(len / 2).Take(1).First();

    }

    [Benchmark(Baseline = true)]
    public string LookupUsingDictionary()
    {
        return _dictionary[_key];
    }

    [Benchmark]
    public string LookupUsingMemoryCache()
    {
        return (string)_memCache[_key];
    }

    [Benchmark]
    public string LookupUsingConcurrentDictionary()
    {
        _ = _concurrentDictionary.TryGetValue(_key, out var value);
        return value;
    }
}
