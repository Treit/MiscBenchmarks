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
        var benchmark = new Benchmark
        {
            Size = 256,
            DiagonalStride = 8
        };

        benchmark.GlobalSetup();

        var multiDimensional = benchmark.SumMultiDimensional();
        var jagged = benchmark.SumJagged();
        var flat = benchmark.SumFlat();
        var compressed = benchmark.SumCompressedDiagonals();

        if (multiDimensional != jagged ||
            multiDimensional != flat ||
            multiDimensional != compressed)
        {
            throw new InvalidOperationException("Benchmark implementations returned different sums.");
        }

        Console.WriteLine(multiDimensional);
        Console.WriteLine(jagged);
        Console.WriteLine(flat);
        Console.WriteLine(compressed);
#endif
    }
}