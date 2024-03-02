namespace Test
{
    using BenchmarkDotNet.Running;
    using System;
    using System.Diagnostics;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
#if RELEASE
            BenchmarkRunner.Run<Benchmark>();
#else
            Benchmark b = new Benchmark();
            b.Count = 70;
            b.GlobalSetup();
#endif
        }
    }
}
