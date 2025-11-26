namespace Test;
using BenchmarkDotNet.Attributes;
using System;
using System.Linq;
using BenchmarkDotNet.Jobs;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    private static readonly char[] _separator = new char[] { ',' };

    [Params(100)]
    public int Count { get; set; }

    private string _delimitedString;

    [GlobalSetup]
    public void GlobalSetup()
    {
        var random = new Random(Count);
        _delimitedString = string.Join(',', Enumerable.Range(1, random.Next(Count)).Select(x => x.ToString()));
    }

    [Benchmark(Baseline = true)]
    public long SplitWithSingleChar()
    {
        var sum = 0L;
        foreach (var s in _delimitedString.Split(','))
        {
            sum += long.Parse(s);
        }

        return sum;
    }

    [Benchmark]
    public long SplitWithSingleString()
    {
        var sum = 0L;
        foreach (var s in _delimitedString.Split(","))
        {
            sum += long.Parse(s);
        }

        return sum;
    }

    [Benchmark]
    public long SplitWithNewCharArray()
    {
        var sum = 0L;

        foreach (var s in _delimitedString.Split(new char[] { ',' }))
        {
            sum += long.Parse(s);
        }

        return sum;
    }

    [Benchmark]
    public long SplitWithStaticCharArray()
    {
        var sum = 0L;
        foreach (var s in _delimitedString.Split(_separator))
        {
            sum += long.Parse(s);
        }

        return sum;
    }
}
