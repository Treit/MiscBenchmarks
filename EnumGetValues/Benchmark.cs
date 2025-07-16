namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using System;
using System.Collections.Generic;

public enum MyEnum
{
    First,
    Second,
    Third,
    Fourth,
    Fifth,
    Sixth,
    Seventh,
    Eighth,
    Ninth,
    Tenth,

}

[MemoryDiagnoser]
public class Benchmark
{
    [GlobalSetup]
    public void GlobalSetup()
    {
    }

    [Benchmark]
    public int EnumGetValuesTypeof()
    {
        return Enum.GetValues(typeof(MyEnum)).Length;
    }

    [Benchmark(Baseline = true)]
    public long EnumGetValuesGeneric()
    {
        return Enum.GetValues<MyEnum>().Length;
    }
}
