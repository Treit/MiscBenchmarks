namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Jobs;

public enum EnumUsingByte : byte
{
    A,
    B,
    C,
    D,
    E,
    F,
    G
}

public enum EnumUsingInt : int
{
    A,
    B,
    C,
    D,
    E,
    F,
    G
}

public enum EnumUsingLong : long
{
    A,
    B,
    C,
    D,
    E,
    F,
    G
}

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    [Params(10_000)]
    public int Count { get; set; }

    List<EnumUsingByte> _valuesA = new();
    List<EnumUsingInt> _valuesB = new();
    List<EnumUsingLong> _valuesC = new();

    [GlobalSetup]
    public void GlobalSetup()
    {
    }

    [Benchmark(Baseline = true)]
    public int EnumsUsingInt32()
    {
        var r = new Random(Count);

        _valuesB = new List<EnumUsingInt>();
        int count = 0;

        for (int i = 0; i < Count; i++)
        {
            _valuesB.Add((EnumUsingInt)r.Next(10));
        }

        foreach (var x in _valuesB)
        {
            if (x == EnumUsingInt.A || x == EnumUsingInt.G)
            {
                count++;
            }
        }

        return count;
    }

    [Benchmark]
    public int EnumsUsingInt64()
    {
        var r = new Random(Count);

        _valuesC = new List<EnumUsingLong>();
        int count = 0;

        for (int i = 0; i < Count; i++)
        {
            _valuesC.Add((EnumUsingLong)r.Next(10));
        }

        foreach (var x in _valuesC)
        {
            if (x == EnumUsingLong.A || x == EnumUsingLong.G)
            {
                count++;
            }
        }

        return count;
    }

    [Benchmark]
    public int EnumsUsingByte()
    {
        var r = new Random(Count);

        _valuesA = new List<EnumUsingByte>();
        int count = 0;

        for (int i = 0; i < Count; i++)
        {
            _valuesA.Add((EnumUsingByte)r.Next(10));
        }

        foreach (var x in _valuesA)
        {
            if (x == EnumUsingByte.A || x == EnumUsingByte.G)
            {
                count++;
            }
        }

        return count;
    }
}
