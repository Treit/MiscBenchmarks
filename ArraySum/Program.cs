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
        b.Size = 1024;
        b.GlobalSetup();
        Console.WriteLine(b.SumMultiDimensional());
        Console.WriteLine(b.SumJagged());
        Console.WriteLine(b.SumMultiDimensionalAkari());
        Console.WriteLine(b.SumMultiDimensionalVectorAkari());
        Console.WriteLine(b.SumHandrolledAkseli());
        Console.WriteLine(b.SumHandrolledAkseliJuly2023());
#endif

    }
}
