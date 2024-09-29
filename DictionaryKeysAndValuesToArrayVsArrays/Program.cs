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
            var first = b.BuildDictionaryAndThenUseToArray();
            var second = b.BuildTwoArraysDirectly();
            Console.WriteLine($"First: {first}, Second: {second}");
#endif
        }
    }
}
