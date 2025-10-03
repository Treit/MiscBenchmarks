using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using BenchmarkDotNet.Attributes;

namespace DictionaryRemoval
{
    [MemoryDiagnoser]
    public class Benchmarks
    {
        [Params(100, 10000)]
        public int Count { get; set; }

        private Dictionary<int, string> _dictionary;
        private ConcurrentDictionary<int, string> _concurrentDictionary;
        private ImmutableDictionary<int, string> _immutableDict;
        private int[] _keysToRemove;
        private Random _random;

        // Working copies for each iteration
        private Dictionary<int, string> _workingDictionary;
        private ConcurrentDictionary<int, string> _workingConcurrentDictionary;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _random = new Random(42);

            // Initialize test data - create dictionaries with Count * 2 items
            // so we have enough to remove Count items
            var totalItems = Count * 2;

            _dictionary = new Dictionary<int, string>();
            _concurrentDictionary = new ConcurrentDictionary<int, string>();
            var immutableBuilder = ImmutableDictionary.CreateBuilder<int, string>();

            // Populate with test data
            for (int i = 0; i < totalItems; i++)
            {
                var value = $"Value_{i}";
                _dictionary[i] = value;
                _concurrentDictionary[i] = value;
                immutableBuilder[i] = value;
            }

            _immutableDict = immutableBuilder.ToImmutable();

            // Create keys to remove - randomly select Count keys from the first half
            // This ensures all keys exist in all dictionaries
            var availableKeys = Enumerable.Range(0, totalItems);
            _keysToRemove = new int[Count];

            var keyArray = availableKeys.ToArray();
            for (int i = 0; i < Count; i++)
            {
                var randomIndex = _random.Next(keyArray.Length - i);
                _keysToRemove[i] = keyArray[randomIndex];
                // Swap the selected key to the end to avoid re-selection
                (keyArray[randomIndex], keyArray[keyArray.Length - 1 - i]) = (keyArray[keyArray.Length - 1 - i], keyArray[randomIndex]);
            }
        }

        [IterationSetup]
        public void IterationSetup()
        {
            // Create fresh copies for each iteration to avoid measuring copy cost in benchmarks
            _workingDictionary = new Dictionary<int, string>(_dictionary);
            _workingConcurrentDictionary = new ConcurrentDictionary<int, string>(_concurrentDictionary);
        }

        [Benchmark(Baseline = true)]
        public int RegularDictionary()
        {
            int removedCount = 0;

            foreach (var key in _keysToRemove)
            {
                if (_workingDictionary.Remove(key))
                {
                    removedCount++;
                }
            }

            return removedCount;
        }

        [Benchmark]
        public int ConcurrentDictionary()
        {
            int removedCount = 0;

            foreach (var key in _keysToRemove)
            {
                if (_workingConcurrentDictionary.TryRemove(key, out _))
                {
                    removedCount++;
                }
            }

            return removedCount;
        }

        [Benchmark]
        public int ImmutableDictionaryRemove()
        {
            var dict = _immutableDict;
            int removedCount = 0;

            foreach (var key in _keysToRemove)
            {
                if (dict.ContainsKey(key))
                {
                    dict = dict.Remove(key);
                    removedCount++;
                }
            }

            return removedCount;
        }

        [Benchmark]
        public int ImmutableDictionaryRemoveRange()
        {
            // Test bulk removal using RemoveRange - avoid ToList()
            var keysInDict = _keysToRemove.Where(k => _immutableDict.ContainsKey(k));
            var resultDict = _immutableDict.RemoveRange(keysInDict);

            // Return the number of items actually removed
            return _immutableDict.Count - resultDict.Count;
        }

        [Benchmark]
        public int RegularDictionaryWithContainsKey()
        {
            int removedCount = 0;

            foreach (var key in _keysToRemove)
            {
                if (_workingDictionary.ContainsKey(key))
                {
                    _workingDictionary.Remove(key);
                    removedCount++;
                }
            }

            return removedCount;
        }

        [Benchmark]
        public int RegularDictionaryBulkRemove()
        {
            int removedCount = 0;

            // Collect keys that exist, then remove them - avoid ToList()
            foreach (var key in _keysToRemove.Where(k => _workingDictionary.ContainsKey(k)))
            {
                _workingDictionary.Remove(key);
                removedCount++;
            }

            return removedCount;
        }
    }
}
