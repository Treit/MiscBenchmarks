namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;

[MemoryDiagnoser]
public class Benchmark
{
    [Params(100, 10000)]
    public int Count { get; set; }

    public int ItemsPerList { get; set; } = 100;

    private IList<List<string>> _lists;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _lists = new List<List<string>>(Count);

        for (int i = 0; i < Count; i++)
        {
            var list = new List<string>();
            var n = Random.Shared.Next(100);

            if (n < 90)
            {
                for (int j = 0; j < ItemsPerList; j++)
                {
                    list.Add($"{i}_{j}");
                }
            }

            _lists.Add(list);
        }
    }

    [Benchmark(Baseline = true)]
    public int CheckListEmptyUsingCount()
    {
        int nonemptyCount = 0;

        for (int i = 0; i < _lists.Count; i++)
        {
            if (_lists[i].Count > 0)
            {
                nonemptyCount++;
            }
        }

        return nonemptyCount;
    }

    [Benchmark]
    public int CheckListEmptyUsingAny()
    {
        int nonemptyCount = 0;

        for (int i = 0; i < _lists.Count; i++)
        {
            if (_lists[i].Any())
            {
                nonemptyCount++;
            }
        }

        return nonemptyCount;
    }
}
