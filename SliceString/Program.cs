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
            b.Count = 1;
            b.GlobalSetup();
            var first = b.SliceWithSpan();
            var second = b.SliceWithEnumerable();
            Console.WriteLine(string.Join("\n", first));
            Console.WriteLine("----");
            Console.WriteLine(string.Join("\n", second));
#endif
        }
    }
}
