namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using System.Collections.Generic;
using BenchmarkDotNet.Jobs;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    private string[] _stringArray;
    private List<string> _stringList;

    [Params(10, 100_000)]
    public int Count { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        _stringArray = new string[Count];
        _stringList = new List<string>(Count);

        for (int i = 0; i < Count; i++)
        {
            var str = i.ToString();
            _stringArray[i] = str;
            _stringList.Add(str);
        }
    }

    [Benchmark(Baseline = true)]
    public long ForLoopArray()
    {
        long result = 0;
        var items = _stringArray;

        for (int i = 0; i < items.Length; i++)
        {
            result += items[i].Length;
        }

        return result;
    }

    [Benchmark]
    public long ForEachLoopArray()
    {
        long result = 0;
        var items = _stringArray;

        foreach (var item in items)
        {
            result += item.Length;
        }

        return result;
    }

    [Benchmark]
    public long ForLoopList()
    {
        long result = 0;
        var items = _stringList;

        for (int i = 0; i < items.Count; i++)
        {
            result += items[i].Length;
        }

        return result;
    }

    [Benchmark]
    public long ForEachLoopList()
    {
        long result = 0;
        var items = _stringList;

        foreach (var item in items)
        {
            result += item.Length;
        }

        return result;
    }
}
