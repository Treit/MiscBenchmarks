namespace Test
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
            b.ListSize = 1000;
            b.RangeSize = 5;
            b.GlobalSetup();
            var first = b.LinqSkipTakeFirstN();
            var second = b.ToListDotGetRangeFirstN();
            Console.WriteLine(first);
            Console.WriteLine(second);
            var third = b.LinqSkipTakeLastN();
            var fourth = b.ToListDotGetRangeLastN();
            Console.WriteLine(third);
            Console.WriteLine(fourth);

#endif

        }
    }
}
