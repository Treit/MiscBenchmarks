namespace Test;
using BenchmarkDotNet.Attributes;
using System;

[MemoryDiagnoser]
public class Benchmark
{
    private (string, string)[] _stringPairs;

    [Params(100)]
    public int Count { get; set; }

    [Params(3, 100)]
    public int StringLength { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        _stringPairs = new (string, string)[Count];
        var random = new Random(Count);

        for (int i = 0; i < Count; i++)
        {
            var strA = RandomStringCreate(random, StringLength);
            var strB = (random.Next() % 2) switch
            {
                0 => strA,
                _ => RandomStringCreate(random, StringLength)
            };

            _stringPairs[i] = (strA, strB);
        }
    }

    [Benchmark(Baseline = true)]
    public int StartsWithOrdinalIgnoreCase()
    {
        var pairs = _stringPairs;
        var result = 0;

        foreach (var (first, second) in pairs)
        {
            if (first.StartsWith(second, StringComparison.OrdinalIgnoreCase))
            {
                result++;
            }
        }

        return result;
    }

    [Benchmark]
    public int EqualsOrdinalIgnoreCase()
    {
        var pairs = _stringPairs;
        var result = 0;

        foreach (var (first, second) in pairs)
        {
            if (first.Equals(second, StringComparison.OrdinalIgnoreCase))
            {
                result++;
            }
        }

        return result;
    }

    [Benchmark]
    public int AsSpanEqualsOrdinalIgnoreCase()
    {
        var pairs = _stringPairs;
        var result = 0;

        foreach (var (first, second) in pairs)
        {
            if (first.AsSpan(0, StringLength).Equals(second, StringComparison.OrdinalIgnoreCase))
            {
                result++;
            }
        }

        return result;
    }

    [Benchmark]
    public int AsSpanStartsWithOrdinalIgnoreCase()
    {
        var pairs = _stringPairs;
        var result = 0;

        foreach (var (first, second) in pairs)
        {
            if (first.AsSpan(0, StringLength).StartsWith(second, StringComparison.OrdinalIgnoreCase))
            {
                result++;
            }
        }

        return result;
    }

    static string RandomStringCreate(Random random, int length)
    {
        const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz-_@!#$%^&*()+{}[]";

        return string.Create(length, random, (buff, str) =>
        {
            for (int i = 0; i < buff.Length; i++)
            {
                buff[i] = alphabet[random.Next(alphabet.Length)];
            }
        });
    }
}
