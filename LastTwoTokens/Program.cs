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
            b.GlobalSetup();
            var first = b.LastTwoTokensWithSplit();
            var second = b.LastTwoTokensWithRegex();
            var third = b.LastTwoTokensWithReverseAndSubstring();
            var fourth = b.LastTwoTokensWalkingBackwards();
            var fifth = b.LastTwoTokensWithSpanAndLastIndexOf();
            Console.WriteLine(first);
            Console.WriteLine(second);
            Console.WriteLine(third);
            Console.WriteLine(fourth);
            Console.WriteLine(fifth);
#endif
        }
    }
}
