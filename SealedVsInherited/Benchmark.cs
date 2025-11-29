namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]

public class Benchmark
{
    [Params(10, 1000)]
    public int Count { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
    }

    [Benchmark]
    public long Sealed()
    {
        var c = new TestClassSealed();
        long result = 0;

        for (int i = 0; i < Count; i++)
        {
            result += c.DoWork(Count);
        }

        return result;
    }

    [Benchmark]
    public long NonSealed()
    {
        var c = new TestClassNonSealed();
        long result = 0;

        for (int i = 0; i < Count; i++)
        {
            result += c.DoWork(Count);
        }

        return result;
    }

    [Benchmark]
    public long NonSealedVirtualMethod()
    {
        var c = new TestClassNonSealedVirtualMethod();
        long result = 0;

        for (int i = 0; i < Count; i++)
        {
            result += c.DoWork(Count);
        }

        return result;
    }

    [Benchmark]
    public long OneChild()
    {
        TestClassOneChild c = new Child1();
        long result = 0;

        for (int i = 0; i < Count; i++)
        {
            result += c.DoWork(Count);
        }

        return result;
    }
}
