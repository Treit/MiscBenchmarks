#pragma warning disable SYSLIB0013 // Type or member is obsolete
namespace Test
{
    using BenchmarkDotNet.Running;
    using Microsoft.Diagnostics.Tracing.Parsers;
    using System;
    using System.Linq;
    using System.Net;

    internal class Program
    {
        static void Main(string[] args)
        {
#if RELEASE
            BenchmarkRunner.Run<Benchmark>();
#else
            Benchmark b = new Benchmark();
            b.Count = 100_543;
            b.GlobalSetup();
            var first = Benchmark.EscapeAndEncodeSpecialChars("https://something.example.com/{123}/a-b_c{{123}}/foo/[{123}]");
            var second = Benchmark.New("https://something.example.com/{123}/a-b_c{{123}}/foo/[{123}]");
            var third = Benchmark.CharLookup("https://something.example.com/{123}/a-b_c{{123}}/foo/[{123}]");

            Console.WriteLine(first == second);
            Console.WriteLine(first == third);
            Console.WriteLine(first);
            Console.WriteLine(second);
            Console.WriteLine(third);
#endif
        }
    }
}
#pragma warning restore SYSLIB0013 // Type or member is obsolete