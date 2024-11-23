namespace Test
{
    using BenchmarkDotNet.Running;
    using System;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
#if RELEASE
            BenchmarkRunner.Run<Benchmark>();
#else
            Benchmark b = new Benchmark();
            b.GlobalSetup();
            b.Value = "needle_in_a_haystack";
            var answerA = b.CheckWithSimpleEqualityTest();
            var answerB = b.CheckWithNewHashSet();
            var answerC = b.CheckWithStaticHashSet();
            var answerD = b.CheckWithCharListPattern();
            Console.WriteLine($"CheckWithSimpleIf: {answerA}");
            Console.WriteLine($"CheckWithNewHashSet: {answerB}");
            Console.WriteLine($"CheckWithStaticHashSet: {answerC}");
            Console.WriteLine($"CheckWithCharListPattern: {answerD}");
#endif
        }
    }
}
