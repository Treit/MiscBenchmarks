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
        b.Count = 3;
        b.GlobalSetup();
        var first = b.ReadDataUsingEntityFramework();
        var second = b.ReadDataUsingDataSet();
        var third = b.ReadDataUsingDataReader();
#endif
    }
}
