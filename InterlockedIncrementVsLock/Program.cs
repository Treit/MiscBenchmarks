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
            b.Count = 1000;
            b.GlobalSetup();
            b.IterationSetup();
            var first = b.IncrementUsingInterlocked();
            b.IterationSetup();
            var second = b.IncrementUsingLock();
            Console.WriteLine($"First: {first}, Second: {second}");
#endif
        }
    }
}
