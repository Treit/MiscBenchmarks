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
        b.Count = 500;
        b.MaxDepth = 10;
        b.GlobalSetup();
        var result = b.TraverseRecursive();
        var result2 = b.TraverseWithStack();
        var result3 = b.TraverseWithGetFileSystemEntries();
        var result4 = b.TraverseWithEnumerateFileSystemEntries();
        var result5 = b.TraverseWithEnumerateFileSystemEntriesParallelLinq();
        Console.WriteLine(result);
        Console.WriteLine(result2);
        Console.WriteLine(result3);
        Console.WriteLine(result4);
        Console.WriteLine(result5);
#endif

    }
}
