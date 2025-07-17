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
        var b = new Benchmark();
        b.Count = 1000;
        b.GlobalSetup();
        var first = b.NewDictionary();
        var second = b.NullCheck();
        Console.WriteLine($"NewDictionary: {first}, NullCheck: {second}");
    
#endif
    }
}
