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
        b.Count = 1000;
        b.GlobalSetup();
        int loc1 = b.FindTokenUsingSpan();
        int loc2 = b.FindTokenUsingTokenize();
        int loc3 = b.FindTokenUsingSplit();
        int loc4 = b.FindTokenUsingTokenizeWithForEach();

        if (loc1 != loc2 || loc2 != loc3 || loc4 != loc1)
        {
            throw new InvalidOperationException($"Expected to be the same!");
        }
#endif

    }
}
