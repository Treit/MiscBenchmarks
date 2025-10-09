namespace NumericStringComparison
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
            var result1 = b.EqualityOperator();
            b.GlobalSetup();
            var result2 = b.StringEqualsOrdinal();
            b.GlobalSetup();
            var result3 = b.StringEqualsOrdinalIgnoreCase();
            b.GlobalSetup();
            var result4 = b.StringInstanceEquals();
            b.GlobalSetup();
            var result5 = b.StringInstanceEqualsOrdinal();

            // Output results for comparison
            Console.WriteLine($"EqualityOperator: {result1}");
            Console.WriteLine($"StringEqualsOrdinal: {result2}");
            Console.WriteLine($"StringEqualsOrdinalIgnoreCase: {result3}");
            Console.WriteLine($"StringInstanceEquals: {result4}");
            Console.WriteLine($"StringInstanceEqualsOrdinal: {result5}");

            // Verify results are equivalent (if applicable)
            Console.WriteLine($"Results equal: {result1 == result2 && result2 == result3 && result3 == result4 && result4 == result5}");
#endif
        }
    }
}