namespace Test;
using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using BenchmarkDotNet.Jobs;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    [Params(1000, 100_000)]
    public int Count { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
    }

    [Benchmark(Baseline = true)]
    public List<int> BuildIntListWithoutBoxing()
    {
        var result = new List<int>(Count);

        for (int i = 0; i < Count; i++)
        {
            result.Add(i);
        }

        return result;
    }

    [Benchmark]
    public List<object> BuildIntListWitBoxing()
    {
        var result = new List<object>(Count);

        for (int i = 0; i < Count; i++)
        {
            result.Add(i);
        }

        return result;
    }
}
