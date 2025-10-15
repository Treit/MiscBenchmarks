using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;

namespace DictionaryVsFrozenDictionaryPopulation
{
    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(1000, 100000)]
        public int Count { get; set; }

        private KeyValuePair<string, int>[] _sourceData;

        [GlobalSetup]
        public void GlobalSetup()
        {
            // Create source data that will be used to populate both dictionaries
            _sourceData = new KeyValuePair<string, int>[Count];

            for (int i = 0; i < Count; i++)
            {
                _sourceData[i] = new KeyValuePair<string, int>($"Key_{i:D8}", i);
            }
        }

        [Benchmark(Baseline = true)]
        public Dictionary<string, int> CreateDictionary()
        {
            var dict = new Dictionary<string, int>();

            foreach (var kvp in _sourceData)
            {
                dict[kvp.Key] = kvp.Value;
            }

            return dict;
        }

        [Benchmark]
        public Dictionary<string, int> CreateDictionaryWithCapacity()
        {
            var dict = new Dictionary<string, int>(Count);

            foreach (var kvp in _sourceData)
            {
                dict[kvp.Key] = kvp.Value;
            }

            return dict;
        }

        [Benchmark]
        public Dictionary<string, int> CreateDictionaryFromEnumerable()
        {
            return _sourceData.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        }

        [Benchmark]
        public FrozenDictionary<string, int> CreateFrozenDictionary()
        {
            var dict = new Dictionary<string, int>();

            foreach (var kvp in _sourceData)
            {
                dict[kvp.Key] = kvp.Value;
            }

            return dict.ToFrozenDictionary();
        }

        [Benchmark]
        public FrozenDictionary<string, int> CreateFrozenDictionaryFromEnumerable()
        {
            return _sourceData.ToFrozenDictionary(kvp => kvp.Key, kvp => kvp.Value);
        }

        [Benchmark]
        public FrozenDictionary<string, int> CreateFrozenDictionaryFromDictionary()
        {
            var dict = new Dictionary<string, int>(Count);

            foreach (var kvp in _sourceData)
            {
                dict[kvp.Key] = kvp.Value;
            }

            return dict.ToFrozenDictionary();
        }
    }
}
