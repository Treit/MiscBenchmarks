namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using System.Collections.Generic;
using System.Linq;

public record TestData(int Value);

[MemoryDiagnoser]
public class Benchmark
{
    IEnumerable<TestData> _data = [new(1), new(2), new(3)];

    [GlobalSetup]
    public void GlobalSetup()
    {
    }

    [Benchmark(Baseline = true)]
    public TestData[] ToArray()
    {
        return _data.ToArray();
    }

    [Benchmark]
    public TestData[] CollectionExpression()
    {
        return [.. _data];
    }
}
