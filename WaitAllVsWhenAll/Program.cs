namespace Test
{
    using BenchmarkDotNet.Running;
    using System;
    using System.Threading.Tasks;

    internal class Program
    {
        static async Task Main(string[] args)
        {
#if RELEASE
            await Task.Yield();
            BenchmarkRunner.Run<Benchmark>();
#else
            Benchmark b = new Benchmark();
            b.GlobalSetup();
            b.ThreadCount = 16;
            b.Count = 1000;
            b.WaitAll();
            await b.WhenAll();
#endif
        }
    }
}
