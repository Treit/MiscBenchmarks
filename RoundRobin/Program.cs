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
            b.Count = 3;
            b.GlobalSetup();
            var first = b.RoundRobinUsingListAndEnumerators();
            var second = b.RoundRobinUsingQueue();
            var third = b.RoundRobinUsingQueueAndEnumerators();
            var fourth = b.RoundRobinUsingListAndEnumerators2();
            var fifth = b.RoundRobinUsingSuperLinqInterleave();

            foreach (var item in first)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("----------------------------");

            foreach (var item in second)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("----------------------------");

            foreach (var item in third)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("----------------------------");
            foreach (var item in fourth)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("----------------------------");
            foreach (var item in fifth)
            {
                Console.WriteLine(item);
            }
#endif
        }
    }
}
