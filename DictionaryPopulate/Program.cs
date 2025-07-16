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
        Benchmark b = new Benchmark();
        b.Count = 5000;
        b.GlobalSetup();
        var first = b.PopulateOriginalWithThreeChecksAndTryAdd();
        var second = b.PopulateWithInitializeToZeroAndThenUpdate();
        var third = b.PopulateWithThreeChecksAndAdd();
        Console.WriteLine($"First: {first}, Second: {second}, Third: {third}");
#endif

    }
}
