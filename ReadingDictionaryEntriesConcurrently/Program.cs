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
            BenchmarkRunner.Run<Benchmark>();
#else
            Benchmark b = new Benchmark();
            b.Count = 1000;
            b.GlobalSetup();
            var first = await b.ConcurrentReadsUsingConcurrentDictionary();
            var second = await b.ConcurrentReadsUsingDictionaryNoLockingNotThreadSafe();
            var third = await b.ConcurrentReadsUsingFrozentDictionary();
            Console.WriteLine(first);
            Console.WriteLine(second);
            Console.WriteLine(third);
#endif
        }
    }
}
