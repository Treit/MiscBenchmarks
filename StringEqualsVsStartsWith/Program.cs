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
            b.Count = 1000;
            b.GlobalSetup();
            var first = b.EqualStringsCompareWithStartsWithMethod();
            var second = b.EqualStringsCompareWithEqualsOperator();
            var third = b.EqualStringsCompareWithEqualsMethod();
            Console.WriteLine(first);
            Console.WriteLine(second);
            Console.WriteLine(third);
#endif

        }
    }
}
