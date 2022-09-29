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
        public int TotalItems { get; set; }

        [Params(10, 100, 100_000)]
        public int RandomNumberCeiling { get; set; }

        private const int DefaultInternalSetCapacity = 7;

        private int[] _data;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _data = new int[TotalItems];

            var r = new Random(TotalItems);

            for (int i = 0; i < TotalItems; i++)
            {
                _data[i] = r.Next(RandomNumberCeiling);
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
            }

            foreach (int val in set)
            {
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
