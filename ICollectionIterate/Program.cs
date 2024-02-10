namespace Test
{
    using BenchmarkDotNet.Running;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
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
#endif
        }
    }
}
