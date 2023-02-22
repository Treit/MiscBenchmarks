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
        [Params(100, 100_000)]
        public int Count { get; set; }

        private Hashtable _hashTable;
        private Dictionary<string, int> _dictionary;

        [GlobalSetup]
        public void GlobalSetup()
        {
            PopulateHashTable();
            PopulateDictionary();
        }

        [Benchmark(Baseline = true)]
        public void PopulateHashTable()
        {
            Random r = new Random(Count);

            _hashTable = new Hashtable(Count);

            for (int i = 0; i < Count; i++)
            {
                _hashTable[r.Next(0, 100000).ToString()] = i;
            }
        }

        [Benchmark]
        public void PopulateDictionary()
        {
            Random r = new Random(Count);

            _dictionary = new(Count);

            for (int i = 0; i < Count; i++)
            {
                _dictionary[r.Next(0, 100000).ToString()] =  i;
            }
        }

        [Benchmark]
        public long LookupHashTable()
        {
            Random r = new Random(Count);
            long result = 0;

            for (int i = 0; i < Count; i++)
            {
                var random = r.Next().ToString();

                if (_hashTable.ContainsKey(random))
                {
                    result += (int)_hashTable[random];
                }
            }

            return result;
        }

        [Benchmark]
        public long LookupDictionary()
        {
            Random r = new Random(Count);
            long result = 0;

            for (int i = 0; i < Count; i++)
            {
                var random = r.Next().ToString();

                if (_dictionary.ContainsKey(random))
                {
                    result += _dictionary[random];
                }
            }

            return result;
        }
    }
}
