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
        b.Count = 100_543;
        b.GlobalSetup();
        var first = b.ForEachLoopCountField();
        var second = b.Lulz1();
        var third = b.Lulz2();
        var fourth = b.Lulz3();

        Console.WriteLine(first);
        Console.WriteLine(second);
        Console.WriteLine(third);
        Console.WriteLine(fourth);
#endif
    }
}
