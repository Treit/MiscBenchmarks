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
            b.Size = 32 * 1024;
            b.GlobalSetup();
            Console.WriteLine(b.PaginateWithArraySegment());
            Console.WriteLine(b.PaginateWithMemory());
#endif

        }
    }
}
