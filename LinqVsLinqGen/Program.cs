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
            b.Count = 1000;
            b.GlobalSetup();
            var first = b.WhereUsingLinq();
            var second = b.WhereUsingLinqGen();
            if (first.Length != second.Length)
            {
                throw new InvalidOperationException("Mismatch!");
            }
#endif
        }
    }
}
