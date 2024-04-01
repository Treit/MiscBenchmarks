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
            var tupA = b.TokenizeWithStringSplit();
            var tupB = b.TokenizeWithSubstring();
            var tupC = b.TokenizeWithRangeOperator();
            var tupD = b.TokenizeWithRegexGroupsDotValue();
            var tupE = b.TokenizeWithRegexMatchDotResult();
            Console.WriteLine(tupA);
            Console.WriteLine(tupB);
            Console.WriteLine(tupC);
            Console.WriteLine(tupD);
            Console.WriteLine(tupE);
#endif
        }
    }
}
