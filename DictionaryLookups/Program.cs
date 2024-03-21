namespace Test
{
    using System;
    using BenchmarkDotNet.Running;

    internal class Program
    {
        static void Main(string[] args)
        {
#if DEBUG
            Benchmark b = new Benchmark();
            b.Iterations = 100;
            b.ItemCount = 1000;
            b.GlobalSetup();
            var first = b.LookupUsingDictionary();
            var second = b.LookupUsingImmutableDictionary();
            Console.WriteLine($"First: {first}, Second: {second}");
#else
            BenchmarkRunner.Run<Benchmark>();
#endif
        }
    }
}
