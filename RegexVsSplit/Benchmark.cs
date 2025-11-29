namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using CommunityToolkit.HighPerformance;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Jobs;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    [Params(10, 100, 1000, 100_000)]
    public int Count { get; set; }

    private List<string> _values;

    private Regex _re;
    private Regex _rec;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _values = new List<string>(Count);
        _re = new Regex("^.+,.+,.+,.+,.+,(.+?),");
        _rec = new Regex("^.+,.+,.+,.+,.+,(.+?),", RegexOptions.Compiled);

        for (int i = 0; i < this.Count; i++)
        {
            _values.Add($"{i},{i + 1},{i + 2},{i + 3},{i + 4},{i + 5},{i + 6},{i + 7},{i + 8},{i + 9},{i + 10}");
        }
    }

    [Benchmark(Baseline = true)]
    public int FindTokenUsingSplit()
    {
        string needle = "104";
        int result = -1;

        for (int i = 0; i < _values.Count; i++)
        {
            string[] tokens = _values[i].Split(",");
            if (tokens[5] == needle)
            {
                result = i;
            }
        }

        return result;
    }

    [Benchmark]
    public int FindTokenUsingRegex()
    {
        string needle = "104";
        int result = -1;

        for (int i = 0; i < _values.Count; i++)
        {
            Match m = _re.Match(_values[i]);
            if (m.Success && m.Result("$1") == needle)
            {
                result = i;
            }
        }

        return result;
    }

    [Benchmark]
    public int FindTokenUsingCompiledRegex()
    {
        string needle = "104";
        int result = -1;

        for (int i = 0; i < _values.Count; i++)
        {
            Match m = _rec.Match(_values[i]);
            if (m.Success && m.Result("$1") == needle)
            {
                result = i;
            }
        }

        return result;
    }

    [Benchmark]
    public int FindTokenUsingSpan()
    {
        string needle = "104";
        int result = -1;

        for (int i = 0; i < _values.Count; i++)
        {
            string value = _values[i];
            int cc = 0;
            int start = 0;
            int end = 0;

            for (int j = 0; j < value.Length; j++)
            {
                if (value[j] == ',')
                {
                    cc++;
                }

                if (cc == 5)
                {
                    if (start == 0)
                    {
                        start = j;
                    }
                }

                if (cc == 6)
                {
                    end = j;
                    break;
                }
            }

            ReadOnlySpan<char> span = value.AsSpan(start + 1, end - start - 1);

            if (span.CompareTo(needle.AsSpan(), StringComparison.Ordinal) == 0)
            {
                result = i;
            }

        }

        return result;
    }

    [Benchmark]
    public int FindTokenUsingTokenize()
    {
        string needle = "104";
        int result = -1;

        for (int i = 0; i < _values.Count; i++)
        {
            var tokens = _values[i].Tokenize(',');

            int tokenNumber = 1;

            do
            {
                tokens.MoveNext();
            }
            while (tokenNumber++ != 6);

            if (tokens.Current.CompareTo(needle.AsSpan(), StringComparison.Ordinal) == 0)
            {
                result = i;
            }
        }

        return result;
    }

    [Benchmark]
    public int FindTokenUsingTokenizeWithForEach()
    {
        string needle = "104";
        int result = -1;

        for (int i = 0; i < _values.Count; i++)
        {
            var tokens = _values[i].Tokenize(',');

            int tokenIndex = 0;

            foreach (var token in tokens)
            {
                if (tokenIndex++ == 5)
                {
                    if (token.CompareTo(needle.AsSpan(), StringComparison.Ordinal) == 0)
                    {
                        result = i;
                    }

                    break;
                }
            }
        }

        return result;
    }
}
