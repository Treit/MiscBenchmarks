namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

[MemoryDiagnoser]
public class Benchmark
{
    string _sampleInput = null;

    [GlobalSetup]
    public void GlobalSetup()
    {
        var sb = new StringBuilder();

        // Big string
        for (int i = 0; i < 100_000; i++)
        {
            sb.Append(i);
        }

        sb.Append(" ");

        for (int i = 0; i < 100_000; i++)
        {
            sb.Append(i);
        }

        sb.Append(" ");

        for (int i = 0; i < 100_000; i++)
        {
            sb.Append(i);
        }

        _sampleInput = sb.ToString();
    }

    [Benchmark(Baseline = true)]
    public string ToCharArray()
    {
        var m = Regex.Match(_sampleInput, @"(\d+) (\d+) (\d+)");

        if (!m.Success)
        {
            throw new InvalidOperationException(@"Failed to match unexpectedly");
        }

        var chars = m.Groups[3].Value.ToCharArray();
        for (int i = 0; i < chars.Length; i++)
        {
            chars[i] = (char)(chars[i] + 1);
        }

        return new string(chars);
    }

    [Benchmark]
    public string ValueSpanToArray()
    {
        var m = Regex.Match(_sampleInput, @"(\d+) (\d+) (\d+)");

        if (!m.Success)
        {
            throw new InvalidOperationException(@"Failed to match unexpectedly");
        }

        var chars = m.Groups[3].ValueSpan.ToArray();
        for (int i = 0; i < chars.Length; i++)
        {
            chars[i] = (char)(chars[i] + 1);
        }

        return new string(chars);
    }
}
