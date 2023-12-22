namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using System;
    using System.Collections;
    using System.Collections.Concurrent;
    using System.Collections.Frozen;
    using System.Collections.Generic;
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
        [Params(10, 100_000)]
        public int Iterations { get; set; }

        private SortedList<int, SomeClass> sortedListLookup;
        private Dictionary<int, SomeClass> dictionaryLookup;
        private SortedDictionary<int, SomeClass> sortedDictionaryLookup;
        private ConcurrentDictionary<int, SomeClass> concurrentDictionaryLookup;
        private OrderedDictionary orderedDictionary;
        private Hashtable hashTable;
        private FrozenDictionary<int, SomeClass> frozenDictionary;

        [GlobalSetup]
        public void GlobalSetup()
        {
            int len = 50;

            sortedListLookup = new SortedList<int, SomeClass>(len);
            dictionaryLookup = new Dictionary<int, SomeClass>(len);
            sortedDictionaryLookup = new SortedDictionary<int, SomeClass>();
            concurrentDictionaryLookup = new ConcurrentDictionary<int, SomeClass>();
            orderedDictionary = new OrderedDictionary();
            hashTable = new Hashtable();

            for (int i = 0; i < len; i++)
            {
                sortedListLookup.Add(i, new SomeClass());
                dictionaryLookup.Add(i, new SomeClass());
                sortedDictionaryLookup.Add(i, new SomeClass());
                concurrentDictionaryLookup.TryAdd(i, new SomeClass());
                orderedDictionary.Add(i, new SomeClass());
                hashTable.Add(i, new SomeClass());
            }

            frozenDictionary = FrozenDictionary.ToFrozenDictionary(dictionaryLookup);
        }

        [Benchmark(Baseline = true)]
        public long LookupUsingDictionary()
        {
            long result = 0;

            for (int i = 0; i < this.Iterations; i++)
            {
                for (int j = 0; j < sortedListLookup.Count; j++)
                {
                    SomeClass c = dictionaryLookup[j];
                    result += c.DoSomething();
                }
            }

            return result;
        }

        [Benchmark]
        public long LookupUsingSortedList()
        {
            long result = 0;

            for (int i = 0; i < this.Iterations; i++)
            {
                for (int j = 0; j < sortedListLookup.Count; j++)
                {
                    SomeClass c = sortedListLookup[j];
                    result += c.DoSomething();
                }
            }

            return result;
        }

        [Benchmark]
        public long LookupUsingSortedDictionary()
        {
            long result = 0;

            for (int i = 0; i < this.Iterations; i++)
            {
                for (int j = 0; j < sortedDictionaryLookup.Count; j++)
                {
                    SomeClass c = sortedDictionaryLookup[j];
                    result += c.DoSomething();
                }
            }

            return result;
        }

        [Benchmark]
        public long LookupUsingConcurrentDictionary()
        {
            long result = 0;

            for (int i = 0; i < this.Iterations; i++)
            {
                for (int j = 0; j < concurrentDictionaryLookup.Count; j++)
                {
                    SomeClass c = concurrentDictionaryLookup[j];
                    result += c.DoSomething();
                }
            }

            return result;
        }

        [Benchmark]
        public long LookupUsingOrderedDictionary()
        {
            long result = 0;

            for (int i = 0; i < this.Iterations; i++)
            {
                for (int j = 0; j < orderedDictionary.Count; j++)
                {
                    SomeClass c = (SomeClass)orderedDictionary[j];
                    result += c.DoSomething();
                }
            }

            return result;
        }

        [Benchmark]
        public long LookupUsingHashtable()
        {
            long result = 0;

            for (int i = 0; i < this.Iterations; i++)
            {
                for (int j = 0; j < hashTable.Count; j++)
                {
                    SomeClass c = (SomeClass)hashTable[j];
                    result += c.DoSomething();
                }
            }

            return result;
        }

        [Benchmark]
        public long LookupUsingFrozenDictionary()
        {
            long result = 0;

            for (int i = 0; i < this.Iterations; i++)
            {
                for (int j = 0; j < frozenDictionary.Count; j++)
                {
                    SomeClass c = frozenDictionary[j];
                    result += c.DoSomething();
                }
            }

            return result;
        }
    }
}
