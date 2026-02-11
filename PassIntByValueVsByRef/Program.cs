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
        var b = new Benchmark();
        b.Count = 1000;
        b.GlobalSetup();

        var result1 = b.PassByValue();
        var result2 = b.PassByRef();
        var result3 = b.PassByIn();

        Console.WriteLine($"PassByValue: {result1}");
        Console.WriteLine($"PassByRef:   {result2}");
        Console.WriteLine($"PassByIn:    {result3}");
        Console.WriteLine($"Results equal: {result1 == result2 && result2 == result3}");
#endif
    }
}
