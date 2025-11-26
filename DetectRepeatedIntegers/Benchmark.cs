using BenchmarkDotNet.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Jobs;

[MemoryDiagnoser]
//[ShortRunJob]
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    [Params(10, 10_000)]
    public int Length { get; set; }

    //[Params("First", "Middle", "Last" )]
    [Params("Middle")]
    public string ElementToDuplicate { get; set; }

    private int[] _data = null!;

    [GlobalSetup]
    public void Setup()
    {
        _data = Enumerable.Range(0, Length).ToArray();
        _data[_data.Length / 2] = ElementToDuplicate switch
        {
            "First" => _data[0],
            "Middle" => _data[_data.Length / 2],
            _ => _data[_data.Length - 1]
        };
    }

    [Benchmark]
    public bool Linq()
    {
        return _data
            .GroupBy(x => x)
            .OrderByDescending(g => g.Count())
            .First()
            .Count() > 1;
    }

    [Benchmark]
    public bool Hazel_LINQ_Any_With_Count()
    {
        return _data.Any(x => _data.Count(y => x == y) > 1);
    }

    [Benchmark]
    public bool Dictionary()
    {
        Dictionary<int, object> dict = new();
        foreach (var x in _data)
        {
            if (dict.ContainsKey(x))
                return true;
            else
                dict[x] = null!;
        }
        return false;
    }

    [Benchmark]
    public bool Aaron_Sane_HashSet_With_ShortCircuit()
    {
        var set = new HashSet<int>(_data.Length);
        foreach (var item in _data)
        {
            if (!set.Add(item)) return true;
        }
        return false;
    }

    [Benchmark]
    public bool Mtreit_A_HashSet()
    {
        var hs = new HashSet<int>(_data);
        return hs.Count < _data.Length;
    }

    [Benchmark]
    public bool Mtreit_B_BitArray()
    {
        var bitset = new BitArray(Length);
        foreach (var i in _data)
        {
            if (bitset[i])
            {
                return true;
            }

            bitset[i] = true;
        }
        return false;
    }

    [Benchmark]
    public bool Mtreit_C_LinearSearch()
    {
        var slice = _data.AsSpan();
        for (int i = 0; i < _data.Length - 1; i++)
        {
            slice = slice.Slice(1);
            if (slice.Contains(_data[i]))
            {
                return true;
            }
        }

        return false;
    }
}