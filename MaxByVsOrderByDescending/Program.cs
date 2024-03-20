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
        b.Count = 10000;
        b.GlobalSetup();
        var first = b.OrderByDescendingFirst();
        var second = b.MaxBy();
        Console.WriteLine(first);
        Console.WriteLine(second);

#endif
    }
}