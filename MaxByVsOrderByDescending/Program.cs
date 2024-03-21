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
        var b = new Benchmark()
        {
            Count = 10000
        };
        b.GlobalSetup();
        var first = b.OrderByDescendingFirst();
        var second = b.MaxBy();
        var third = b.OrderByDescendingFirstWithUnnecessaryToList();
        var fourth = b.SuperLinqPartialSortByDescendingFirst();
        Console.WriteLine(first);
        Console.WriteLine(second);
        Console.WriteLine(third);
        Console.WriteLine(fourth);

#endif
    }
}