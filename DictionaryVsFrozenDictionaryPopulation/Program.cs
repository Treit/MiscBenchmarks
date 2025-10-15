namespace DictionaryVsFrozenDictionaryPopulation
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
            // Debug mode: Test benchmark methods and compare results
            Benchmark b = new Benchmark();
            b.Count = 1000;
            b.GlobalSetup();

            // Test each benchmark method
            var result1 = b.CreateDictionary();
            b.GlobalSetup();
            var result2 = b.CreateDictionaryWithCapacity();
            b.GlobalSetup();
            var result3 = b.CreateDictionaryFromEnumerable();
            b.GlobalSetup();
            var result4 = b.CreateFrozenDictionary();
            b.GlobalSetup();
            var result5 = b.CreateFrozenDictionaryFromEnumerable();
            b.GlobalSetup();
            var result6 = b.CreateFrozenDictionaryFromDictionary();

            // Output results for comparison
            Console.WriteLine($"CreateDictionary: {result1.Count}");
            Console.WriteLine($"CreateDictionaryWithCapacity: {result2.Count}");
            Console.WriteLine($"CreateDictionaryFromEnumerable: {result3.Count}");
            Console.WriteLine($"CreateFrozenDictionary: {result4.Count}");
            Console.WriteLine($"CreateFrozenDictionaryFromEnumerable: {result5.Count}");
            Console.WriteLine($"CreateFrozenDictionaryFromDictionary: {result6.Count}");

            // Verify results are equivalent (if applicable)
            Console.WriteLine($"All results equal: {result1.Count == result2.Count && result2.Count == result3.Count && result3.Count == result4.Count && result4.Count == result5.Count && result5.Count == result6.Count}");
#endif
        }
    }
}