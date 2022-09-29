namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(100_000)]
        public int Count { get; set; }

        private int[] _data;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _data = new int[Count];

            var r = new Random(Count);

            for (int i = 0; i < Count; i++)
            {
                _data[i] = r.Next(100);
            }
        }

        [Benchmark(Baseline = true)]
        public long ForEachUsingHashSet()
        {
            var count = 0L;

            foreach (int idx in new HashSet<int>(_data))
            {
                count++;
            }

            return count;
        }

        [Benchmark]
        public long ForEachUsingDistinct()
        {
            var count = 0L;

            foreach (int idx in _data.Distinct())
            {
                count++;
            }

            return count;
        }
    }
}
