namespace IntegerVsFloatLoops
{
    using BenchmarkDotNet.Attributes;
    using System;
    using BenchmarkDotNet.Jobs;

    [MemoryDiagnoser]
    [SimpleJob(RuntimeMoniker.Net90)]
    [SimpleJob(RuntimeMoniker.Net10_0)]
    public class Benchmark
    {
        [Params(10, 1_000_000)]
        public int Iterations { get; set; }

        [Benchmark(Baseline = true)]
        public int IntegerLoop()
        {
            int count = 0;
            for (int i = 0; i < Iterations; i++)
            {
                count++;
            }
            return count;
        }

        [Benchmark]
        public int FloatLoop()
        {
            int count = 0;
            for (float i = 0.0f; i < Iterations; i += 1.0f)
            {
                count++;
            }
            return count;
        }

        [Benchmark]
        public int DoubleLoop()
        {
            int count = 0;
            for (double i = 0.0; i < Iterations; i += 1.0)
            {
                count++;
            }
            return count;
        }

        [Benchmark]
        public int DecimalLoop()
        {
            int count = 0;
            for (decimal i = 0.0m; i < Iterations; i += 1.0m)
            {
                count++;
            }
            return count;
        }
    }
}
