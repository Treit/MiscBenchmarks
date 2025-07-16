namespace Test;
using BenchmarkDotNet.Running;
using System;
using System.Diagnostics;

internal class Program
{
    static void Main(string[] args)
    {
#if RELEASE
        BenchmarkRunner.Run<Benchmark>();
#else
        try
        {
            Benchmark b = new Benchmark();
            b.Length = 100;
            b.Setup();
            b.Mtreit_C_LinearSearch();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
#endif

    }
}
