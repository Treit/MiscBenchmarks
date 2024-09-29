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
            b.Count = 100;
            b.GlobalSetup();
            var first = b.MemoryStreamToGuidUsingBitConverter();
            var second = b.MemoryStreamToGuidUsingToHexString();
            var third = b.MemoryStreamToGuidUsingSpanAndBigEndian();
            var fourth = b.MemoryStreamToGuidUsingBinaryPrimitivesChatGPT();
            Console.WriteLine(first);
            Console.WriteLine(second);
            Console.WriteLine(third);
            Console.WriteLine(fourth);
#endif
        }
    }
}
