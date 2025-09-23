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
            b.Count = 100; // Use small count for debug
            b.GlobalSetup();

            // Test each benchmark method
            var result1 = b.RoundTripThroughString();
            b.GlobalSetup();
            var result2 = b.DirectFromBytes();
            b.GlobalSetup();

            // Output results for comparison
            Console.WriteLine($"RoundTripThroughString: {result1.Length} items");
            Console.WriteLine($"DirectFromBytes: {result2.Length} items");

            // Verify results are equivalent
            bool allEqual = result1.Length == result2.Length;
            if (allEqual && result1.Length > 0)
            {
                // Compare first item in detail
                var item1 = result1[0];
                var item2 = result2[0];

                allEqual = item1.Id == item2.Id &&
                          item1.Name == item2.Name &&
                          Math.Abs(item1.Value - item2.Value) < 0.0001;
            }

            Console.WriteLine($"Results equivalent: {allEqual}");
#endif
        }
    }
}