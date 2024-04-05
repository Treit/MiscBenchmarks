namespace Test
{
    using BenchmarkDotNet.Running;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
#if RELEASE
            BenchmarkRunner.Run<Benchmark>();
#else
            Benchmark b = new Benchmark();
            b.Count = 1;
            b.GlobalSetup();
            var first = b.ConvertFromBase64WtihSubstring();
            var second= b.ConvertTryFromBase64Chars();
            var third = b.ConvertTryFromBase64CharsWithArrayPool();

            Console.WriteLine("First:");
            PrintResult(first.First());
            Console.WriteLine("Second:");
            PrintResult(second.First());
            Console.WriteLine("Third:");
            PrintResult(third.First());
#endif
        }

        static void PrintResult(Dictionary<string, float> result)
        {
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
