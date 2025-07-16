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
        var first = b.GetTokenFromUrlToStringSplitWithLinqAndUnnecessaryNullChecks();
        var second = b.GetTokenFromUrlToStringSplitWithLinq();
        var third = b.GetTokenFromUrlToStringWithIndexOfAndSubstring();
        var fourth = b.GetTokenFromUrlAbsolutePathWithIndexOfAndSubstring();
        Console.WriteLine($"First: {first}, Second: {second}, Third: {third}");
        Console.WriteLine($"Fourth: {fourth}");
#endif
    }
}
