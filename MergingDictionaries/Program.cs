namespace Test
{
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
            Benchmark b = new Benchmark();
            b.Count = 10;
            b.ItemsPerDictionary= 5;
            b.GlobalSetup();
            var merged = b.GroupBy();
            var merged2 = b.ForLoop();
            Debugger.Break();
#endif
        }
    }
}
