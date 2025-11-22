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
            var result1 = b.UsingExpressionBodyEmptyList();
            b.GlobalSetup();
            var result2 = b.UsingReadOnlyListField();
            b.GlobalSetup();

            // Output results for comparison
            Console.WriteLine($"Expression body: {result1}");
            Console.WriteLine($"Readonly list field: {result2}");

            // Verify results are equivalent
            Console.WriteLine($"Results equal: {result1 == result2}");
#endif
        }
    }
}