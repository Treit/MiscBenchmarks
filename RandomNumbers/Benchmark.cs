namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using System;

    [MemoryDiagnoser]
    public class Benchmark
    {
        public static Random s_random;

        public static Random s_randomNoSeed;

        [ThreadStatic]
        public static Random s_randomThreadStatic;

        public static Xorshift s_xorshift;

        public static object s_lockobj = new object();

        [Params(1_000_000)]
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            s_random = new Random(Count);
            s_randomNoSeed = new Random();
            s_xorshift = new Xorshift((uint)Count);
        }

        [Benchmark(Baseline = true)]
        public long SystemRandomStaticInstanceWithSeed()
        {
            long result = 0;

            for (int i = 0; i < Count; i++)
            {
                result += s_random.Next();
            }

            return result;
        }

        [Benchmark]
        public long SystemRandomLocalInstanceWithSeed()
        {
            long result = 0;
            var random = new Random(Count);

            for (int i = 0; i < Count; i++)
            {
                result += random.Next();
            }

            return result;
        }


        [Benchmark]
        public long SystemRandomDotShared()
        {
            long result = 0;

            for (int i = 0; i < Count; i++)
            {
                result += Random.Shared.Next();
            }

            return result;
        }

        [Benchmark]
        public long SystemRandomStaticInstanceNoSeed()
        {
            long result = 0;

            for (int i = 0; i < Count; i++)
            {
                result += s_randomNoSeed.Next();
            }

            return result;
        }

        [Benchmark]
        public long SystemRandomLocalInstanceNoSeed()
        {
            long result = 0;
            var random = new Random();

            for (int i = 0; i < Count; i++)
            {
                result += random.Next();
            }

            return result;
        }

        [Benchmark]
        public long SystemRandomWithLock()
        {
            long result = 0;

            for (int i = 0; i < Count; i++)
            {
                lock (s_lockobj)
                {
                    result += s_random.Next();
                }
            }

            return result;
        }

        [Benchmark]
        public long SystemRandomNewInstanceEveryTime()
        {
            long result = 0;

            for (int i = 0; i < Count; i++)
            {
                var random = new Random(i);
                result += random.Next();
            }

            return result;
        }

        [Benchmark]
        public long SystemRandomThreadStatic()
        {
            long result = 0;

            if (s_randomThreadStatic == null)
            {
                s_randomThreadStatic = new Random(Count);
            }

            for (int i = 0; i < Count; i++)
            {
                result += s_randomThreadStatic.Next();
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
