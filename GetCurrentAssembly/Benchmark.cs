namespace Test;
using BenchmarkDotNet.Attributes;
using System.Reflection;
using BenchmarkDotNet.Jobs;

[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]

public class Benchmark
{
    [GlobalSetup]
    public void GlobalSetup()
    {
    }

    [Benchmark(Baseline = true)]
    public Assembly GetExecutingAssembly()
    {
        return Assembly.GetExecutingAssembly();
    }

    [Benchmark]
    public Assembly TypeofDotAssembly()
    {
        return typeof(Benchmark).Assembly;
    }
}
