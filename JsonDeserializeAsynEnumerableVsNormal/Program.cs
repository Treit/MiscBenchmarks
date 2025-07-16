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
        b.Count = 10_000;
        b.GlobalSetup();
        var first = b.DeserializeNormal();
        var second = b.DeserializeAsyncEnumerable().Result;
        Console.WriteLine(first);
        Console.WriteLine(second);

#endif

    }
}
