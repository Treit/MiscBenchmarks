using System;

namespace Test
{
    using BenchmarkDotNet.Running;

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
            Console.WriteLine(b.IterateListAfterCallingDistinct());
            Console.WriteLine(b.IterateListSkippingDuplicates());
#endif

        }
    }
}
