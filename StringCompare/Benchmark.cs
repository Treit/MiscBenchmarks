namespace Test;
using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using System.Linq;

public class Benchmark
{
    private List<string> _strings;
    private readonly string needle = "find_me";

    [Params(1000)]
    public int Count { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        _strings = new List<string>(Count);
        for (int i = 0; i < Count; i++)
        {
            _strings.Add(i.ToString() + "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
        }

        _strings[_strings.Count - 1] = $"1234-abc-xyz{needle}zzz";
    }

    [Benchmark(Baseline = true)]
    public int Ordinal()
    {
        for (int i = 0; i < _strings.Count; i++)
        {
            if (_strings[i].Contains(needle, System.StringComparison.Ordinal))
            {
                return i;
            }
        }

        return -1;
    }

    [Benchmark]
    public int OrdinalIgnoreCase()
    {
        for (int i = 0; i < _strings.Count; i++)
        {
            if (_strings[i].Contains(needle, System.StringComparison.OrdinalIgnoreCase))
            {
                return i;
            }
        }

        return -1;
    }

    [Benchmark]
    public int CurrentCulture()
    {
        for (int i = 0; i < _strings.Count; i++)
        {
            if (_strings[i].Contains(needle, System.StringComparison.CurrentCulture))
            {
                return i;
            }
        }

        return -1;
    }

    [Benchmark]
    public int CurrentCultureIgnoreCase()
    {
        for (int i = 0; i < _strings.Count; i++)
        {
            if (_strings[i].Contains(needle, System.StringComparison.CurrentCultureIgnoreCase))
            {
                return i;
            }
        }

        return -1;
    }

    [Benchmark]
    public int InvariantCulture()
    {
        for (int i = 0; i < _strings.Count; i++)
        {
            if (_strings[i].Contains(needle, System.StringComparison.InvariantCulture))
            {
                return i;
            }
        }

        return -1;
    }

    [Benchmark]
    public int InvariantCultureIgnoreCase()
    {
        for (int i = 0; i < _strings.Count; i++)
        {
            if (_strings[i].Contains(needle, System.StringComparison.InvariantCultureIgnoreCase))
            {
                return i;
            }
        }

        return -1;
    }
}
