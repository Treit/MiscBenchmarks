using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Frozen;
using System.Collections.Immutable;
using System.Linq;
using BenchmarkDotNet.Attributes;

namespace KeyValuePairIteration
{
    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(100, 10000)]
        public int Count { get; set; } = 100;

        private Dictionary<int, string> _dictionary;
        private SortedDictionary<int, string> _sortedDictionary;
        private ReadOnlyDictionary<int, string> _readOnlyDictionary;
        private FrozenDictionary<int, string> _frozenDictionary;
        private List<KeyValuePair<int, string>> _list;
        private SortedList<int, string> _sortedList;
        private ImmutableDictionary<int, string> _immutableDictionary;
        private ImmutableSortedDictionary<int, string> _immutableSortedDictionary;
        private KeyValuePair<int, string>[] _array;

        [GlobalSetup]
        public void GlobalSetup()
        {
            // Create test data
            _dictionary = new Dictionary<int, string>();
            for (int i = 0; i < Count; i++)
            {
                _dictionary[i] = $"Value_{i}";
            }

            _sortedDictionary = new SortedDictionary<int, string>(_dictionary);
            _readOnlyDictionary = new ReadOnlyDictionary<int, string>(_dictionary);
            _frozenDictionary = _dictionary.ToFrozenDictionary();
            _list = _dictionary.ToList();
            _sortedList = new SortedList<int, string>(_dictionary);
            _immutableDictionary = _dictionary.ToImmutableDictionary();
            _immutableSortedDictionary = _dictionary.ToImmutableSortedDictionary();
            _array = _dictionary.ToArray();
        }

        [Benchmark]
        public long EnumerateDictionary()
        {
            long sum = 0;
            foreach (var kvp in _dictionary)
            {
                sum += kvp.Key + kvp.Value.Length;
            }
            return sum;
        }

        [Benchmark]
        public long EnumerateSortedDictionary()
        {
            long sum = 0;
            foreach (var kvp in _sortedDictionary)
            {
                sum += kvp.Key + kvp.Value.Length;
            }
            return sum;
        }

        [Benchmark]
        public long EnumerateReadOnlyDictionary()
        {
            long sum = 0;
            foreach (var kvp in _readOnlyDictionary)
            {
                sum += kvp.Key + kvp.Value.Length;
            }
            return sum;
        }

        [Benchmark]
        public long EnumerateFrozenDictionary()
        {
            long sum = 0;
            foreach (var kvp in _frozenDictionary)
            {
                sum += kvp.Key + kvp.Value.Length;
            }
            return sum;
        }

        [Benchmark(Baseline = true)]
        public long EnumerateList()
        {
            long sum = 0;
            foreach (var kvp in _list)
            {
                sum += kvp.Key + kvp.Value.Length;
            }
            return sum;
        }

        [Benchmark]
        public long EnumerateSortedList()
        {
            long sum = 0;
            foreach (var kvp in _sortedList)
            {
                sum += kvp.Key + kvp.Value.Length;
            }
            return sum;
        }

        [Benchmark]
        public long EnumerateImmutableDictionary()
        {
            long sum = 0;
            foreach (var kvp in _immutableDictionary)
            {
                sum += kvp.Key + kvp.Value.Length;
            }
            return sum;
        }

        [Benchmark]
        public long EnumerateImmutableSortedDictionary()
        {
            long sum = 0;
            foreach (var kvp in _immutableSortedDictionary)
            {
                sum += kvp.Key + kvp.Value.Length;
            }
            return sum;
        }

        [Benchmark]
        public long EnumerateArray()
        {
            long sum = 0;
            foreach (var kvp in _array)
            {
                sum += kvp.Key + kvp.Value.Length;
            }
            return sum;
        }
    }
}
