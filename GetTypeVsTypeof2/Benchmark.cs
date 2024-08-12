namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using System;

    [MemoryDiagnoser]
    public class Benchmark
    {
        static Type s_type = typeof(Benchmark);

        [Params(1_000_000)]
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
        }

        [Benchmark(Baseline = true)]
        public Type UsingTypeof()
        {
            Type t = null;

            for (int i = 0; i < Count; i++)
            {
                t = typeof(Benchmark);
            }

            return t;
        }

        [Benchmark]
        public Type UsingThisDotGetType()
        {
            Type t = null;

            for (int i = 0; i < Count; i++)
            {
                t = this.GetType();
            }

            return t;
        }

        [Benchmark]
        public Type UsingCachedType()
        {
            Type t = null;

            for (int i = 0; i < Count; i++)
            {
                t = s_type;
            }

            return t;
        }
    }
}
