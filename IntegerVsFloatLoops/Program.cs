namespace IntegerVsFloatLoops
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
            Benchmark b = new Benchmark();
            b.Iterations = 1000;

            var result1 = b.IntegerLoop();
            var result2 = b.FloatLoop();
            var result3 = b.DoubleLoop();
            var result4 = b.DecimalLoop();
            Console.WriteLine($"Integer Loop Result: {result1}");
            Console.WriteLine($"Float Loop Result: {result2}");
            Console.WriteLine($"Double Loop Result: {result3}");
            Console.WriteLine($"Decimal Loop Result: {result4}");
#endif
        }
    }
}
