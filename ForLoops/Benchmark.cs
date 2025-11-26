namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;

// ViceroyPenguin implementation.
public static class Extensions
{
    public static RangeEnumerator GetEnumerator(this Range range)
    {
        return new RangeEnumerator(range.End.Value, range.Start.Value);
    }

    public struct RangeEnumerator(int end, int current)
    {
        private readonly int _end = end;

        public int Current { get; private set; } = current - 1;

        public bool MoveNext() =>
            ++Current < _end;
    }
}

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    [Params(100, 1_000_000)]
    public int Count { get; set; }

    private List<int> _data;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _data = new List<int>(Count);

        for (int i = 0; i < Count; i++)
        {
            _data.Add(i);
        }
    }

    [Benchmark(Baseline = true)]
    public long ClassicForLoop()
    {
        long result = 0;

        for (int i = 0; i < Count; i++)
        {
            result += _data[i];
        }

        return result;
    }

    [Benchmark]
    public long ForLoopPrefixIncrementInsideConditionCheck()
    {
        long result = 0;

        for (int i = -1; ++i < Count;)
        {
            result += _data[i];
        }

        return result;
    }

    [Benchmark]
    public long LoopUsingGoto()
    {
        long result = 0;

        int i = 0;
    loop:
        result += _data[i];

        if (++i < Count)
        {
            goto loop;
        }

        return result;
    }

    [Benchmark]
    public long LoopUsingEnumerableRange()
    {
        long result = 0;

        foreach (int i in Enumerable.Range(0, _data.Count))
        {
            result += _data[i];
        }

        return result;
    }

    [Benchmark]
    public long LoopUsingRangeEnumerator()
    {
        long result = 0;

        foreach (int i in 0.._data.Count)
        {
            result += _data[i];
        }

        return result;
    }

    [Benchmark]
    public long LoopUsingSkipAny()
    {
        long result = 0;

        for (int i = 0; _data.Skip(i).Any(); i++)
        {
            result += _data[i];
        }

        return result;
    }
}
