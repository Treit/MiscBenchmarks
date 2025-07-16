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
        b.GlobalSetup();
        var first = b.EnumGetValuesGeneric();
        var second = b.EnumGetValuesTypeof();
        Console.WriteLine(first);
        Console.WriteLine(second);
#endif
    }
}
