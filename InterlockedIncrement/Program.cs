namespace InterlockedIncrement
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
            var result1 = b.PlainIncrement();
            
            b.GlobalSetup();
            var result2 = b.InterlockedIncrementMethod();

            // Output results for comparison
            Console.WriteLine($"PlainIncrement: {result1}");
            Console.WriteLine($"InterlockedIncrement: {result2}");

            // Verify results are equivalent
            Console.WriteLine($"Results equal: {result1 == result2}");
#endif
        }
    }
}
