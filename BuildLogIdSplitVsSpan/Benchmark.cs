namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using System;
using System.Linq;
using BenchmarkDotNet.Jobs;

public record TestData(int Value);

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    string _pathSplitString = @"\s\";
    string _samplePath = @"C:\Users\user\source\repos\s\Benchmark\Benchmark.cs";

    [GlobalSetup]
    public void GlobalSetup()
    {
    }

    [Benchmark(Baseline = true)]
    public string GetLogIdWithIndexOfAndSpan()
    {
        var fileName = _samplePath;
        var fileLine = 99;

        if (fileName is null)
        {
            return $"Unknown:{fileLine}";
        }

        var loc = fileName.IndexOf(_pathSplitString, StringComparison.Ordinal);
        loc = loc == -1 ? 0 : loc + _pathSplitString.Length;
        var span = fileName.AsSpan(loc);

        return $"{span}:{fileLine}";
    }

    [Benchmark]
    public string GetLogIdWithIndexOfAndSubstringChatGPT()
    {
        var fileName = _samplePath;
        var fileLine = 99;

        if (fileName is null)
        {
            return $"Unknown:{fileLine}";
        }

        // Find index and handle cases where it's not found
        var loc = fileName.IndexOf(_pathSplitString, StringComparison.Ordinal);
        loc = loc >= 0 ? loc + _pathSplitString.Length : 0;

        // Directly format without using span.ToString()
        return $"{fileName.Substring(loc)}:{fileLine}";
    }

    [Benchmark]
    public string GetLogIdWithSplit()
    {
        var fileName = _samplePath;
        var fileLine = 99;

        if (fileName is null)
        {
            return $"Unknown:{fileLine}";
        }

        fileName = fileName.Split(_pathSplitString, StringSplitOptions.RemoveEmptyEntries).LastOrDefault();
        return $"{fileName}:{fileLine}";
    }

    [Benchmark]
    public string GetLogIdWithCustomSpanSplit()
    {
        var fileName = _samplePath;
        var fileLine = 99;

        if (fileName is null)
        {
            return $"Unknown:{fileLine}";
        }

        var (_, span) = fileName.AsSpan().SplitFirst(_pathSplitString);
        return $"{span}:{fileLine}";
    }
}
