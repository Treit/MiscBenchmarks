namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using Cathei.LinqGen;
    using System;
    using System.Linq;

    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(1_000_000)]
        public int Count { get; set; }

        private int[] _array;

        [GlobalSetup]
        public void GlobalSetup()
        {
            Random r = new Random();

            _array = new int[Count];

            for (int i = 0; i < Count; i++)
            {
                _array[i] = r.Next(0, 100);
            }
        }

        [Benchmark(Baseline = true)]
        public int[] WhereUsingLinq()
        {
            return _array.Where(x => x % 2 == 0).ToArray();
        }

        [Benchmark]
        public int[] WhereUsingLinqGen()
        {
            return _array.Specialize().Where(x => x % 2 == 0).ToArray();
        }
    }
}
