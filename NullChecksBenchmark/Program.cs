using BenchmarkDotNet.Running;
using System;

namespace NullChecksBenchmark
{
    internal class Program
    {
        static void Main(string[] args)
        {
#if RELEASE
            BenchmarkRunner.Run<Benchmark>();
#else
            var b = new Benchmark();            foreach (var scenario in new[] { "AllNonNull", "OneNull", "LastNull" })
            {
                foreach (var iterations in new[] { 1000, 10000 })
                {
                    b.Scenario = scenario;
                    b.Iterations = iterations;
                    b.GlobalSetup();                    var result1 = b.ExplicitNullChecks();
                    var result2 = b.LinqAnyWithArray();
                    var result3 = b.PatternMatchingSwitch();

                    Console.WriteLine($"Scenario: {scenario}, Iterations: {iterations}");
                    Console.WriteLine($"ExplicitNullChecks: {result1}");
                    Console.WriteLine($"LinqAnyWithArray: {result2}");
                    Console.WriteLine($"PatternMatchingSwitch: {result3}");
                    Console.WriteLine($"Results equal: {result1 == result2 && result2 == result3}");
                    Console.WriteLine();
                }
            }
#endif
        }
    }
}

// Edited by AI 🤖
