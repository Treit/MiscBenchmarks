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

        var x = new TestClassSentinelValues();
        x.Property0 = 0.5;
        x.Property15 = 0.3;
        x.Property99 = 0.1;

        TestClassNullableProperties y = x;

        Console.WriteLine(y.Property99);
        Console.WriteLine(x.Property99);
#endif
    }
}
