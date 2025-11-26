namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using System;
using System.Collections.Generic;
using BenchmarkDotNet.Jobs;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    [Params(10, 10_000)]
    public int Count { get; set; }
    private List<string> _values;
    private List<string> _values2;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _values = new List<string>(Count);
        _values2 = new List<string>(Count);
        var random = new Random(Count);

        for (int i = 0; i < this.Count; i++)
        {
            var str = new string('a', random.Next(100));
            _values.Add(str);

            // Ensure they are not reference equal
            var str2 = new string(str.ToCharArray());
            _values2.Add(str2);
        }
    }

    [Benchmark(Baseline = true)]
    public int EqualStringsCompareWithEqualsOperator()
    {
        var count = 0;

        for (int i = 0; i < this.Count; i++)
        {
            if (_values[i] == _values2[i])
            {
                count++;
            }
        }

        return count;
    }

    [Benchmark]
    public int EqualStringsCompareWithEqualsMethod()
    {
        var count = 0;

        for (int i = 0; i < this.Count; i++)
        {
            if (_values[i].Equals(_values2[i]))
            {
                count++;
            }
        }

        return count;
    }

    [Benchmark]
    public int EqualStringsCompareWithEqualsMethodIgnoreCase()
    {
        var count = 0;

        for (int i = 0; i < this.Count; i++)
        {
            if (_values[i].Equals(_values2[i], StringComparison.InvariantCultureIgnoreCase))
            {
                count++;
            }
        }

        return count;
    }

    [Benchmark]
    public int EqualStringsCompareWithEqualsMethodOrdinal()
    {
        var count = 0;

        for (int i = 0; i < this.Count; i++)
        {
            if (_values[i].Equals(_values2[i], StringComparison.Ordinal))
            {
                count++;
            }
        }

        return count;
    }

    [Benchmark]
    public int EqualStringsCompareWithEqualsMethodOrdinalIgnoreCase()
    {
        var count = 0;

        for (int i = 0; i < this.Count; i++)
        {
            if (_values[i].Equals(_values2[i], StringComparison.OrdinalIgnoreCase))
            {
                count++;
            }
        }

        return count;
    }

    [Benchmark]
    public int EqualStringsCompareWithStartsWithMethod()
    {
        var count = 0;

        for (int i = 0; i < this.Count; i++)
        {
            if (_values[i].StartsWith(_values2[i]))
            {
                count++;
            }
        }

        return count;
    }

    [Benchmark]
    public int EqualStringsCompareWithStartsWithMethodIgnoreCase()
    {
        var count = 0;

        for (int i = 0; i < this.Count; i++)
        {
            if (_values[i].StartsWith(_values2[i], StringComparison.InvariantCultureIgnoreCase))
            {
                count++;
            }
        }

        return count;
    }

    [Benchmark]
    public int EqualStringsCompareWithStartsWithMethodOrdinal()
    {
        var count = 0;

        for (int i = 0; i < this.Count; i++)
        {
            if (_values[i].StartsWith(_values2[i], StringComparison.Ordinal))
            {
                count++;
            }
        }

        return count;
    }

    [Benchmark]
    public int EqualStringsCompareWithStartsWithMethodOrdinalIgnoreCase()
    {
        var count = 0;

        for (int i = 0; i < this.Count; i++)
        {
            if (_values[i].StartsWith(_values2[i], StringComparison.OrdinalIgnoreCase))
            {
                count++;
            }
        }

        return count;
    }
}
