namespace Test;
using BenchmarkDotNet.Running;
using System;

internal class Program
{
    static void Main(string[] args)
    {
#if RELEASE
        BenchmarkRunner.Run<Benchmark>();
#else
        Benchmark benchmark = new Benchmark();
        benchmark.Count = 1000;
        benchmark.GlobalSetup();
        var first = benchmark.DoTrimWithOneCallUsingNewCharArray();
        var second = benchmark.DoTrimWithThreeTrimCallsAndNewCharArray();
        var third = benchmark.DoTrimWithOneCallUsingParamsArray();
        var fourth = benchmark.DoTrimWithOneCallUsingStaticCharArray();
        Console.WriteLine($"first:  >>>{first}<<<");
        Console.WriteLine($"second: >>>{second}<<<");
        Console.WriteLine($"third:  >>>{third}<<<");
        Console.WriteLine($"fourth: >>>{fourth}<<<");
#endif

    }
}
