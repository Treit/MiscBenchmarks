namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;

[MemoryDiagnoser]
public class Benchmark
{
    [Params(10_000)]
    public int Count { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
    }
}
