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
        b.Count = 10_000;
        b.GlobalSetup();
        var first = b.SumDataBinaryPrimitives();
        var second = b.SumDataBitConverter();
        var third = b.SumDataMemoryMarshalCast();
        var fourth = b.SumDataMemoryMarshalCastAndVectorizedSum();

        Console.WriteLine(first);
        Console.WriteLine(second);
        Console.WriteLine(third);
        Console.WriteLine(fourth);
#endif

    }
}
