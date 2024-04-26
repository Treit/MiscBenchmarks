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
            b.Count = 10;
            b.GlobalSetup();
            var first = b.DedupeWithLinqDistinct();
            var second = b.DedupeWithRemoveDuplicateFunction();
            Console.WriteLine(first);
            Console.WriteLine(second);
#endif
        }
    }
}
