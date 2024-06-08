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
            Benchmark benchmark = new Benchmark();
            benchmark.Count = 1000;
            benchmark.GlobalSetup();
            var first = benchmark.DeQuoteWithTrim();
            var second = benchmark.DeQuoteWithSubstring();
            var third = benchmark.DeQuoteWithRangePattern();
            var fourth = benchmark.DeQuoteWithSpan();
            Console.WriteLine($"DeQuoteWithTrim: {first}");
            Console.WriteLine($"DeQuoteWithSubstring: {second}");
            Console.WriteLine($"DeQuoteWithRangePattern: {third}");
            Console.WriteLine($"DeQuoteWithSpan: {fourth}");
#endif

        }
    }
}
