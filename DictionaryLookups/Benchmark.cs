namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using System;
    using System.Collections;
    using System.Collections.Concurrent;
    using System.Collections.Frozen;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Collections.Specialized;

    public class SomeClass
    {
        public int DoSomething()
        {
            return (int)DateTime.UtcNow.Ticks;
        }
    }

    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(10_000)]
        public int Iterations { get; set; }

        private SortedList<int, SomeClass> _sortedListLookup;
        private Dictionary<int, SomeClass> _dictionaryLookup;
        private SortedDictionary<int, SomeClass> _sortedDictionaryLookup;
        private ConcurrentDictionary<int, SomeClass> _concurrentDictionaryLookup;
        private OrderedDictionary _orderedDictionary;
        private Hashtable _hashTable;
        private FrozenDictionary<int, SomeClass> _frozenDictionary;
        private ImmutableDictionary<int, SomeClass> _immutableDictionary;

        [GlobalSetup]
        public void GlobalSetup()
        {
            int len = 50;

            _sortedListLookup = new SortedList<int, SomeClass>(len);
            _dictionaryLookup = new Dictionary<int, SomeClass>(len);
            _sortedDictionaryLookup = new SortedDictionary<int, SomeClass>();
            _concurrentDictionaryLookup = new ConcurrentDictionary<int, SomeClass>();
            _orderedDictionary = new OrderedDictionary();
            _hashTable = new Hashtable();

            for (int i = 0; i < len; i++)
            {
                _sortedListLookup.Add(i, new SomeClass());
                _dictionaryLookup.Add(i, new SomeClass());
                _sortedDictionaryLookup.Add(i, new SomeClass());
                _concurrentDictionaryLookup.TryAdd(i, new SomeClass());
                _orderedDictionary.Add(i, new SomeClass());
                _hashTable.Add(i, new SomeClass());
            }

            _frozenDictionary = FrozenDictionary.ToFrozenDictionary(_dictionaryLookup);
            _immutableDictionary = ImmutableDictionary.CreateRange(_dictionaryLookup);
        }

        [Benchmark(Baseline = true)]
        public long LookupUsingDictionary()
        {
            long result = 0;

            for (int i = 0; i < Iterations; i++)
            {
                for (int j = 0; j < _sortedListLookup.Count; j++)
                {
                    SomeClass c = _dictionaryLookup[j];
                    result += c.DoSomething();
                }
            }

            return result;
        }

        [Benchmark]
        public long LookupUsingSortedList()
        {
            long result = 0;

            for (int i = 0; i < Iterations; i++)
            {
                for (int j = 0; j < _sortedListLookup.Count; j++)
                {
                    SomeClass c = _sortedListLookup[j];
                    result += c.DoSomething();
                }
            }

            return result;
        }

        [Benchmark]
        public long LookupUsingSortedDictionary()
        {
            long result = 0;

            for (int i = 0; i < Iterations; i++)
            {
                for (int j = 0; j < _sortedDictionaryLookup.Count; j++)
                {
                    SomeClass c = _sortedDictionaryLookup[j];
                    result += c.DoSomething();
                }
            }

            return result;
        }

        [Benchmark]
        public long LookupUsingConcurrentDictionary()
        {
            long result = 0;

            for (int i = 0; i < Iterations; i++)
            {
                for (int j = 0; j < _concurrentDictionaryLookup.Count; j++)
                {
                    SomeClass c = _concurrentDictionaryLookup[j];
                    result += c.DoSomething();
                }
            }

            return result;
        }

        [Benchmark]
        public long LookupUsingOrderedDictionary()
        {
            long result = 0;

            for (int i = 0; i < Iterations; i++)
            {
                for (int j = 0; j < _orderedDictionary.Count; j++)
                {
                    SomeClass c = (SomeClass)_orderedDictionary[j];
                    result += c.DoSomething();
                }
            }

            return result;
        }

        [Benchmark]
        public long LookupUsingHashtable()
        {
            long result = 0;

            for (int i = 0; i < Iterations; i++)
            {
                for (int j = 0; j < _hashTable.Count; j++)
                {
                    SomeClass c = (SomeClass)_hashTable[j];
                    result += c.DoSomething();
                }
            }

            return result;
        }

        [Benchmark]
        public long LookupUsingFrozenDictionary()
        {
            long result = 0;

            for (int i = 0; i < Iterations; i++)
            {
                for (int j = 0; j < _frozenDictionary.Count; j++)
                {
                    SomeClass c = _frozenDictionary[j];
                    result += c.DoSomething();
                }
            }

            return result;
        }

        [Benchmark]
        public long LookupUsingImmutableDictionary()
        {
            long result = 0;

            for (int i = 0; i < Iterations; i++)
            {
                for (int j = 0; j < _immutableDictionary.Count; j++)
                {
                    SomeClass c = _immutableDictionary[j];
                    result += c.DoSomething();
                }
            }

            return result;
        }
    }
}
