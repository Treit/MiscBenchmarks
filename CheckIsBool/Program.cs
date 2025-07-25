namespace Test;
using BenchmarkDotNet.Running;
using System;
using System.Linq;

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
        var first = b.CheckWithStringCompare();
        var second = b.CheckWithTryParse();
        var third = b.CheckWithStringCompareAaronSearchValues();
        var fourth = b.CheckWithStringCompareAaronFrozenSet();
        Console.WriteLine($"CheckWithStringCompare: {first}");
        Console.WriteLine($"CheckWithTryParse: {second}");
        Console.WriteLine($"CheckWithStringCompareAaronSearchValues: {third}");
        Console.WriteLine($"CheckWithStringCompareAaronFrozenSet: {fourth}");
#endif
    }
}
