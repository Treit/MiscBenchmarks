namespace Test;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Jobs;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    [Params(100, 999983, 1_000_000)]
    public int Count { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
    }

    [Benchmark]
    public int ToList()
    {
        return GetData().ToList().Count;
    }

    [Benchmark(Baseline = true)]
    public int ToArray()
    {
        return GetData().ToArray().Length;
    }

    public IEnumerable<string> GetData()
    {
        for (int i = 0; i < Count; i++)
        {
            if (i % 10 == 0)
            {
                yield return "";
            }
            else
            {
                yield return i.ToString();
            }
        }
    }
}
