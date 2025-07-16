namespace Test;
using BenchmarkDotNet.Running;
using System;
using System.Diagnostics;

internal class Program
{
    static void Main(string[] args)
    {
#if RELEASE
        BenchmarkRunner.Run<Benchmark>();
#else
        Benchmark b = new Benchmark();
        b.ArraySize = 10_000;
        b.GlobalSetup();
#endif
    }
}
