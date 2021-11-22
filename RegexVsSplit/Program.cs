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
            b.Count = 1000;
            b.GlobalSetup();
            int x = b.FindTokenUsingSpan();
            int z = b.FindTokenUsingSplit();
            int y = b.FindTokenUsingTokenize();

            if (x != y || x != z)
            {
                throw new InvalidOperationException($"Expected to be the same! {x} - {y}");
            }
#endif

        }
    }
}
