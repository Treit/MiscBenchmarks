namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using System;

    [MemoryDiagnoser]
    public class Benchmark
    {
        public static Random s_random;
        public static Xorshift s_xorshift;

        [Params(1_000_000)]
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            s_random = new Random(Count);
            s_xorshift = new Xorshift((uint)Count);
        }

        [Benchmark(Baseline = true)]
        public long SystemRandom()
        {
            long result = 0;

            for (int i = 0; i < Count; i++)
            {
                result += s_random.Next();
            }

            return result;
        }

        [Benchmark]
        public long XorShiftRandom()
        {
            long result = 0;

            for (int i = 0; i < Count; i++)
            {
                result += s_xorshift.Next();
            }

            return result;
        }
    }
}
