namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using System;
    using System.Collections.Generic;

    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(10, 100, 100_000)]
        public int Count { get; set; }

        [Params(1, 50, 1000)]
        public int NumberOfLookups { get; set; }

        private List<int> _list;
        private HashSet<int> _set;

        [GlobalSetup]
        public void GlobalSetup()
        {
            Random r = new Random();

            _list = new List<int>(Count);

            for (int i = 0; i < Count; i++)
            {
                _list.Add(i);
            }

            _set = new HashSet<int>(_list);
        }

        [Benchmark(Baseline = true)]
        public int FindUsingList()
        {
            var list = _list;
            var r = new Random(Count);
            var needle = r.Next(Count);
            var result = 0;

            for (int i = 0; i < NumberOfLookups; i++)
            {
                if (list.Contains(needle))
                {
                    result++;
                }
            }

            return result;
        }

        [Benchmark]
        public int FindUsingHashSet()
        {
            var set = _set;
            var r = new Random(Count);
            var needle = r.Next(Count);
            var result = 0;

            for (int i = 0; i < NumberOfLookups; i++)
            {
                if (set.Contains(needle))
                {
                    result++;
                }
            }

            return result;
        }
    }
}
