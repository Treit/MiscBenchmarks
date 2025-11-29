using System.Text;

namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Jobs;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    [Params(2, 10, 50)]
    public int ArrayCount { get; set; }

    [Params(10, 100, 10000)]
    public int ArraySize { get; set; }

    private List<string[]> _arrays;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _arrays = new List<string[]>(ArrayCount);

        var r = new Random();

        for (int i = 0; i < ArrayCount; i++)
        {
            _arrays.Add(new string[ArraySize]);

            for (int j = 0; j < ArraySize; j++)
            {
                _arrays[i][j] = r.Next(100).ToString();
            }
        }
    }

    [Benchmark(Baseline = true)]
    public int MergeUsingConcat()
    {
        var result = Enumerable.Empty<string>();

        foreach (var arr in _arrays)
        {
            result = result.Concat(arr);
        }

        return result.ToArray().Length;
    }

    [Benchmark]
    public int MergeUsingUnion()
    {
        var result = Enumerable.Empty<string>();

        foreach (var arr in _arrays)
        {
            result = result.Union(arr);
        }

        return result.ToArray().Length;
    }

    [Benchmark]
    public int MergeUsingArrayCopy()
    {
        var result = new string[ArrayCount * ArraySize];
        int pos = 0;

        foreach (var arr in _arrays)
        {
            Array.Copy(arr, 0, result, pos, arr.Length);
            pos += arr.Length;
        }

        return result.Length;
    }
}
