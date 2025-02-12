namespace Test
{
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
            b.Count = 100_543;
            b.GlobalSetup();
            var first = b.WhereDotCount();
            var second = b.CountWithPredicate();

            Console.WriteLine(first);
            Console.WriteLine(second);
#endif
        }
    }
}
