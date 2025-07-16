namespace Test;
using BenchmarkDotNet.Running;
using System;
using System.Linq;

internal class Program
{
    static void Main(string[] args)
    {
#if RELEASE
        BenchmarkRunner.Run<Benchmark>();
#else
        Benchmark b = new Benchmark();
        b.Count = 26;
        b.GlobalSetup();
        var first = b.SwapWithTuple();
        b.GlobalSetup();
        var second = b.SwapWithLocalFunction();
        b.GlobalSetup();
        var third = b.SwapWithTempVariable();

        Console.WriteLine(first);
        Console.WriteLine(second);
        Console.WriteLine(third);
#endif
    }
}
