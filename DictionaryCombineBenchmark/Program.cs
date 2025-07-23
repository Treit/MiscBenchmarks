namespace DictionaryCombineBenchmark
{
    using BenchmarkDotNet.Running;
    using System;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
#if RELEASE
            BenchmarkRunner.Run<Benchmark>();
#else
            // Debug mode: Test benchmark methods and compare results
            Benchmark b = new Benchmark();
            b.FeatureCount = 10;
            b.ScoreFeatureCount = 10;
            b.GlobalSetup();

            // Test each benchmark method
            var result1 = b.OriginalLinqApproach();
            b.GlobalSetup();
            var result2 = b.OriginalLinqWithPresize();
            b.GlobalSetup();
            var result3 = b.ImperativeLoop();
            b.GlobalSetup();
            var result4 = b.ImperativeLoopWithPresize();
            b.GlobalSetup();
            var result5 = b.ImperativeLoopWithTryAdd();
            b.GlobalSetup();
            var result6 = b.ImperativeLoopWithTryAddPresize();
            b.GlobalSetup();
            var result7 = b.LinqUnionApproach();
            b.GlobalSetup();
            var result8 = b.LinqUnionApproachWithPresize();

            // Output results for comparison
            Console.WriteLine($"OriginalLinqApproach: {result1.Count} items");
            Console.WriteLine($"OriginalLinqWithPresize: {result2.Count} items");
            Console.WriteLine($"ImperativeLoop: {result3.Count} items");
            Console.WriteLine($"ImperativeLoopWithPresize: {result4.Count} items");
            Console.WriteLine($"ImperativeLoopWithTryAdd: {result5.Count} items");
            Console.WriteLine($"ImperativeLoopWithTryAddPresize: {result6.Count} items");
            Console.WriteLine($"LinqUnionApproach: {result7.Count} items");
            Console.WriteLine($"LinqUnionApproachWithPresize: {result8.Count} items");

            // Verify results contain the same keys (order might differ)
            var keys1 = result1.Keys.OrderBy(x => x).ToArray();
            var keys2 = result2.Keys.OrderBy(x => x).ToArray();
            var keys3 = result3.Keys.OrderBy(x => x).ToArray();
            var keys7 = result7.Keys.OrderBy(x => x).ToArray();

            Console.WriteLine($"All methods produce equivalent results: {
                keys1.SequenceEqual(keys2) && 
                keys2.SequenceEqual(keys3) && 
                keys3.SequenceEqual(keys7)}");

            // Show some sample keys
            Console.WriteLine($"Sample keys from result1: {string.Join(", ", keys1.Take(5))}");
            Console.WriteLine($"Sample keys from result7: {string.Join(", ", keys7.Take(5))}");
#endif
        }
    }
}
