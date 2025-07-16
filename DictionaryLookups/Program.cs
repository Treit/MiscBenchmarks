namespace Test;
using System;
using BenchmarkDotNet.Running;
using Microsoft.Collections.Extensions;

internal class Program
{
    static void Main(string[] args)
    {
#if DEBUG
        Benchmark b = new Benchmark();
        b.Iterations = 100;
        b.GlobalSetup();

        var first = b.LookupUsingDictionary();
        var second = b.LookupUsingImmutableDictionary();
        var third = b.LookupUsingDictionarySlim();
        Console.WriteLine($"First: {first}, Second: {second}");
        Console.WriteLine($"Third: {third}");
#else
        BenchmarkRunner.Run<Benchmark>();
#endif
    }
}
