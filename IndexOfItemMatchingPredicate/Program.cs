using BenchmarkDotNet.Running;
using System;

namespace Test;
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
        var first = b.SuperLinqFindIndex();
        var second = b.ToListFindIndex();
        var third = b.SelectAndWhereWithAnonymousType();
        Console.WriteLine($"First: {first}, Second: {second}, Third: {third}");
#endif
    }
}