namespace Test;
using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using Microsoft.VisualBasic;
using BenchmarkDotNet.Jobs;

public static class Constants
{
    public const string ValueA = "ValueA";
    public const string ValueB = "ValueB";
    public const string ValueC = "ValueC";
    public const string ValueD = "ValueD";
    public const string ValueE = "ValueE";
}

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    [Params("FirstValue", "LastValue", "ValueNotInSet")]
    public string Value { get; set; }

    private string valueToCheck;

    private static readonly Dictionary<string, string> Map = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
    {
        {Constants.ValueA, Constants.ValueA},
        {Constants.ValueB , Constants.ValueB},
        {Constants.ValueC , Constants.ValueC},
        {Constants.ValueD , Constants.ValueD},
        {Constants.ValueE , Constants.ValueE}
    };

    private static readonly HashSet<string> Set = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
    {
        Constants.ValueA,
        Constants.ValueB,
        Constants.ValueC,
        Constants.ValueD
    };

    private static readonly List<string> List = new List<string>
    {
        Constants.ValueA,
        Constants.ValueB,
        Constants.ValueC,
        Constants.ValueD,
        Constants.ValueE
    };

    [GlobalSetup]
    public void GlobalSetup()
    {
        valueToCheck = Value switch
        {
            "firstvalue" => Constants.ValueA,
            "lastvalue" => Constants.ValueE,
            _ => "gibberish",
        };
    }

    [Benchmark]
    public string CheckWithHashSet()
    {
        return Set.Contains(valueToCheck) ? valueToCheck : Constants.ValueC;
    }

    [Benchmark]
    public string CheckWithListSearch()
    {
        return List.Contains(valueToCheck) ? valueToCheck : Constants.ValueC;
    }

    [Benchmark]
    public string CheckWithNewDictionaryEveryTime()
    {
        var map = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            {Constants.ValueA, Constants.ValueA},
            {Constants.ValueB , Constants.ValueB},
            {Constants.ValueC , Constants.ValueC},
            {Constants.ValueD , Constants.ValueD},
            {Constants.ValueE , Constants.ValueE}
        };

        if (map.TryGetValue(valueToCheck, out var result))
        {
            return result;
        }

        return Constants.ValueC;
    }

    [Benchmark]
    public string CheckWithDictionary()
    {
        if (Map.TryGetValue(valueToCheck, out var result))
        {
            return result;
        }

        return Constants.ValueC;
    }

    [Benchmark]
    public string CheckWithSimpleIf()
    {
        if (valueToCheck.Equals(Constants.ValueA, StringComparison.OrdinalIgnoreCase))
        {
            return Constants.ValueA;
        }
        else if (valueToCheck.Equals(Constants.ValueB, StringComparison.OrdinalIgnoreCase))
        {
            return Constants.ValueB;
        }
        else if (valueToCheck.Equals(Constants.ValueD, StringComparison.OrdinalIgnoreCase))
        {
            return Constants.ValueD;
        }
        else if (valueToCheck.Equals(Constants.ValueE, StringComparison.OrdinalIgnoreCase))
        {
            return Constants.ValueE;
        }

        return Constants.ValueC;
    }

    [Benchmark]
    public string CheckWithSwitchStatement()
    {
        switch (valueToCheck.ToLowerInvariant())
        {
            case "valuea":
                return Constants.ValueA;
            case "valueb":
                return Constants.ValueB;
            case "valued":
                return Constants.ValueD;
            case "valuee":
                return Constants.ValueE;
            default:
                return Constants.ValueC;
        }
    }

    [Benchmark(Baseline = true)]
    public string CheckWithSwitchExpression()
    {
        return valueToCheck.ToLowerInvariant() switch
        {
            "valuea" => Constants.ValueA,
            "valueb" => Constants.ValueB,
            "valued" => Constants.ValueD,
            "valuee" => Constants.ValueE,
            _ => Constants.ValueC,
        };
    }
}
