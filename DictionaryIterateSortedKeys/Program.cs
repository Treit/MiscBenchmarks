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
        var first = b.IterateSortedKeysWithLINQOrderBy();
        var second = b.IterateSortedKeysWithNewListAndSort();
        Console.WriteLine($"LINQ OrderBy: {first}");
        Console.WriteLine($"New List and Sort: {second}");
#endif

    }
}
