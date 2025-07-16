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
        var first = b.AddToListWithForEachLoop();
        var second  = b.AddToListPresetCapacity();
        var third = b.AddToListWithToListDotForEach();
        Console.WriteLine(first);
        Console.WriteLine(second);
        Console.WriteLine(third);
#endif

    }
}
