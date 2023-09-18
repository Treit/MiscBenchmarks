namespace Test
{
    using BenchmarkDotNet.Running;
    using System;

    internal class Program
    {
        static void Main(string[] args)
        {
#if DEBUG
            Benchmark b = new Benchmark();
            b.Count = 100;
            b.GlobalSetup();
            var first = b.IncrementUsingDictionary();
            var second = b.IncrementUsingConcurrentDictionary();

            Console.WriteLine(first);
            Console.WriteLine(second);
#else
            BenchmarkRunner.Run<Benchmark>();
#endif
        }
    }
}
