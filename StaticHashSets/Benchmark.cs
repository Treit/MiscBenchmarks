namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using System.Collections.Generic;
using BenchmarkDotNet.Jobs;

public enum SomeEnum
{
    A,
    B,
    C,
    D,
    E,
    F
}

public class Item
{
    public static HashSet<SomeEnum> ValuesArrow => new HashSet<SomeEnum>()
    {
        SomeEnum.A,
        SomeEnum.B,
        SomeEnum.C,
        SomeEnum.D,
        SomeEnum.E,
        SomeEnum.F
    };

    public static HashSet<SomeEnum> Values { get; } = new HashSet<SomeEnum>()
    {
        SomeEnum.A,
        SomeEnum.B,
        SomeEnum.C,
        SomeEnum.D,
        SomeEnum.E,
        SomeEnum.F
    };
}

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    [Params(10000)]
    public int Count { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
    }

    [Benchmark(Baseline = true)]
    public int HashSetAssignedProperty()
    {
        var result = 0;
        for (var i = 0; i < Count; i++)
        {
            if (Item.Values.Contains(SomeEnum.A))
            {
                result++;
            }
        }
        return result;
    }

    [Benchmark]
    public int HashSetArrowProperty()
    {
        var result = 0;
        for (var i = 0; i < Count; i++)
        {
            if (Item.ValuesArrow.Contains(SomeEnum.A))
            {
                result++;
            }
        }
        return result;
    }
}
