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
        b.Count = 10;
        b.GlobalSetup();
        b.FisherYates();
        b.Print();
        Console.WriteLine("-------");
        b.FisherYates();
        b.Print();
        Console.WriteLine("-------");
        b.FisherYatesXorSwap();
        b.Print();
#endif

    }
}
