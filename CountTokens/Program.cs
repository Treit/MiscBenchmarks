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
            b.Count = 1_000_000;
            b.GlobalSetup();
            var first = b.CountTokensUsingLinqCount();
            var second = b.CountTokensUsingSpanCount();
            var third = b.CountTokensUsingSplitToListAndCount();
            var fourth = b.CountTokensUsingSplitAndLength();
            Console.WriteLine($"First: {first}, Second: {second}, Third: {third}, Fourth: {fourth}");
#endif
        }
    }
}
