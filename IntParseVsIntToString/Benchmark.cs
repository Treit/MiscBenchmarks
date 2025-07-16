namespace Test;
using BenchmarkDotNet.Attributes;
using System.Collections.Generic;

[MemoryDiagnoser]
public class Benchmark
{
    [Params(10, 100_000)]
    public int Count { get; set; }
    private List<string> _values;
    private int _valueToCheck = 1234;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _values = new List<string>(Count);

        for (int i = 0; i < this.Count; i++)
        {
            var str = i.ToString();
            _values.Add(str);
        }
    }

    [Benchmark(Baseline = true)]
    public int CompareUsingTryParse()
    {
        int matches = 0;

        foreach (var str in _values)
        {
            if (int.Parse(str) == _valueToCheck)
            {
                matches++;
            }
        }

        return matches;
    }

    [Benchmark]
    public int CompareUsingToString()
    {
        int matches = 0;

        foreach (var str in _values)
        {
            if (str == _valueToCheck.ToString())
            {
                matches++;
            }
        }

        return matches;
    }
}
