namespace PropertyInitializationBenchmark
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
            var result1 = b.ExpressionBodiedProperty();
            b.GlobalSetup();
            var result2 = b.AutoPropertyWithInitializer();

            // Output results for comparison
            Console.WriteLine($"ExpressionBodiedProperty: {result1}");
            Console.WriteLine($"AutoPropertyWithInitializer: {result2}");

            // Verify results are equivalent
            Console.WriteLine($"Results equal: {result1?.Equals(result2) == true}");

            // Test individual instances to show the difference
            Console.WriteLine("\nTesting individual instances:");
            var expr = new ExpressionBodiedClass();
            var auto = new AutoPropertyClass();
            Console.WriteLine($"Expression-bodied: {expr.RoleInstance}");
            Console.WriteLine($"Auto-property: {auto.RoleInstance}");
#endif
        }
    }
}
