namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using System.Collections.Concurrent;
using System.Collections.Generic;

[MemoryDiagnoser]
public class Benchmark
{
    [Params(10, 10_000)]
    public int Count { get; set; }

    private Dictionary<string, int> _dict;
    private ConcurrentDictionary<string, int> _concurrentDict;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _dict = new Dictionary<string, int>();
        _concurrentDict = new ConcurrentDictionary<string, int>();

        for (int i = 0; i < Count; i++)
        {
            if (i % 2 == 0)
            {
                _dict.Add(i.ToString(), i);
                _ = _concurrentDict.TryAdd(i.ToString(), i);
            }
        }

    }

    [Benchmark(Baseline = true)]
    public int IncrementUsingDictionary()
    {
        for (int i = 0; i < this.Count; i++)
        {
            var key = i.ToString();

            if (!_dict.ContainsKey(key))
            {
                _dict.Add(key, 0);
            }

            _dict[key] += 1;
        }

        return _dict.Count;
    }

    [Benchmark]
    public int IncrementUsingConcurrentDictionary()
    {
        for (int i = 0; i < this.Count; i++)
        {
            var key = i.ToString();
            var x = _concurrentDict.AddOrUpdate(key, 1, (k, v) => v += 1);
        }

        return _concurrentDict.Count;
    }
}
