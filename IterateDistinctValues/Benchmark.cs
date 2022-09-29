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

        private const int DefaultInternalSetCapacity = 7;

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

            foreach (int val in new HashSet<int>(_data))
            {
                count++;
            }

            return count;
        }

        [Benchmark]
        public long ForEachUsingHashSetWithInitialCapacity()
        {
            var set = new HashSet<int>(DefaultInternalSetCapacity, null);
            var count = 0L;

            foreach (int val in _data)
            {
                set.Add(val);
                count++;
            }

            return count;
        }

        [Benchmark]
        public long ForEachUsingDistinct()
        {
            var count = 0L;

            foreach (int val in _data.Distinct())
            {
                count++;
            }

            return count;
        }
    }
}
