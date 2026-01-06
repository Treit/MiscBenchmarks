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
        b.Count = 1000;
        b.ItemsPerList = 100;
        b.GlobalSetup();

        var result1 = b.CheckListEmptyUsingCount();
        var result2 = b.CheckListEmptyUsingAny();

        Console.WriteLine($"CheckListEmptyUsingCount: {result1}");
        Console.WriteLine($"CheckListEmptyUsingAny: {result2}");
        Console.WriteLine($"Results equal: {result1 == result2}");
#endif
    }
}