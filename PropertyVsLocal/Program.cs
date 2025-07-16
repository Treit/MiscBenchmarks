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
        b.Count = 10000;
        var x = b.PropertyAccess();
        var y = b.LocalVariableAccess();
        Console.WriteLine(x == y);
#endif
    }
}
