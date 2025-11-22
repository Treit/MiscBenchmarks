namespace SortWithEnumParsing
{
    using System;
    using System.Linq;
    using BenchmarkDotNet.Running;

    internal class Program
    {
        static void Main(string[] args)
        {
#if RELEASE
            BenchmarkRunner.Run<Benchmark>();
#else
            Benchmark benchmark = new()

            {
                Count = 100,
            };

            benchmark.GlobalSetup();
            ExpressionHolidayItem[] expressionResult = benchmark.ExpressionPropertySort();
            benchmark.GlobalSetup();
            CachedHolidayItem[] cachedResult = benchmark.CachedPropertySort();

            Console.WriteLine($"Expression-bodied first element: {expressionResult[0].Holiday}");
            Console.WriteLine($"Cached-property first element: {cachedResult[0].Holiday}");
            Console.WriteLine($"Sequences equal: {expressionResult.Select(x => x.Holiday).SequenceEqual(cachedResult.Select(x => x.Holiday))}");
#endif
        }
    }
}