using System.Linq;

namespace Test;
using BenchmarkDotNet.Running;
using System;

internal class Program
{
    static void Main(string[] args)
    {
#if DEBUG
        Benchmark b = new Benchmark();
        b.Count = 100;
        b.GlobalSetup();
        var first = b.BuildDictionaryUsingForLoop();
        var second = b.BuildDictionaryUsingToDictionary();
        var third = b.BuildDictionaryUsingZipAndToDictionary();
        Console.WriteLine($"{first.Count} -> {first.All(kvp => kvp.Value is null)}");
        Console.WriteLine($"{second.Count} -> {second.All(kvp => kvp.Value is null)}");
        Console.WriteLine($"{third.Count} -> {third.All(kvp => kvp.Value is null)}");
#else
        BenchmarkRunner.Run<Benchmark>();
#endif
    }
}
