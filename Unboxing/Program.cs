namespace Test
{
    using System;
    using BenchmarkDotNet.Running;

    internal class Program
    {
        static void Main(string[] args)
        {
#if RELEASE
            BenchmarkRunner.Run<Benchmark>();
#else
            Benchmark b = new Benchmark();
            b.Count = 1000;
            b.GlobalSetup();
            var sum1 = b.SumIntListWithoutUnboxing();
            var sum2 = b.SumObjectListWithUnboxing();
            Console.WriteLine($"Sum without unboxing: {sum1}");
            Console.WriteLine($"Sum with unboxing: {sum2}");
#endif
        }
    }
}
