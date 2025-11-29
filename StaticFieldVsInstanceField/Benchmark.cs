namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Jobs;

internal class SomeClass
{
    public static string StaticField;
    public string InstanceField;
}

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    private SomeClass _someClass;

    [Params(1, 100)]
    public int Count { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        _someClass = new SomeClass();
        _someClass.InstanceField = "Some test string";
        SomeClass.StaticField = "Some test string";
    }

    [Benchmark]
    public long ReadInstanceField()
    {
        var result = 0L;

        for (int i = 0; i < Count; i++)
        {
            result += _someClass.InstanceField.Length;
        }

        return result;
    }

    [Benchmark]
    public long ReadStaticField()
    {
        var result = 0L;

        for (int i = 0; i < Count; i++)
        {
            result += SomeClass.StaticField.Length;
        }

        return result;
    }

    [Benchmark]
    public long WriteInstanceField()
    {
        var result = 0L;

        for (int i = 0; i < Count; i++)
        {
            _someClass.InstanceField = i.ToString();
            result += SomeClass.StaticField.Length;
        }

        return result;
    }

    [Benchmark]
    public long WriteStaticField()
    {
        var result = 0L;

        for (int i = 0; i < Count; i++)
        {
            SomeClass.StaticField = i.ToString();
            result += SomeClass.StaticField.Length;
        }

        return result;
    }
}
