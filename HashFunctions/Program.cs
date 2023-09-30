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
            b.Size = 1024;
            b.GlobalSetup();
            var x = b. Hash64BitUsingMD5ChatGPT();
            var y = b.HashCRC32();
            Console.WriteLine(x == y);
#endif

        }
    }
}
