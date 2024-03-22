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
            b.Count = 10_000;
            b.GlobalSetup();
            var first = b.ReadDataUsingBitConverter();
            var second = b.ReadDataUsingBinaryPrimitivesAndSpan();
            var third = b.ReadDataUsingBinaryPrimitivesAndSpanWithReinterpretCast();

            Console.WriteLine(first);
            Console.WriteLine(second);
            Console.WriteLine(third);
#endif

        }
    }
}
