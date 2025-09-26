namespace KeyValuePairIteration
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
            b.GlobalSetup();

            // Test each benchmark method
            var result1 = b.EnumerateDictionary();
            b.GlobalSetup();
            var result2 = b.EnumerateSortedDictionary();
            b.GlobalSetup();
            var result3 = b.EnumerateReadOnlyDictionary();
            b.GlobalSetup();
            var result4 = b.EnumerateFrozenDictionary();
            b.GlobalSetup();
            var result5 = b.EnumerateList();
            b.GlobalSetup();
            var result6 = b.EnumerateSortedList();
            b.GlobalSetup();
            var result7 = b.EnumerateImmutableDictionary();
            b.GlobalSetup();
            var result8 = b.EnumerateImmutableSortedDictionary();
            b.GlobalSetup();
            var result9 = b.EnumerateArray();

            // Output results for comparison
            Console.WriteLine($"EnumerateDictionary: {result1}");
            Console.WriteLine($"EnumerateSortedDictionary: {result2}");
            Console.WriteLine($"EnumerateReadOnlyDictionary: {result3}");
            Console.WriteLine($"EnumerateFrozenDictionary: {result4}");
            Console.WriteLine($"EnumerateList: {result5}");
            Console.WriteLine($"EnumerateSortedList: {result6}");
            Console.WriteLine($"EnumerateImmutableDictionary: {result7}");
            Console.WriteLine($"EnumerateImmutableSortedDictionary: {result8}");
            Console.WriteLine($"EnumerateArray: {result9}");

            // Verify results are equivalent
            Console.WriteLine($"All results equal: {result1 == result2 && result2 == result3 && result3 == result4 && result4 == result5 && result5 == result6 && result6 == result7 && result7 == result8 && result8 == result9}");
#endif
        }
    }
}