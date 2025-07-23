namespace LinkedListVsListIteration
{
    using BenchmarkDotNet.Attributes;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(100, 1000, 10000)]
        public int Count { get; set; }

        private LinkedList<int> _linkedList = null!;
        private List<int> _list = null!;
        private Random _random = null!;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _random = new Random(42); // Fixed seed for reproducible results
            
            // Generate random data
            var data = Enumerable.Range(0, Count)
                .Select(_ => _random.Next(1, 1000))
                .ToArray();

            // Populate LinkedList
            _linkedList = new LinkedList<int>();
            foreach (var item in data)
            {
                _linkedList.AddLast(item);
            }

            // Populate List<T>
            _list = new List<int>(data);
        }

        [Benchmark(Baseline = true)]
        public long IterateList()
        {
            long sum = 0;
            foreach (var item in _list)
            {
                sum += item;
            }
            return sum;
        }

        [Benchmark]
        public long IterateListWithIndexer()
        {
            long sum = 0;
            for (int i = 0; i < _list.Count; i++)
            {
                sum += _list[i];
            }
            return sum;
        }

        [Benchmark]
        public long IterateLinkedList()
        {
            long sum = 0;
            foreach (var item in _linkedList)
            {
                sum += item;
            }
            return sum;
        }

        [Benchmark]
        public long IterateLinkedListNodes()
        {
            long sum = 0;
            var current = _linkedList.First;
            while (current != null)
            {
                sum += current.Value;
                current = current.Next;
            }
            return sum;
        }

        [Benchmark]
        public long IterateListArray()
        {
            long sum = 0;
            // Convert to array for span-like performance
            var array = _list.ToArray();
            foreach (var item in array)
            {
                sum += item;
            }
            return sum;
        }

        [Benchmark]
        public long IterateListLinq()
        {
            return _list.Sum(x => (long)x);
        }

        [Benchmark]
        public long IterateLinkedListLinq()
        {
            return _linkedList.Sum(x => (long)x);
        }
    }
}
