namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(10, 100, 100_000)]
        public int Count { get; set; }

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
        public bool FindUsingList()
        {
            var list = _list;
            var r = new Random(Count);
            var needle = r.Next(Count);
            return list.Contains(needle);
        }

        [Benchmark]
        public bool FindUsingHashSet()
        {
            var set = _set;
            var r = new Random(Count);
            var needle = r.Next(Count);
            return set.Contains(needle);
        }
    }
}
