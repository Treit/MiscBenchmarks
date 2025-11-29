namespace Test;
using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using BenchmarkDotNet.Jobs;

[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]

public class Benchmark
{
    [Params(10_000)]
    public int Count { get; set; }
    private List<int> _intValues;
    private List<double> _doubleValues;
    private List<decimal> _decimalValues;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _intValues = new List<int>(Count);
        _doubleValues = new List<double>(Count);
        _decimalValues = new List<decimal>(Count);

        for (int i = 0; i < Count; i++)
        {
            _intValues.Add(i);
            _doubleValues.Add(i);
            _decimalValues.Add(i);
        }
    }

    [Benchmark(Baseline = true)]
    public long IntsToString()
    {
        long total = 0;

        for (int i = 0; i < Count; i++)
        {
            var tmp = _intValues[i].ToString();
            total += tmp.Length;
        }

        return total;
    }

    [Benchmark]
    public long IntsToStringUsingConvert()
    {
        long total = 0;

        for (int i = 0; i < Count; i++)
        {
            var tmp = Convert.ToString(_intValues[i]);
            total += tmp.Length;
        }

        return total;
    }

    [Benchmark]
    public long DoublesToString()
    {
        long total = 0;

        for (int i = 0; i < Count; i++)
        {
            var tmp = _doubleValues[i].ToString();
            total += tmp.Length;
        }

        return total;
    }

    [Benchmark]
    public long DoublesToStringUsingConvert()
    {
        long total = 0;

        for (int i = 0; i < Count; i++)
        {
            var tmp = Convert.ToString(_doubleValues[i]);
            total += tmp.Length;
        }

        return total;
    }

    [Benchmark]
    public long DecimalsToString()
    {
        long total = 0;

        for (int i = 0; i < Count; i++)
        {
            var tmp = _decimalValues[i].ToString();
            total += tmp.Length;
        }

        return total;
    }

    [Benchmark]
    public long DecimalsToStringUsingConvert()
    {
        long total = 0;

        for (int i = 0; i < Count; i++)
        {
            var tmp = Convert.ToString(_decimalValues[i]);
            total += tmp.Length;
        }

        return total;
    }
}
