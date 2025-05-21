namespace Test
{
    using System;
    using BenchmarkDotNet.Running;

    internal class Program
    {        static void Main(string[] args)
        {
#if RELEASE
            BenchmarkRunner.Run<Benchmark>();
#else
            Benchmark b = new Benchmark();
            b.Count = 1000;
            b.GlobalSetup();
            var result = b.PruneRecursiveWithWriter();
            var result2 = b.PruneWithJsonNodeRemove();
            Console.WriteLine($"Pruned JSON length: {result.Length}");
            Console.WriteLine($"Sample of pruned JSON: {result.Substring(0, Math.Min(100, result.Length))}...");

            Console.WriteLine("---- Result 2 ----");
            Console.WriteLine($"Pruned JSON length: {result2.Length}");
            Console.WriteLine($"Sample of pruned JSON: {result2.Substring(0, Math.Min(100, result2.Length))}...");
#endif
        }
    }
}
