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
            b.BucketCount = 50;
            b.KeyCount = 100;
            b.GlobalSetup();
            b.IndexViaAdditionAndTwoMods();

            foreach (var item in b.Buckets)
            {
                Console.WriteLine(item);
            }

#endif
        }
    }
}
