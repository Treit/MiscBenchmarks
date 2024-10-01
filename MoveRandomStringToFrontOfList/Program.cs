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
            var first = b.MoveUsingRandomIndex();
            var second = b.MoveUsingLinqOrderByRandomWithUnecessaryToList();
            var third = b.MoveUsingCollectionsMarshal();
            Console.WriteLine(first);
            Console.WriteLine(second);
            Console.WriteLine(third);
#endif
        }
    }
}
