namespace ListSpreadVsReadOnly
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
            b.Count = 10;
            b.GlobalSetup();

            // Test each benchmark method
            var result1 = b.ExpressionBodyWithItems();
            b.GlobalSetup();
            var result2 = b.ExpressionBodyEmpty();
            b.GlobalSetup();
            var result3 = b.IReadOnlyListWithItems();
            b.GlobalSetup();
            var result4 = b.IReadOnlyListEmpty();
            b.GlobalSetup();
            var result5 = b.FrozenSetWithItems();
            b.GlobalSetup();
            var result6 = b.FrozenSetEmpty();

            // Output results for comparison
            Console.WriteLine($"Expression body with items: {result1}");
            Console.WriteLine($"Expression body empty: {result2}");
            Console.WriteLine($"IReadOnlyList with items: {result3}");
            Console.WriteLine($"IReadOnlyList empty: {result4}");
            Console.WriteLine($"FrozenSet with items: {result5}");
            Console.WriteLine($"FrozenSet empty: {result6}");

            // Verify with-items results are equivalent (8 items each)
            Console.WriteLine($"With-items results equal: {result1 == result3 && result3 == result5 && result1 == 8 * b.Count}");
            // Verify empty results are equivalent (3 items each)
            Console.WriteLine($"Empty results equal: {result2 == result4 && result4 == result6 && result2 == 3 * b.Count}");
#endif
        }
    }
}