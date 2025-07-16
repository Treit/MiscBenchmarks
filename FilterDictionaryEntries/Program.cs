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
        benchmark.Count = 20;
        benchmark.GlobalSetup();
        var first = benchmark.FilterUsingConvolutedLinq();
        var second = benchmark.FilterUsingCleanedUpPatternMatching();
        foreach (var item in first)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("-------");

        foreach (var item in second)
        {
            Console.WriteLine(item);
        }
#endif

    }
}
