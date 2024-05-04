namespace Test
{
    using System;
    using System.Linq;
    using BenchmarkDotNet.Running;

    internal class Program
    {
        static void Main(string[] args)
        {
#if RELEASE
            BenchmarkRunner.Run<Benchmark>();
#else
            Benchmark b = new Benchmark();
            b.ListSize = 1000;
            b.GlobalSetup();
            var first = b.LinqTake();
            var second = b.RangeWithMathDotMin();
            var third = b.HandWrittenLoop();

            var same = first.SequenceEqual(second) && second.SequenceEqual(third);
            Console.WriteLine(same);
#endif

        }
    }
}
