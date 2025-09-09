namespace StringToEnumConversion
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
            var result1 = b.ToLowerApproach();
            b.GlobalSetup();
            var result2 = b.SpanApproach(); // Using safe version for debug
            b.GlobalSetup();
            var result3 = b.SpanApproachWithSwitch();
            b.GlobalSetup();
            var result4 = b.TryParseApproach();
            b.GlobalSetup();
            var result5 = b.TryParseSpanApproach();

            // Output results for comparison
            Console.WriteLine($"ToLowerApproach: {result1}");
            Console.WriteLine($"SpanApproach: {result2}");
            Console.WriteLine($"SpanApproachWithSwitch: {result3}");
            Console.WriteLine($"TryParseApproach: {result4}");
            Console.WriteLine($"TryParseSpanApproach: {result5}");

            // Verify results are equivalent
            Console.WriteLine($"Results equal: {result1 == result2 && result2 == result3 && result3 == result4 && result4 == result5}");
#endif
        }
    }
}
