namespace Test
{
    using BenchmarkDotNet.Attributes;
    using System;
    using System.Numerics;

    public class Benchmark
    {
        [Params(100_000)]
        public int Count { get; set; }

        private static int[] RandomInts;

        [GlobalSetup]
        public void GlobalSetup()
        {
            RandomInts = new int[Count];

            // Use Count as the seed.
            var r = new Random(Count);

            for (int i = 0; i < Count; i++)
            {
                RandomInts[i] = r.Next(16);
            }
        }

        [Benchmark(Baseline = true)]
        public long SquareUsingMultiply()
        {
            long result = 0;

            foreach (var val in RandomInts)
            {
                result += val * val;
            }

            return result;
        }

        [Benchmark]
        public long SquareUsingMathPow()
        {
            long result = 0;

            foreach (var val in RandomInts)
            {
                result += (int)Math.Pow(val, 2);
            }

            return result;
        }

        [Benchmark]
        public long SquareUsingBigIntegerPow()
        {
            long result = 0;

            foreach (var val in RandomInts)
            {
                result += (int)BigInteger.Pow(val, 2);
            }

            return result;
        }
    }
}


