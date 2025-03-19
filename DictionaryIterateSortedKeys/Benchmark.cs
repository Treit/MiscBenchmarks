namespace Test
{
    using BenchmarkDotNet.Attributes;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(10, 1000)]
        public int Count { get; set; }

        private IDictionary<string, int> _items;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _items = new Dictionary<string, int>();
            var random = new Random(Count);

            for (int i = 0; i < Count; i++)
            {
                _items.Add(random.Next().ToString(), random.Next());
            }
        }

        [Benchmark(Baseline = true)]
        public long IterateSortedKeysWithLINQOrderBy()
        {
            var sorted = _items.Keys.OrderBy(x => x);
            long sum = 0;

            foreach (var key in sorted)
            {
                sum += key.Length;
            }

            return sum;
        }

        [Benchmark]
        public long IterateSortedKeysWithNewListAndSort()
        {
            var sorted = new List<string>(_items.Keys);
            sorted.Sort();

            long sum = 0;

            foreach (var key in sorted)
            {
                sum += key.Length;
            }

            return sum;
        }

        [Benchmark]
        public long IterateSortedKeysWithOrder()
        {
            var sorted = _items.Keys.Order();
            long sum = 0;

            foreach (var key in sorted)
            {
                sum += key.Length;
            }

            return sum;
        }

        [Benchmark]
        public long IterateSortedKeysOriginal()
        {
            var sorted = _items.OrderBy(kv => kv.Key).ToDictionary(kv => kv.Key, kv => kv.Value).Keys.ToList();
            long sum = 0;

            foreach (var key in sorted)
            {
                sum += key.Length;
            }

            return sum;
        }
    }
}
