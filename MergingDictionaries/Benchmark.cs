namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using System.Collections.Generic;
using System.Linq;

[MemoryDiagnoser]
public class Benchmark
{
    [Params(3, 50, 1000)]
    public int Count { get; set; }

    public int ItemsPerDictionary { get; set; }

    private IList<Dictionary<string, string>> _dictionaries;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _dictionaries = new List<Dictionary<string, string>>(Count);

        for (int i = 0; i < Count; i++)
        {
            var dict = new Dictionary<string, string>();
            for (int j = 0; j < ItemsPerDictionary; j++)
            {
                dict.Add(j.ToString(), $"{i}_{j}");
            }

            _dictionaries.Add(dict);
        }
    }

    [Benchmark(Baseline = true)]
    public Dictionary<string, List<string>> GroupBy()
    {
        var merged =
            _dictionaries
            .SelectMany(kvps => kvps)
            .GroupBy(kvp => kvp.Key, kvp => kvp.Value)
            .ToDictionary(group => group.Key, group => group.ToList());

        return merged;
    }

    [Benchmark]
    public Dictionary<string, List<string>> ToLookup()
    {
        var merged =
            _dictionaries
            .SelectMany(kvps => kvps)
            .ToLookup(kvp => kvp.Key, kvp => kvp.Value)
            .ToDictionary(group => group.Key, group => group.ToList());

        return merged;
    }

    [Benchmark]
    public Dictionary<string, List<string>> ForLoop()
    {
        var result = new Dictionary<string, List<string>>();

        foreach (var dict in _dictionaries)
        {
            foreach (var kvp in dict)
            {
                if (!result.ContainsKey(kvp.Key))
                {
                    result.Add(kvp.Key, new List<string>());
                }

                result[kvp.Key].Add(kvp.Value);
            }
        }

        return result;
    }
}
