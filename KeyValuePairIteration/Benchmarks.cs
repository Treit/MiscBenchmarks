using System;
using System.Collections;
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
        private class KeyValuePairComparer : IComparer<KeyValuePair<int, string>>
        {
            public int Compare(KeyValuePair<int, string> x, KeyValuePair<int, string> y)
            {
                int keyComparison = x.Key.CompareTo(y.Key);
                return keyComparison != 0 ? keyComparison : string.Compare(x.Value, y.Value, StringComparison.Ordinal);
            }
        }

        [Params(100)]
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
        private HashSet<KeyValuePair<int, string>> _hashSet;
        private SortedSet<KeyValuePair<int, string>> _sortedSet;
        private ImmutableHashSet<KeyValuePair<int, string>> _immutableHashSet;
        private ImmutableSortedSet<KeyValuePair<int, string>> _immutableSortedSet;
        private Hashtable _hashtable;
        private ArrayList _arrayList;
        private Queue _queue;
        private Stack _stack;
        private Queue<KeyValuePair<int, string>> _genericQueue;
        private Stack<KeyValuePair<int, string>> _genericStack;

        private static readonly KeyValuePairComparer _comparer = new KeyValuePairComparer();

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
            _hashSet = new HashSet<KeyValuePair<int, string>>(_dictionary);
            _sortedSet = new SortedSet<KeyValuePair<int, string>>(_dictionary, _comparer);
            _immutableHashSet = _dictionary.ToImmutableHashSet();
            _immutableSortedSet = _dictionary.ToImmutableSortedSet(_comparer);

            // Non-generic collections
            _hashtable = new Hashtable();
            _arrayList = new ArrayList();
            _queue = new Queue();
            _stack = new Stack();

            // Generic collections
            _genericQueue = new Queue<KeyValuePair<int, string>>();
            _genericStack = new Stack<KeyValuePair<int, string>>();

            foreach (var kvp in _dictionary)
            {
                _hashtable[kvp.Key] = kvp.Value;
                _arrayList.Add(new DictionaryEntry(kvp.Key, kvp.Value));
                _queue.Enqueue(new DictionaryEntry(kvp.Key, kvp.Value));
                _stack.Push(new DictionaryEntry(kvp.Key, kvp.Value));
                _genericQueue.Enqueue(kvp);
                _genericStack.Push(kvp);
            }
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

        [Benchmark]
        public long EnumerateHashSet()
        {
            long sum = 0;
            foreach (var kvp in _hashSet)
            {
                sum += kvp.Key + kvp.Value.Length;
            }
            return sum;
        }

        [Benchmark]
        public long EnumerateSortedSet()
        {
            long sum = 0;
            foreach (var kvp in _sortedSet)
            {
                sum += kvp.Key + kvp.Value.Length;
            }
            return sum;
        }

        [Benchmark]
        public long EnumerateImmutableHashSet()
        {
            long sum = 0;
            foreach (var kvp in _immutableHashSet)
            {
                sum += kvp.Key + kvp.Value.Length;
            }
            return sum;
        }

        [Benchmark]
        public long EnumerateImmutableSortedSet()
        {
            long sum = 0;
            foreach (var kvp in _immutableSortedSet)
            {
                sum += kvp.Key + kvp.Value.Length;
            }
            return sum;
        }

        [Benchmark]
        public long EnumerateHashtable()
        {
            long sum = 0;
            foreach (DictionaryEntry entry in _hashtable)
            {
                sum += (int)entry.Key + ((string)entry.Value).Length;
            }
            return sum;
        }

        [Benchmark]
        public long EnumerateArrayList()
        {
            long sum = 0;
            foreach (DictionaryEntry entry in _arrayList)
            {
                sum += (int)entry.Key + ((string)entry.Value).Length;
            }
            return sum;
        }

        [Benchmark]
        public long EnumerateQueue()
        {
            long sum = 0;
            foreach (DictionaryEntry entry in _queue)
            {
                sum += (int)entry.Key + ((string)entry.Value).Length;
            }
            return sum;
        }

        [Benchmark]
        public long EnumerateStack()
        {
            long sum = 0;
            foreach (DictionaryEntry entry in _stack)
            {
                sum += (int)entry.Key + ((string)entry.Value).Length;
            }
            return sum;
        }

        [Benchmark]
        public long EnumerateGenericQueue()
        {
            long sum = 0;
            foreach (var kvp in _genericQueue)
            {
                sum += kvp.Key + kvp.Value.Length;
            }
            return sum;
        }

        [Benchmark]
        public long EnumerateGenericStack()
        {
            long sum = 0;
            foreach (var kvp in _genericStack)
            {
                sum += kvp.Key + kvp.Value.Length;
            }
            return sum;
        }
    }
}
