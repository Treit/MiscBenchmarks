namespace Test;
using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using System.Linq;

[MemoryDiagnoser]
public class Benchmark
{
    [Params(100)]
    public int Count { get; set; }

    private IDictionary<string, int> _itemsToAppend;

    [GlobalSetup]
    public void GlobalSetup()
    {
        var temp = new Dictionary<string, int>();

        for (int i = 0; i < Count; i++)
        {
            temp.Add(i.ToString(), i);
        }

        _itemsToAppend = temp;
    }

    [Benchmark]
    public long CopyDictWithForEachLoop()
    {
        var dict = new Dictionary<string, int>();

        foreach (var i in _itemsToAppend)
        {
            dict.Add(i.Key, i.Value);
        }

        return dict.Count;
    }

    [Benchmark]
    public long CopyDictPresetCapacity()
    {
        var dict = new Dictionary<string, int>(Count);

        foreach (var i in _itemsToAppend)
        {
            dict.Add(i.Key, i.Value);
        }

        return dict.Count;
    }

    [Benchmark(Baseline = true)]
    public long CopyDictWithConstructor()
    {
        var dict = new Dictionary<string, int>(_itemsToAppend);
        return dict.Count;
    }

    [Benchmark]
    public long CopyDictWithToDictionaryLambdas()
    {
        var dict = _itemsToAppend.ToDictionary(x => x.Key, x => x.Value);
        return dict.Count;
    }

    [Benchmark]
    public long CopyDictWithToDictionary()
    {
        var dict = _itemsToAppend.ToDictionary();
        return dict.Count;
    }

}
