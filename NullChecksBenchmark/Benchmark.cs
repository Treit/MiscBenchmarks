using BenchmarkDotNet.Attributes;
using System.Linq;

namespace NullChecksBenchmark;

[MemoryDiagnoser]
public class Benchmark
{
    private string? part1;
    private string? part2;
    private string? part3;
    private string? part4;
    private string? part5;
    private string? part6;
    private string? part7;
    private string? part8;
    private string? part9;
    private string? part10;    [Params("AllNonNull", "OneNull", "LastNull")]
    public string Scenario { get; set; } = "";

    [Params(1000, 10000)]
    public int Iterations { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        switch (Scenario)
        {
            case "AllNonNull":
                part1 = "value1";
                part2 = "value2";
                part3 = "value3";
                part4 = "value4";
                part5 = "value5";
                part6 = "value6";
                part7 = "value7";
                part8 = "value8";
                part9 = "value9";
                part10 = "value10";
                break;
            case "OneNull":
                part1 = null;
                part2 = "value2";
                part3 = "value3";
                part4 = "value4";
                part5 = "value5";
                part6 = "value6";
                part7 = "value7";
                part8 = "value8";
                part9 = "value9";
                part10 = "value10";
                break;
            case "LastNull":
                part1 = "value1";
                part2 = "value2";
                part3 = "value3";
                part4 = "value4";
                part5 = "value5";
                part6 = "value6";
                part7 = "value7";
                part8 = "value8";
                part9 = "value9";
                part10 = null;
                break;
        }
    }

    [Benchmark(Baseline = true)]
    public bool ExplicitNullChecks()
    {
        bool result = false;
        for (int i = 0; i < Iterations; i++)
        {
            result = part1 == null || part2 == null || part3 == null || part4 == null
                || part5 == null || part6 == null || part7 == null || part8 == null
                || part9 == null || part10 == null;
        }
        return result;
    }

    [Benchmark]
    public bool LinqAnyWithArray()
    {
        bool result = false;
        for (int i = 0; i < Iterations; i++)
        {
            result = new[] { part1, part2, part3, part4, part5, part6, part7, part8, part9, part10 }.Any(p => p == null);
        }
        return result;
    }

    [Benchmark]
    public bool PatternMatchingSwitch()
    {
        bool result = false;
        for (int i = 0; i < Iterations; i++)
        {
            result = (part1, part2, part3, part4, part5, part6, part7, part8, part9, part10) switch
            {
                (null, _, _, _, _, _, _, _, _, _) => true,
                (_, null, _, _, _, _, _, _, _, _) => true,
                (_, _, null, _, _, _, _, _, _, _) => true,
                (_, _, _, null, _, _, _, _, _, _) => true,
                (_, _, _, _, null, _, _, _, _, _) => true,
                (_, _, _, _, _, null, _, _, _, _) => true,
                (_, _, _, _, _, _, null, _, _, _) => true,
                (_, _, _, _, _, _, _, null, _, _) => true,
                (_, _, _, _, _, _, _, _, null, _) => true,
                (_, _, _, _, _, _, _, _, _, null) => true,
                _ => false
            };
        }
        return result;
    }
}

// Edited by AI 🤖
