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
        b.Count = 3;
        b.GlobalSetup();
        var first = b.SystemRandom();
        var second = b.XorShiftRandom();
        Console.WriteLine(first);
        Console.WriteLine(second);
#endif
    }
}
