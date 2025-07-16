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
        b.Count = 1024;
        b.GlobalSetup();
        var first = b.LookupElementWithList();
        var second = b.LookupElementWithIList();
        Console.WriteLine(first);
        Console.WriteLine(second);
#endif

    }
}
