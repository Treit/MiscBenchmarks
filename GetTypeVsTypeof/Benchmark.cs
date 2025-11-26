namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using BenchmarkDotNet.Jobs;

static class Extensions
{
    public static Type GetType2<T>(this T t) => typeof(T);
}

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    [Params(10_000)]
    public int Count { get; set; }

    List<object> _values = new();

    [GlobalSetup]
    public void GlobalSetup()
    {
        for (int i = 0; i < Count; i++)
        {
            _values.Add(i.ToString());
        }
    }

    [Benchmark(Baseline = true)]
    public Type UsingSwitchAndTypeOf()
    {
        Type t = null;

        foreach (object o in _values)
        {
            t = DoSwitchAndTypeof(o);
        }

        return t;
    }

    [Benchmark]
    public Type UsingTypeOfExtensionMethod()
    {
        Type t = null;

        foreach (object o in _values)
        {
            t = o.GetType2();
        }

        return t;
    }

    [Benchmark]
    public Type UsingGetType()
    {
        Type t = null;

        foreach (object o in _values)
        {
            t = DoGetType(o);
        }

        return t;
    }

    public Type DoSwitchAndTypeof(object o)
    {
        return o switch
        {
            string => typeof(string),
            long => typeof(long),
            int => typeof(int),
            short => typeof(short),
            double => typeof(double),
            _ => o.GetType()
        };
    }

    public Type DoGetType(object o)
    {
        return o.GetType();
    }
}
