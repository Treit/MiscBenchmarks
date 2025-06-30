namespace ShuffleRandomVsSecure
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
            b.Count = 100;  // Set a reasonable size for debug testing
            b.MaxItems = -1;  // Test full shuffle first
            b.GlobalSetup();

            // Test each benchmark method
            var result1 = b.ShuffleWithSecureRandom();
            b.GlobalSetup();
            var result2 = b.ShuffleWithSystemRandom();

            // Output results for comparison
            Console.WriteLine($"Full shuffle test:");
            Console.WriteLine($"Secure Random result count: {result1?.Count()}");
            Console.WriteLine($"System Random result count: {result2?.Count()}");
            Console.WriteLine($"Results have same count: {result1?.Count() == result2?.Count()}");

            // Test partial shuffle
            b.MaxItems = 50;
            b.GlobalSetup();
            var result3 = b.ShuffleWithSecureRandom();
            b.GlobalSetup();
            var result4 = b.ShuffleWithSystemRandom();

            Console.WriteLine($"\nPartial shuffle test:");
            Console.WriteLine($"Secure Random result count: {result3?.Count()}");
            Console.WriteLine($"System Random result count: {result4?.Count()}");
            Console.WriteLine($"Results have same count: {result3?.Count() == result4?.Count()}");
#endif
        }
    }
}

// Edited by AI 🤖
