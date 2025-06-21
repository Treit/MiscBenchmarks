namespace ImmutableArrayVsReadOnlyList
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


            b.Iterations = 10;
            var result1 = b.GetAsImmutableArray();
            b.GlobalSetup();
            var result2 = b.GetAsReadOnlyList();

            Console.WriteLine($"ImmutableArray result: {result1}");
            Console.WriteLine($"ReadOnlyList result: {result2}");

#endif
        }
    }
}
