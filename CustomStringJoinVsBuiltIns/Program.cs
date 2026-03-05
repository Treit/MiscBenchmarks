namespace CustomStringJoinVsBuiltIns
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
            var b = new Benchmark();
            b.Count = 10;
            b.GlobalSetup();

            var result1 = b.CustomSpanJoin();
            b.GlobalSetup();
            var result1b = b.CustomSpanJoinConstant();
            b.GlobalSetup();
            var result2 = b.StringConcat();
            b.GlobalSetup();
            var result3 = b.StringJoin();
            b.GlobalSetup();
            var result4 = b.StringInterpolation();
            b.GlobalSetup();
            var result5 = b.StringCreate();

            Console.WriteLine($"CustomSpanJoin:         {result1}");
            Console.WriteLine($"CustomSpanJoinConstant: {result1b}");
            Console.WriteLine($"StringConcat:           {result2}");
            Console.WriteLine($"StringJoin:             {result3}");
            Console.WriteLine($"StringInterpolation:    {result4}");
            Console.WriteLine($"StringCreate:           {result5}");
            Console.WriteLine($"Results equal: {result1 == result1b && result1b == result2 && result2 == result3 && result3 == result4 && result4 == result5}");
#endif
        }
    }
}