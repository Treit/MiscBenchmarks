namespace Test
{
    using System;
    using BenchmarkDotNet.Running;
    using Microsoft.Collections.Extensions;

    internal class Program
    {
        static void Main(string[] args)
        {
#if DEBUG
            Benchmark b = new Benchmark();
            b.Count = 100;
            b.GlobalSetup();

#else
            BenchmarkRunner.Run<Benchmark>();
#endif
        }
    }
}
