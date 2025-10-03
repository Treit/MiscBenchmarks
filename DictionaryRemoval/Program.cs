using BenchmarkDotNet.Running;
using System;

namespace DictionaryRemoval
{
    internal class Program
    {
        static void Main(string[] args)
        {
#if RELEASE
            BenchmarkRunner.Run<Benchmarks>();
#else
            // Debug mode: Test benchmark methods and compare results
            Benchmarks b = new Benchmarks();

            // Test with small count first
            b.Count = 100;
            b.GlobalSetup();

            // Test each benchmark method
            b.IterationSetup();
            var result1 = b.RegularDictionary();
            b.GlobalSetup();
            b.IterationSetup();
            var result2 = b.ConcurrentDictionary();
            b.GlobalSetup();
            var result3 = b.ImmutableDictionaryRemove();
            b.GlobalSetup();
            var result4 = b.ImmutableDictionaryRemoveRange();
            b.GlobalSetup();
            b.IterationSetup();
            var result5 = b.RegularDictionaryWithContainsKey();
            b.GlobalSetup();
            b.IterationSetup();
            var result6 = b.RegularDictionaryBulkRemove();

            // Output results for comparison
            Console.WriteLine($"RegularDictionary: {result1}");
            Console.WriteLine($"ConcurrentDictionary: {result2}");
            Console.WriteLine($"ImmutableDictionaryRemove: {result3}");
            Console.WriteLine($"ImmutableDictionaryRemoveRange: {result4}");
            Console.WriteLine($"RegularDictionaryWithContainsKey: {result5}");
            Console.WriteLine($"RegularDictionaryBulkRemove: {result6}");

            // Verify results are equivalent
            bool allEqual = result1 == result2 && result2 == result3 && result3 == result4 && result4 == result5 && result5 == result6;
            Console.WriteLine($"All results equal: {allEqual}");
#endif
        }
    }
}