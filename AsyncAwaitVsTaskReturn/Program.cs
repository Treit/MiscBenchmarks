namespace AsyncAwaitVsTaskReturn
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
            var b = new Benchmark();
            b.Count = 10000;
            b.GlobalSetup();
            var first = await b.AsyncAwaitWithAwaitChain();
            var second = await b.AsyncAwaitWithReturnChain();
            Console.WriteLine($"First: {first}, Second: {second}");
#endif
        }
    }
}
