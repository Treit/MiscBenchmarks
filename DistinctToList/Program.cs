using System;

namespace Test;
using BenchmarkDotNet.Running;

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
        Console.WriteLine(b.ToListThenDistinct());
        Console.WriteLine(b.DistinctThenToList());
        Console.WriteLine(b.DistinctOnly());
#endif

    }
}
