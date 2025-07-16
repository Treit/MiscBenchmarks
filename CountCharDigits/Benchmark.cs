namespace Test;
using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Benchmark
{
    private static readonly string s_alphabet = "abcdefghijklmnopqrstuvwxyz0123456789";
    private Random _random;
    private string _text;
    private static HashSet<char> _digitSet = new HashSet<char>
    {
        '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'
    };

    [Params(1_000_000)]
    public int Count { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        _random = new Random(Count);
        var sb = new StringBuilder(Count);

        for (int i = 0; i < Count; i++)
        {
            sb.Append(s_alphabet[_random.Next(s_alphabet.Length)]);
        }

        _text = sb.ToString();
    }

    [Benchmark(Baseline = true)]
    public int CountDigitsUsingIsDigit()
    {
        var count = 0;

        foreach (var c in _text)
        {
            if (char.IsDigit(c))
            {
                count++;
            }
        }

        return count;
    }

    [Benchmark]
    public int CountDigitsUsingSubtraction()
    {
        var count = 0;

        foreach (var c in _text)
        {
            if (c - '0' >= 0 && c - '0' <= 9)
            {
                count++;
            }
        }

        return count;
    }

    [Benchmark]
    public int CountDigitsUsingHashSet()
    {
        var count = 0;

        foreach (var c in _text)
        {
            if (_digitSet.Contains(c))
            {
                count++;
            }
        }

        return count;
    }

}
