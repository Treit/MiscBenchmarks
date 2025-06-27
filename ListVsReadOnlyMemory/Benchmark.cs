namespace ListVsReadOnlyMemory
{
    using BenchmarkDotNet.Attributes;
    using System;
    using System.Collections.Generic;

    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(100, 10000)]
        public int Count { get; set; }

        private List<int> _list;
        private int[] _array;
        private ReadOnlyMemory<int> _readOnlyMemory;
        private Memory<int> _memory;
        private Random _random;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _random = new Random(42);

            // In debug mode, Count might be 0, so use a default value
            var actualCount = Count > 0 ? Count : 100;

            // Initialize data structures
            _array = new int[actualCount];
            _list = new List<int>(actualCount);

            // Populate with random data
            for (int i = 0; i < actualCount; i++)
            {
                var value = _random.Next(1000);
                _array[i] = value;
                _list.Add(value);
            }

            // Create Memory and ReadOnlyMemory from the array
            _memory = new Memory<int>(_array);
            _readOnlyMemory = new ReadOnlyMemory<int>(_array);
        }

        // Reading benchmarks
        [Benchmark(Baseline = true)]
        public long ReadList()
        {
            long sum = 0;
            for (int i = 0; i < _list.Count; i++)
            {
                sum += _list[i];
            }
            return sum;
        }

        [Benchmark]
        public long ReadReadOnlyMemory()
        {
            long sum = 0;
            var span = _readOnlyMemory.Span;
            for (int i = 0; i < span.Length; i++)
            {
                sum += span[i];
            }
            return sum;
        }

        [Benchmark]
        public long ReadMemory()
        {
            long sum = 0;
            var span = _memory.Span;
            for (int i = 0; i < span.Length; i++)
            {
                sum += span[i];
            }
            return sum;
        }

        // Sequential reading using foreach
        [Benchmark]
        public long ReadListForeach()
        {
            long sum = 0;
            foreach (var item in _list)
            {
                sum += item;
            }
            return sum;
        }

        [Benchmark]
        public long ReadReadOnlyMemoryForeach()
        {
            long sum = 0;
            foreach (var item in _readOnlyMemory.Span)
            {
                sum += item;
            }
            return sum;
        }

        // Writing benchmarks
        [Benchmark]
        public void WriteList()
        {
            for (int i = 0; i < _list.Count; i++)
            {
                _list[i] = i * 2;
            }
        }

        [Benchmark]
        public void WriteMemory()
        {
            var span = _memory.Span;
            for (int i = 0; i < span.Length; i++)
            {
                span[i] = i * 2;
            }
        }

        // Note: ReadOnlyMemory<T> cannot be written to, so no write benchmark for it

        // Random access reading
        [Benchmark]
        public long RandomAccessList()
        {
            long sum = 0;
            for (int i = 0; i < 1000; i++)
            {
                var index = _random.Next(_list.Count);
                sum += _list[index];
            }
            return sum;
        }

        [Benchmark]
        public long RandomAccessReadOnlyMemory()
        {
            long sum = 0;
            var span = _readOnlyMemory.Span;
            for (int i = 0; i < 1000; i++)
            {
                var index = _random.Next(span.Length);
                sum += span[index];
            }
            return sum;
        }

        // Creation/allocation benchmarks
        [Benchmark]
        public List<int> CreateList()
        {
            var actualCount = Count > 0 ? Count : 100;
            var list = new List<int>(actualCount);
            for (int i = 0; i < actualCount; i++)
            {
                list.Add(i);
            }
            return list;
        }

        [Benchmark]
        public ReadOnlyMemory<int> CreateReadOnlyMemory()
        {
            var actualCount = Count > 0 ? Count : 100;
            var array = new int[actualCount];
            for (int i = 0; i < actualCount; i++)
            {
                array[i] = i;
            }
            return new ReadOnlyMemory<int>(array);
        }
    }
}

// Edited by AI 🤖
