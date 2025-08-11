﻿namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using CommunityToolkit.HighPerformance;
using System;
using System.Text.RegularExpressions;

[MemoryDiagnoser]
public class Benchmark
{
    private static string[] _delimitedStrings;
    private static Regex _regex;

    [Params(100)]
    public int Count { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        _delimitedStrings = new string[Count];
        for (int i = 0; i < Count; i++)
        {
            _delimitedStrings[i] = $"SomeValue{i},SomeOtherValue{i}";
        }

        _regex = new Regex("^(.+?),(.+)$", RegexOptions.Compiled);
    }

    [Benchmark]
    public (string, string) TokenizeWithStringSplit()
    {
        var result = ("", "");

        for (var i = 0; i < Count; i++)
        {
            var tokens = _delimitedStrings[i].Split(',');
            result = (tokens[0], tokens[1]);
        }

        return result;
    }

    [Benchmark(Baseline = true)]
    public (string, string) TokenizeWithSubstring()
    {
        var result = ("", "");

        for (var i = 0; i < Count; i++)
        {
            var index = _delimitedStrings[i].IndexOf(',');
            var strA = _delimitedStrings[i].Substring(0, index);
            var strB = _delimitedStrings[i].Substring(index + 1);
            result = (strA, strB);
        }

        return result;
    }

    [Benchmark]
    public (string, string) TokenizeWithRangeOperator()
    {
        var result = ("", "");

        for (var i = 0; i < Count; i++)
        {
            var index = _delimitedStrings[i].IndexOf(',');
            var strA = _delimitedStrings[i][..index];
            var strB = _delimitedStrings[i][(index + 1)..];
            result = (strA, strB);
        }

        return result;
    }

    [Benchmark]
    public (string, string) TokenizeWithRegexMatchDotResult()
    {
        var result = ("", "");

        for (var i = 0; i < Count; i++)
        {
            var m = _regex.Match(_delimitedStrings[i]);
            var strA = m.Result("$1");
            var strB = m.Result("$2");
            result = (strA, strB);
        }

        return result;
    }

    [Benchmark]
    public (string, string) TokenizeWithRegexGroupsDotValue()
    {
        var result = ("", "");

        for (var i = 0; i < Count; i++)
        {
            var m = _regex.Match(_delimitedStrings[i]);
            var strA = m.Groups[1].Value;
            var strB = m.Groups[2].Value;
            result = (strA, strB);
        }

        return result;
    }

    [Benchmark]
    public (string, string) TokenizeWithCommunityToolkitTokenize()
    {
        var result = ("", "");

        for (var i = 0; i < Count; i++)
        {
            string strA = "";
            string strB = "";
            int tokenIndex = 0;

            foreach (var token in _delimitedStrings[i].Tokenize(','))
            {
                if (tokenIndex == 0)
                {
                    strA = token.ToString();
                }
                else if (tokenIndex == 1)
                {
                    strB = token.ToString();
                    break; // We only need the first two tokens
                }

                tokenIndex++;
            }

            result = (strA, strB);
        }

        return result;
    }

    [Benchmark]
    public (string, string) TokenizeWithSpanSlicing()
    {
        var result = ("", "");

        for (var i = 0; i < Count; i++)
        {
            var span = _delimitedStrings[i].AsSpan();
            int start = 0;
            string strA = "";
            string strB = "";

            for (int j = 0; j < span.Length; j++)
            {
                if (span[j] == ',')
                {
                    strA = span.Slice(start, j - start).ToString();
                    start = j + 1;
                    break;
                }
            }

            // Get the remaining part as the second token
            strB = span.Slice(start).ToString();

            result = (strA, strB);
        }

        return result;
    }
}
