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
        b.ArrayCount = 100;
        b.GlobalSetup();
        var resultA = b.MergeUsingConcat();
        var resultB = b.MergeUsingUnion();
#endif
    }
}
