namespace Test;
using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using System.Linq;

public class Benchmark
{
    private List<string> _strings;
    private string needle = "find_me";

    [Params(10, 1000, 1_000_000)]
    public int Count { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        _strings = new List<string>(Count);
        for (int i = 0; i < Count; i++)
        {
            _strings.Add(i.ToString());
        }

        _strings[_strings.Count - 1] = needle;
    }

    [Benchmark(Baseline = true)]
    public int ForLoopSearch()
    {
        for (int i = 0; i < _strings.Count; i++)
        {
            if (_strings[i] == needle)
            {
                return i;
            }
        }

        return -1;
    }

    [Benchmark]
    public int ForEachLoopSearch()
    {
        int index = 0;
        foreach (string s in _strings)
        {
            if (s == needle)
            {
                return index;
            }

            index++;
        }

        return -1;
    }

    [Benchmark]
    public int ListFindIndexSearch()
    {
        return _strings.FindIndex(x => x == needle);
    }

    [Benchmark]
    public int ListIndexOfSearch()
    {
        return _strings.IndexOf(needle);
    }

    [Benchmark]
    public int LinqSearch()
    {
        var result = _strings.Where(x => x == needle).Select((_, idx) => idx);
        return result.Any() ? result.First() : -1;
    }
}
