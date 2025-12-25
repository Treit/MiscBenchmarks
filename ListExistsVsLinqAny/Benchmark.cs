namespace ListExistsVsLinqAny
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Jobs;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [MemoryDiagnoser]
    [MemoryRandomization]
    [SimpleJob(RuntimeMoniker.Net80)]
    [SimpleJob(RuntimeMoniker.Net10_0)]
    public class Benchmark
    {
        [Params(100, 1_000_000)]
        public int Count { get; set; }

        private List<int> _list;
        private int _targetFound;
        private int _targetNotFound;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _list = new List<int>(Count);
            var random = new Random(42);

            for (int i = 0; i < Count; i++)
            {
                _list.Add(random.Next(0, Count * 10));
            }

            // Target that exists (pick an element near the end to avoid best-case scenarios)
            _targetFound = _list[Count - 1];

            // Target that doesn't exist
            _targetNotFound = -1;
        }

        [Benchmark(Baseline = true)]
        public bool ListExists_Found()
        {
            return _list.Exists(x => x == _targetFound);
        }

        [Benchmark]
        public bool LinqAny_Found()
        {
            return _list.Any(x => x == _targetFound);
        }

        [Benchmark]
        public bool ListExists_NotFound()
        {
            return _list.Exists(x => x == _targetNotFound);
        }

        [Benchmark]
        public bool LinqAny_NotFound()
        {
            return _list.Any(x => x == _targetNotFound);
        }
    }
}
