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
            b.GlobalSetup();
            var result10 = b.EnumerateHashSet();
            b.GlobalSetup();
            var result11 = b.EnumerateSortedSet();
            b.GlobalSetup();
            var result12 = b.EnumerateImmutableHashSet();
            b.GlobalSetup();
            var result13 = b.EnumerateImmutableSortedSet();
            b.GlobalSetup();
            var result14 = b.EnumerateHashtable();
            b.GlobalSetup();
            var result15 = b.EnumerateArrayList();
            b.GlobalSetup();
            var result16 = b.EnumerateQueue();
            b.GlobalSetup();
            var result17 = b.EnumerateStack();
            b.GlobalSetup();
            var result18 = b.EnumerateGenericQueue();
            b.GlobalSetup();
            var result19 = b.EnumerateGenericStack();

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
            Console.WriteLine($"EnumerateHashSet: {result10}");
            Console.WriteLine($"EnumerateSortedSet: {result11}");
            Console.WriteLine($"EnumerateImmutableHashSet: {result12}");
            Console.WriteLine($"EnumerateImmutableSortedSet: {result13}");
            Console.WriteLine($"EnumerateHashtable: {result14}");
            Console.WriteLine($"EnumerateArrayList: {result15}");
            Console.WriteLine($"EnumerateQueue: {result16}");
            Console.WriteLine($"EnumerateStack: {result17}");
            Console.WriteLine($"EnumerateGenericQueue: {result18}");
            Console.WriteLine($"EnumerateGenericStack: {result19}");

            // Verify results are equivalent
            Console.WriteLine($"All results equal: {result1 == result2 && result2 == result3 && result3 == result4 && result4 == result5 && result5 == result6 && result6 == result7 && result7 == result8 && result8 == result9 && result9 == result10 && result10 == result11 && result11 == result12 && result12 == result13 && result13 == result14 && result14 == result15 && result15 == result16 && result16 == result17 && result17 == result18 && result18 == result19}");
#endif
        }
    }
}