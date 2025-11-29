namespace Test;
using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Jobs;

[MemoryDiagnoser]
public partial class Benchmark
{
    private static string _pattern = @"^[^-]*-[^-]*$";

    [GeneratedRegex(@"^[^-]*-[^-]*$", RegexOptions.None)]
    private static partial Regex GetSourceGenRegex();

    [Params(1000)]
    public int Count { get; set; }

    private List<string> _delimitedStrings;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _delimitedStrings = new List<string>(Count);
        var random = new Random(Count);
        for (var i = 0; i < Count; i++)
        {
            if (random.Next() % 2 == 0)
            {
                _delimitedStrings.Add($"{ random.Next(0, 1000)}-{random.Next(0, 1000)}");
            }
            else
            {
                _delimitedStrings.Add($"{random.Next(0, 1000)}-{random.Next(0, 1000)}-{random.Next(0, 1000)}");
            }
        }
    }

    [Benchmark]
    public long CountTokensUsingLinqCount()
    {
        var result = 0L;
        foreach (var s in _delimitedStrings)
        {
            var count = s.Count(c => c == '-');
            if (count == 1)
            {
                result++;
            }
        }

        return result;
    }

    [Benchmark(Baseline = true)]
    public long CountTokensUsingSpanCount()
    {
        var result = 0L;
        foreach (var s in _delimitedStrings)
        {
            var count = s.AsSpan().Count('-');
            if (count == 1)
            {
                result++;
            }
        }

        return result;
    }

    [Benchmark]
    public long CountTokensUsingHandWrittenForEachLoop()
    {
        var result = 0L;
        foreach (var s in _delimitedStrings)
        {
            var count = 0;
            foreach (var c in s)
            {
                if (c == '-')
                {
                    count++;
                }
            }

            if (count == 1)
            {
                result++;
            }
        }

        return result;
    }

    [Benchmark]
    public long CountTokensUsingHandWrittenForLoop()
    {
        var result = 0L;
        foreach (var s in _delimitedStrings)
        {
            var count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '-')
                {
                    count++;
                }
            }

            if (count == 1)
            {
                result++;
            }
        }

        return result;
    }

    [Benchmark]
    public long CountTokensUsingHandWrittenForEachLoopWithShortCircuit()
    {
        var result = 0L;
        foreach (var s in _delimitedStrings)
        {
            var count = 0;
            foreach (var c in s)
            {
                if (c == '-')
                {
                    count++;
                }

                if (count > 1)
                {
                    break;
                }
            }

            if (count == 1)
            {
                result++;
            }
        }

        return result;
    }

    [Benchmark]
    public long CountTokensUsingHandWrittenForEachLoopWithIndexOf()
    {
        var result = 0L;
        foreach (var s in _delimitedStrings)
        {
            var index = s.IndexOf('-');
            if (index == -1)
            {
                continue;
            }

            index = s.IndexOf('-', index + 1);
            if (index == -1)
            {
                result++;
            }
        }

        return result;
    }

    [Benchmark]
    public long CountTokensUsingHandWrittenForEachLoopWithIndexOfAaron()
    {
        var result = 0L;
        foreach (var s in _delimitedStrings)
        {
            var firstIndex = s.IndexOf('-');
            if (firstIndex == -1)
            {
                continue;
            }

            if (s.AsSpan()[(firstIndex + 1)..].IndexOf('-') == -1)
            {
                result++;
            }
        }

        return result;
    }

    [Benchmark]
    public long CountTokensUsingHandWrittenForEachLoopWithRegex()
    {
        var result = 0L;
        foreach (var s in _delimitedStrings)
        {
            if (Regex.IsMatch(s, _pattern))
            {
                result++;
            }
        }

        return result;
    }

    [Benchmark]
    public long CountTokensUsingHandWrittenForEachLoopWithSourceGenRegex()
    {
        var result = 0L;
        var regex = GetSourceGenRegex();
        foreach (var s in _delimitedStrings)
        {
            if (regex.IsMatch(s))
            {
                result++;
            }
        }

        return result;
    }

    [Benchmark]
    public long CountTokensUsingSplitAndLength()
    {
        var result = 0L;
        foreach (var s in _delimitedStrings)
        {
            var count = s.Split('-').Length;
            if (count == 2)
            {
                result++;
            }
        }

        return result;
    }

    [Benchmark]
    public long CountTokensUsingSplitToListAndCount()
    {
        var result = 0L;
        foreach (var s in _delimitedStrings)
        {
            var count = s.Split('-').ToList().Count;
            if (count == 2)
            {
                result++;
            }
        }

        return result;
    }
}
