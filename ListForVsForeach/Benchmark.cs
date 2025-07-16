namespace Test;
using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class Benchmark
{
    private List<string> _strings;

    [Params(10, 1000, 1_000_000)]
    public int Count { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        _strings = new List<string>(Count);
        for (int i = 0; i < Count; i++)
        {
            if (i % 10 == 0)
            {
                _strings.Add("");
            }
            else
            {
                _strings.Add(i.ToString());
            }
        }
    }

    [Benchmark]
    public int ForLoopCount()
    {
        int count = 0;
        var temp = _strings;
        for (int i = 0; i < temp.Count; i++)
        {
            if (temp[i].Length == 0)
            {
                count++;
            }
        }

        return count;
    }

    [Benchmark(Baseline = true)]
    public int ForEachLoopCount()
    {
        int count = 0;
        foreach (string s in _strings)
        {
            if (s.Length == 0)
            {
                count++;
            }
        }

        return count;
    }

    [Benchmark]
    public int ForEachLoopCountCollectionsMarshalAsSpan()
    {
        int count = 0;
        foreach (string s in CollectionsMarshal.AsSpan(_strings))
        {
            if (s.Length == 0)
            {
                count++;
            }
        }

        return count;
    }

    [Benchmark]
    public int ListDotForEachLoopCount()
    {
        int count = 0;
        _strings.ForEach(s =>
        {
            if (s.Length == 0)
            {
                count++;
            }
        });

        return count;
    }

    [Benchmark]
    public int ListExplicitEnumeratorCount()
    {
        int count = 0;
        var enumerator = _strings.GetEnumerator();

        while (enumerator.MoveNext())
        {
            if (enumerator.Current.Length == 0)
            {
                count++;
            }
        }

        return count;
    }
}
