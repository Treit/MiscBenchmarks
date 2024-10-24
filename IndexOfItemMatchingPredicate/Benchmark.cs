namespace Test;

using BenchmarkDotNet.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using SuperLinq;

[MemoryDiagnoser]
public class Benchmark
{
    [Params(10, 10_000)]
    public int Count { get; set; }

    Func<string, bool> _predicateFunc;
    Predicate<string> _predicate;

    Random _rnd;
    IEnumerable<string> _values;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _rnd = new Random(Count);
        var values = new string[Count];
        var item = _rnd.Next(Count);
        _predicate = x => x == values[item];
        _predicateFunc = x => x == values[item];

        for (var i = 0; i < Count; i++)
        {
            values[i] = Guid.NewGuid().ToString();
        }

        _values = values;
    }

    [Benchmark(Baseline = true)]
    public int ToListFindIndex()
    {
        return _values.ToList().FindIndex(_predicate);
    }

    [Benchmark]
    public int SelectFirstOrDefaultWithAnonymousType()
    {
        var result = _values
            .Select((value, index) => new { value, index })
            .FirstOrDefault(x => _predicateFunc(x.value));

        return result?.index ?? -1;
    }

    [Benchmark]
    public int SuperLinqFindIndex()
    {
        return _values.FindIndex(_predicateFunc);
    }
}