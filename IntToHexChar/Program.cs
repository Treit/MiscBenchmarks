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
        var resultA = b.GetHexCharWithMath();
        var resultB = b.GetHexCharWithIndexLookup();

        foreach (var c in resultA)
        {
            Console.WriteLine(c);
        }

        Console.WriteLine("----");

        foreach (var c in resultB)
        {
            Console.WriteLine(c);
        }

#endif
    }
}
