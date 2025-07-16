namespace Test;
using BenchmarkDotNet.Running;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
    static void Main(string[] args)
    {
#if RELEASE
        BenchmarkRunner.Run<Benchmark>();
#else
        var b = new Benchmark();
        b.Count = 100;
        b.GlobalSetup();
        var first = b.ToLower();
        var second = b.ToLowerInvariant();
        var third = b.ToUpper();
        var fourth = b.ToUpperInvariant();
        var fifth = b.StringComparisonIgnoreCaseFlag();
        var sixth = b.StringComparisonCurrentCultureIgnoreCase();
        var seventh = b.StringComparisonInvariantCultureIgnoreCase();
        var eighth = b.StringComparisonOrdinalIgnoreCase();

        List<int> results = [first, second, third, fourth, fifth, sixth, seventh, eighth];

        Console.WriteLine(results.All(x => x == results.First()));
#endif
    }
}
