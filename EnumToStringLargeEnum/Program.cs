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
        b.GlobalSetup();
        var first = b.HttpStatusCodeToStringRegularToString();
        var second = b.HttpStatusCodeToStringSwitchExpression();
        var third = b.HttpStatusCodeToStringFrozenDictionaryLookup();
        var fourth = b.HttpStatusCodeToStringSparseArrayLookup();
        Console.WriteLine($"Regular: {first}");
        Console.WriteLine($"Fast: {second}");
        Console.WriteLine($"Cached: {third}");
        Console.WriteLine($"Array: {fourth}");

#endif
    }
}
