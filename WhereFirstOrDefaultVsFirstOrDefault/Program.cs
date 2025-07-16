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
        b.Count = 100;
        b.GlobalSetup();
        var first = b.WhereThenFirstOrDefault();
        var second = b.FirstOrDefault();
        Console.WriteLine(first);
        Console.WriteLine(second);
#endif
    }
}
