using System.Text;

namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using System;
using BenchmarkDotNet.Jobs;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    [Params(3, 50, 1000)]
    public int Count { get; set; }

    private static string HexChars = "0123456789ABCDEF";

    private static int[] RandomInts;

    [GlobalSetup]
    public void GlobalSetup()
    {
        RandomInts = new int[Count];

        // Use Count as the seed.
        var r = new Random(Count);

        for (int i = 0; i < Count; i++)
        {
            RandomInts[i] = r.Next(16);
        }
    }

    [Benchmark(Baseline = true)]
    public char[] GetHexCharWithIndexLookup()
    {
        var result = new char[Count];

        for (int i = 0; i < Count; i++)
        {
            int val = RandomInts[i];
            result[i] = DoGetHexChar(val);
        }

        return result;

        char DoGetHexChar(int i)
        {
            return HexChars[i];
        }
    }

    [Benchmark]
    public char[] GetHexCharWithMath()
    {
        var result = new char[Count];

        for (int i = 0; i < Count; i++)
        {
            int val = RandomInts[i];
            result[i] = DoGetHexChar(val);
        }

        return result;

        char DoGetHexChar(int i)
        {
            if (i < 10)
            {
                return (char)(i + 48);
            }

            return (char)(i - 10 + 65);
        }
    }
}
