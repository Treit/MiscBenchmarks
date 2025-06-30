namespace ShuffleRandomVsSecure
{
    using BenchmarkDotNet.Attributes;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;

    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(100, 10000)]
        public int Count { get; set; }

        [Params(50, -1)] // 50 for partial shuffle, -1 for full shuffle
        public int MaxItems { get; set; }

        private List<int>? _sourceData;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _sourceData = Enumerable.Range(1, Count).ToList();
        }

        [Benchmark]
        public List<int> ShuffleWithSecureRandom()
        {
            return ShuffleSecure(_sourceData, MaxItems).ToList();
        }

        [Benchmark(Baseline = true)]
        public List<int> ShuffleWithSystemRandom()
        {
            return ShuffleSystemRandom(_sourceData, MaxItems).ToList();
        }

        private static IEnumerable<T> ShuffleSecure<T>(IEnumerable<T>? source, int maxItems)
        {
            if (source is null)
                return Enumerable.Empty<T>();

            List<T> list = new(source);
            int n = list.Count;

            for (int i = n - 1; i > 0; i--)
            {
                int j = RandomNumberGenerator.GetInt32(i + 1);
                (list[i], list[j]) = (list[j], list[i]);
            }

            return maxItems >= 0 && maxItems <= list.Count ? list.Take(maxItems) : list;
        }

        private static IEnumerable<T> ShuffleSystemRandom<T>(IEnumerable<T>? source, int maxItems)
        {
            if (source is null)
                return Enumerable.Empty<T>();

            List<T> list = new(source);
            int n = list.Count;

            for (int i = n - 1; i > 0; i--)
            {
                int j = Random.Shared.Next(i + 1);
                (list[i], list[j]) = (list[j], list[i]);
            }

            return maxItems >= 0 && maxItems <= list.Count ? list.Take(maxItems) : list;
        }
    }
}

// Edited by AI 🤖
