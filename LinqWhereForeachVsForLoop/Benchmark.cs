namespace Test;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System;
using System.Linq;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    private int[] _items;
    private Func<int, bool> _condition;
    private int _threshold;

    [Params(1_000, 1_000_000)]
    public int Count { get; set; }

    [Params(10, 50, 90)]
    public int MatchPercent { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        _items = new int[Count];
        for (int i = 0; i < _items.Length; i++)
        {
            _items[i] = i % 100;
        }

        _threshold = 100 - MatchPercent;
        _condition = item => item >= _threshold;
    }

    [Benchmark]
    public long LinqWhereThenForeach()
    {
        long result = 0;

        var filtered = _items.Where(_condition);
        foreach (var item in filtered)
        {
            result += item;
        }

        return result;
    }

    [Benchmark]
    public long LinqWhereThenSum()
    {
        return _items.Where(_condition).Sum(static item => (long)item);
    }

    [Benchmark(Baseline = true)]
    public long ForLoopWithContinue()
    {
        long result = 0;

        for (int i = 0; i < _items.Length; i++)
        {
            var item = _items[i];
            if (!_condition(item))
            {
                continue;
            }

            result += item;
        }

        return result;
    }

    [Benchmark]
    public long ForLoopWithInlineCondition()
    {
        long result = 0;

        for (int i = 0; i < _items.Length; i++)
        {
            var item = _items[i];
            if (item < _threshold)
            {
                continue;
            }

            result += item;
        }

        return result;
    }
}
