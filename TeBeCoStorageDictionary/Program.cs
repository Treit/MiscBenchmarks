namespace StorageDictionary
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
            Benchmark benchmark = new Benchmark
            {
                EntityCount = 128,
            };

            benchmark.GlobalSetup();
            int newTypeof = benchmark.NewImplementationTypeOf();
            benchmark.GlobalSetup();
            int oldTypeof = benchmark.OldImplementationTypeOf();
            benchmark.GlobalSetup();
            int newGetType = benchmark.NewImplementationGetType();
            benchmark.GlobalSetup();
            int oldGetType = benchmark.OldImplementationGetType();

            Console.WriteLine($"New typeof count: {newTypeof}");
            Console.WriteLine($"Old typeof count: {oldTypeof}");
            Console.WriteLine($"New GetType count: {newGetType}");
            Console.WriteLine($"Old GetType count: {oldGetType}");
#endif
        }
    }
}