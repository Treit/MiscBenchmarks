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
            b.Count = 100_000;
            b.GlobalSetup();
            var countA = b.ForEachUsingDistinct();
            var countB = b.ForEachUsingHashSet();
            var countC = b.ForEachUsingHashSetWithInitialCapacity();

            var identical = countA == countB && countB == countC;

            if (!identical)
            {
                throw new InvalidOperationException("Mismatch");
            }
#endif

        }
    }
}
