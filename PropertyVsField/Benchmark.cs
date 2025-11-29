namespace Test;
using BenchmarkDotNet.Attributes;
using System;
using System.Runtime.CompilerServices;
using BenchmarkDotNet.Jobs;

[DisassemblyDiagnoser]
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    public int Count;

    TestClass _instance;

    [GlobalSetup]
    public void GlobalSetup()
    {
        Count = 1000;

        _instance = new TestClass
        {
            _string = Guid.NewGuid().ToString(),
            _time = DateTime.UtcNow
        };
    }

    [Benchmark]
    public (DateTime, string) GetProperty()
    {
        (DateTime, string) result = default;

        for (int i = 0; i < Count; i++)
        {
            result = DoGetProperty();
        }

        return result;
    }

    [Benchmark]
    public (DateTime, string) GetPropertyAggressiveInlining()
    {
        (DateTime, string) result = default;

        for (int i = 0; i < Count; i++)
        {
            result = DoGetPropertyAggressiveInlining();
        }

        return result;
    }

    [Benchmark]
    public (DateTime, string) GetField()
    {
        (DateTime, string) result = default;

        for (int i = 0; i < Count; i++)
        {
            result = DoGetField();
        }

        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public (DateTime, string) DoGetPropertyAggressiveInlining()
    {
        return (_instance.Time, _instance.String);
    }

    public (DateTime, string) DoGetProperty()
    {
        return (_instance.Time, _instance.String);
    }

    public (DateTime, string) DoGetField()
    {
        return (_instance._time, _instance._string);
    }
}

class TestClass
{
    public DateTime _time;

    public string _string;

    public DateTime Time
    {
        get { return _time; }
        set { _time = value; }
    }

    public string String
    {
        get { return _string; }
        set { _string = value; }
    }
}
