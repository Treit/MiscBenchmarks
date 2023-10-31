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
            b.Count = 1024;
            b.GlobalSetup();
            var first = b.WriteArray();
            var second = b.WriteMemoryStream();
            var third = b.WriteMemoryStreamInChunks();
            var fourth = b.WriteArrayInChunks();

            Console.WriteLine(first);
            Console.WriteLine(second);
            Console.WriteLine(third);
            Console.WriteLine(fourth);
#endif

        }
    }
}
