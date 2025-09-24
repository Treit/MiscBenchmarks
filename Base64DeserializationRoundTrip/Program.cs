using BenchmarkDotNet.Running;
using System;

namespace Base64DeserializationRoundTrip
{
    internal class Program
    {
        static void Main(string[] args)
        {
#if RELEASE
            BenchmarkRunner.Run<Benchmarks>();
#else
            // Debug mode: Test benchmark methods and compare results
            var b = new Benchmarks();
            b.ListSize = 10; // Use small list size for debug
            b.GlobalSetup();

            // Test each benchmark method
            var result1 = b.RoundTripThroughString_SmallData();
            b.GlobalSetup();
            var result2 = b.DirectFromBytes_SmallData();
            b.GlobalSetup();
            var result3 = b.DirectFromSpan_SmallData();
            b.GlobalSetup();
            var result4 = b.RoundTripThroughString_LargeData();
            b.GlobalSetup();
            var result5 = b.DirectFromBytes_LargeData();
            b.GlobalSetup();
            var result6 = b.DirectFromSpan_LargeData();

            // Output results for comparison
            Console.WriteLine($"RoundTripThroughString_SmallData: {result1.Items.Count} items");
            Console.WriteLine($"DirectFromBytes_SmallData: {result2.Items.Count} items");
            Console.WriteLine($"DirectFromSpan_SmallData: {result3.Items.Count} items");
            Console.WriteLine($"RoundTripThroughString_LargeData: {result4.Items.Count} items");
            Console.WriteLine($"DirectFromBytes_LargeData: {result5.Items.Count} items");
            Console.WriteLine($"DirectFromSpan_LargeData: {result6.Items.Count} items");

            // Verify results are equivalent
            bool smallDataEqual = result1.Items.Count == result2.Items.Count &&
                                 result2.Items.Count == result3.Items.Count &&
                                 result1.Id == result2.Id && result2.Id == result3.Id;

            bool largeDataEqual = result4.Items.Count == result5.Items.Count &&
                                 result5.Items.Count == result6.Items.Count &&
                                 result4.Id == result5.Id && result5.Id == result6.Id;

            Console.WriteLine($"Small data results equivalent: {smallDataEqual}");
            Console.WriteLine($"Large data results equivalent: {largeDataEqual}");
            Console.WriteLine($"Expected small data size: 10, actual: {result1.Items.Count}");
            Console.WriteLine($"Expected large data size: {b.ListSize}, actual: {result4.Items.Count}");
#endif
        }
    }
}