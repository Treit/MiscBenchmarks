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
        b.Count = 1000;
        b.GlobalSetup();
        var first = b.CheckWithSimpleIf();
        var second = b.CheckWithArray();
        Console.WriteLine($"First: {first}, Second: {second}");
#endif
    }
}
