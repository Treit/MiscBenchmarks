namespace ListExistsVsLinqAny
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
            b.Count = 100;
            b.GlobalSetup();

            // Test each benchmark method
            var result1 = b.ListExists_Found();
            var result2 = b.LinqAny_Found();
            var result3 = b.ListExists_NotFound();
            var result4 = b.LinqAny_NotFound();

            // Output results for comparison
            Console.WriteLine($"ListExists_Found: {result1}");
            Console.WriteLine($"LinqAny_Found: {result2}");
            Console.WriteLine($"ListExists_NotFound: {result3}");
            Console.WriteLine($"LinqAny_NotFound: {result4}");

            // Verify results are equivalent
            Console.WriteLine($"Found results equal: {result1 == result2}");
            Console.WriteLine($"NotFound results equal: {result3 == result4}");
#endif
        }
    }
}
