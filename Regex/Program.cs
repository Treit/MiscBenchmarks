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
        int loc1 = b.FindTokenUsingCompiledRegex();
        int loc2 = b.FindTokenUsingRegex();
        int loc3 = b.FindTokenUsingSourceGenRegex();

        if (loc1 != loc2 || loc2 != loc3)
        {
            throw new InvalidOperationException($"Expected to be the same!");
        }
#endif

    }
}
