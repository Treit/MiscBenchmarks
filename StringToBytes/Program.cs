﻿namespace Test
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
            b.Count = 100;
            b.GlobalSetup();
            var first = b.StringToBytesUsingUnicodeEncoding();
            var second = b.StringToBytesUsingUnicodeEncoding();
            Console.WriteLine(first);
            Console.WriteLine(second);
#endif
        }
    }
}
