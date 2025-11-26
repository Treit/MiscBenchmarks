namespace Test;
using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Jobs;

[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]

public class Benchmark
{
    private List<string> _strings;

    [Params(100, 100_000)]
    public int Count { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        _strings = new List<string>(Count);
        for (int i = 0; i < Count; i++)
        {
            _strings.Add($"\"{i}\"");
        }
    }

    [Benchmark(Baseline = true)]
    public string DeQuoteWithTrim()
    {
        var result = "";

        for (int i = 0; i < _strings.Count; i++)
        {
            var newStr = _strings[i].Trim('"');
            result = newStr;
        }

        return result;
    }

    [Benchmark]
    public string DeQuoteWithSubstring()
    {
        var result = "";

        for (int i = 0; i < _strings.Count; i++)
        {
            var newStr = _strings[i].Substring(1, _strings[i].Length - 2);
            result = newStr;
        }

        return result;
    }

    [Benchmark]
    public string DeQuoteWithRangePattern()
    {
        var result = "";

        for (int i = 0; i < _strings.Count; i++)
        {
            var newStr = _strings[i][1..^1];
            result = newStr;
        }

        return result;
    }

    [Benchmark]
    public string DeQuoteWithSpan()
    {
        var result = "";

        for (int i = 0; i < _strings.Count; i++)
        {
            var span = _strings[i].AsSpan().Slice(1, _strings[i].Length - 2);
            result = new string(span);
        }

        return result;
    }
}
