namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Jobs;

[MemoryDiagnoser]
[MemoryRandomization]
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    private Dictionary<string, uint> _dict;
    private string[] _arr;

    [Params(1000)]
    public int Count { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        _dict = new Dictionary<string, uint>(Count);

        for (int i = 0; i < Count; i++)
        {
            var str = i.ToString();
            _dict.Add(str, (uint)i);
        }

        _arr = _dict.Keys.ToArray();
    }

    [Benchmark]
    public long EnumerateDictionaryKeys()
    {
        var result = 0L;

        foreach (var str in _dict.Keys)
        {
            result += str.Length;
        }

        return result;

    }

    [Benchmark]
    public long EnumerateDictionaryKeyValuePairs()
    {
        var result = 0L;

        foreach (var kvp in _dict)
        {
            result += kvp.Key.Length;
        }

        return result;
    }

    [Benchmark(Baseline = true)]
    public long EnumerateDictionaryKeysCachedInArray()
    {
        var result = 0L;

        foreach (var str in _arr)
        {
            result += str.Length;
        }

        return result;
    }
}
