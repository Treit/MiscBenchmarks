using System;
using BenchmarkDotNet.Running;

namespace Test;

internal class Program
{
    private static void Main(string[] args)
    {
#if RELEASE
        BenchmarkRunner.Run<Benchmark>();
#else
        var b = new Benchmark
        {
            Count = 1_024,
        };

        b.GlobalSetup();
        Console.WriteLine(b.AddInt32Values());
        Console.WriteLine(b.AddInt64Values());
#endif
    }
}
