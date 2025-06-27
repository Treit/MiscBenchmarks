#nullable disable
using BenchmarkDotNet.Attributes;
using System.Collections;
using System.Security.Cryptography;

namespace RandomElementsBenchmark
{
    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(500)]
        public int SourceCount { get; set; }

        [Params(3)]
        public int SelectCount { get; set; }

        private IReadOnlyList<int> _source;
        private Dictionary<int, string> _dictionary;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _source = Enumerable.Range(0, SourceCount).ToArray();
            _dictionary = Enumerable.Range(0, SourceCount).ToDictionary(x => x, x => $"Value{x}");
        }

        [Benchmark]
        public IReadOnlyList<int> CryptographicRngWithHashSet()
        {
            return _source.GetRandomElementsCrypto(SelectCount);
        }

        [Benchmark]
        public IReadOnlyList<int> SharedRandomWithHashSet()
        {
            return _source.GetRandomElementsSharedRandom(SelectCount);
        }

        [Benchmark]
        public IReadOnlyList<int> SharedRandomWithBoolArray()
        {
            return _source.GetRandomElementsSharedRandomNoHashSet(SelectCount);
        }

        [Benchmark]
        public IReadOnlyList<int> SharedRandomWithStackAllocBoolArray()
        {
            return _source.GetRandomElementsStackAlloc(SelectCount);
        }

        [Benchmark]
        public IReadOnlyList<int> SharedRandomWithWithStackAllocBitSet()
        {
            return _source.GetRandomElementsStackAllocBitSet(SelectCount);
        }

        [Benchmark(Baseline = true)]
        public IReadOnlyList<int> SharedRandomWithBitArray()
        {
            return _source.GetRandomElementsBitArray(SelectCount);
        }

        //[Benchmark]
        public IReadOnlyList<int> KeyCollectionWithBitArray()
        {
            return _dictionary.Keys.GetRandomElementsFromKeyCollection(SelectCount);
        }

        //[Benchmark]
        public IReadOnlyList<int> KeyCollectionWithArrayContains()
        {
            return _dictionary.Keys.GetRandomElementsFromKeyCollectionWithArray(SelectCount);
        }

        //[Benchmark]
        public IReadOnlyList<int> AaronVariation()
        {
            return _dictionary.GetRandomDictKeys(SelectCount);
        }
    }

    public static class RandomExtensions
    {
        // Original implementation using cryptographic RNG
        public static IReadOnlyList<T> GetRandomElementsCrypto<T>(this IReadOnlyList<T> source, int count)
        {
            if (count > source.Count)
                throw new ArgumentOutOfRangeException(nameof(count), "Count must be less than the source count.");

            if (count == source.Count)
                return source;

            HashSet<int> selectedIndices = [];
            List<T> result = new(count);
            while (selectedIndices.Count < count)
            {
                var randomIndex = RandomNumberGenerator.GetInt32(source.Count);

                if (selectedIndices.Add(randomIndex))
                    result.Add(source[randomIndex]);
            }

            return result;
        }

        public static IReadOnlyList<T> GetRandomElementsSharedRandom<T>(this IReadOnlyList<T> source, int count)
        {
            if (count > source.Count)
                throw new ArgumentOutOfRangeException(nameof(count), "Count must be less than the source count.");

            if (count == source.Count)
                return source;

            HashSet<int> selectedIndices = [];
            List<T> result = new(count);
            while (selectedIndices.Count < count)
            {
                var randomIndex = Random.Shared.Next(source.Count);

                if (selectedIndices.Add(randomIndex))
                    result.Add(source[randomIndex]);
            }

            return result;
        }

        public static IReadOnlyList<T> GetRandomElementsSharedRandomNoHashSet<T>(this IReadOnlyList<T> source, int count)
        {
            if (count > source.Count)
                throw new ArgumentOutOfRangeException(nameof(count), "Count must be less than the source count.");

            if (count == source.Count)
                return source;

            List<T> result = new(count);
            bool[] selected = new bool[source.Count];

            while (result.Count < count)
            {
                var randomIndex = Random.Shared.Next(source.Count);

                if (!selected[randomIndex])
                {
                    selected[randomIndex] = true;
                    result.Add(source[randomIndex]);
                }
            }

            return result;
        }

        public static IReadOnlyList<T> GetRandomElementsStackAlloc<T>(this IReadOnlyList<T> source, int count)
        {
            if (count > source.Count)
                throw new ArgumentOutOfRangeException(nameof(count), "Count must be less than the source count.");

            if (count == source.Count)
                return source;

            List<T> result = new(count);

            // Use stackalloc for small arrays to avoid heap allocation
            const int maxStackAllocSize = 1024; // Reasonable limit for stack allocation
            if (source.Count <= maxStackAllocSize)
            {
                Span<bool> selected = stackalloc bool[source.Count];

                while (result.Count < count)
                {
                    var randomIndex = Random.Shared.Next(source.Count);

                    if (!selected[randomIndex])
                    {
                        selected[randomIndex] = true;
                        result.Add(source[randomIndex]);
                    }
                }
            }
            else
            {
                // Fall back to heap allocation for large arrays
                bool[] selected = new bool[source.Count];

                while (result.Count < count)
                {
                    var randomIndex = Random.Shared.Next(source.Count);

                    if (!selected[randomIndex])
                    {
                        selected[randomIndex] = true;
                        result.Add(source[randomIndex]);
                    }
                }
            }

            return result;
        }

        public static IReadOnlyList<T> GetRandomElementsStackAllocBitSet<T>(this IReadOnlyList<T> source, int count)
        {
            if (count > source.Count)
                throw new ArgumentOutOfRangeException(nameof(count), "Count must be less than the source count.");

            if (count == source.Count)
                return source;

            List<T> result = new(count);

            const int bitsPerUlong = 64;
            const int maxStackAllocSize = 1024 * 8;

            if (source.Count <= maxStackAllocSize)
            {
                int ulongCount = (source.Count + bitsPerUlong - 1) / bitsPerUlong;
                Span<ulong> bitSet = stackalloc ulong[ulongCount];

                while (result.Count < count)
                {
                    var randomIndex = Random.Shared.Next(source.Count);
                    int ulongIndex = randomIndex / bitsPerUlong;
                    int bitIndex = randomIndex % bitsPerUlong;
                    ulong mask = 1UL << bitIndex;

                    if ((bitSet[ulongIndex] & mask) == 0)
                    {
                        bitSet[ulongIndex] |= mask;
                        result.Add(source[randomIndex]);
                    }
                }
            }
            else
            {
                // Fall back to heap allocation for large arrays
                int ulongCount = (source.Count + bitsPerUlong - 1) / bitsPerUlong;
                ulong[] bitSet = new ulong[ulongCount];

                while (result.Count < count)
                {
                    var randomIndex = Random.Shared.Next(source.Count);
                    int ulongIndex = randomIndex / bitsPerUlong;
                    int bitIndex = randomIndex % bitsPerUlong;
                    ulong mask = 1UL << bitIndex;

                    if ((bitSet[ulongIndex] & mask) == 0)
                    {
                        bitSet[ulongIndex] |= mask;
                        result.Add(source[randomIndex]);
                    }
                }
            }

            return result;
        }

        public static IReadOnlyList<T> GetRandomElementsBitArray<T>(this IReadOnlyList<T> source, int count)
        {
            if (count > source.Count)
                throw new ArgumentOutOfRangeException(nameof(count), "Count must be less than the source count.");

            if (count == source.Count)
                return source;

            List<T> result = new(count);
            BitArray selected = new(source.Count);

            while (result.Count < count)
            {
                var randomIndex = Random.Shared.Next(source.Count);

                if (!selected[randomIndex])
                {
                    selected[randomIndex] = true;
                    result.Add(source[randomIndex]);
                }
            }

            return result;
        }

        public static IReadOnlyList<TKey> GetRandomElementsFromKeyCollection<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection keys, int targetAmount)
        {
            if (targetAmount > keys.Count)
                throw new ArgumentOutOfRangeException(nameof(targetAmount), "Target amount must be less than or equal to the key collection count.");

            if (targetAmount == keys.Count)
                return keys.ToArray();

            var indexes = GetRandomIndexesUpToCount(keys.Count, targetAmount);
            int current = 0;
            var enu = keys.GetEnumerator();
            var result = new List<TKey>(targetAmount);

            try
            {
                while (current < keys.Count && result.Count < targetAmount)
                {
                    enu.MoveNext();
                    if (indexes[current])
                    {
                        result.Add(enu.Current);
                    }
                    current++;
                }
            }
            finally
            {
                enu.Dispose();
            }

            return result;
        }

        public static IReadOnlyList<TKey> GetRandomElementsFromKeyCollectionWithArray<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection keys, int targetAmount)
        {
            if (targetAmount > keys.Count)
                throw new ArgumentOutOfRangeException(nameof(targetAmount), "Target amount must be less than or equal to the key collection count.");

            if (targetAmount == keys.Count)
                return keys.ToArray();

            var indexes = GetRandomIndexesArray(keys.Count, targetAmount);
            int current = 0;
            var enu = keys.GetEnumerator();
            var result = new List<TKey>(targetAmount);

            try
            {
                while (current < keys.Count && result.Count < targetAmount)
                {
                    enu.MoveNext();
                    if (indexes.Contains(current))
                    {
                        result.Add(enu.Current);
                    }
                    current++;
                }
            }
            finally
            {
                enu.Dispose();
            }

            return result;
        }

        public static IReadOnlyList<TKey> GetRandomDictKeys<TKey, TValue>(this Dictionary<TKey, TValue> dict, int targetCount) where TKey : notnull
        {
            return dict.Keys.Where(GetContainsChecker(dict.Count, targetCount)).ToArray();

            static Func<TKey, int, bool> GetContainsChecker(int dictCount, int targetCount)
            {
                var rng = Random.Shared;
                if (targetCount < 8) // random number idk
                {
                    int[] indexes = new int[targetCount];
                    for (int i = 0; i < targetCount; i++)
                    {
                        while (true)
                        {
                            var next = rng.Next(dictCount);
                            if (Array.IndexOf(indexes, next, 0, i) == -1)
                            {
                                indexes[i] = next;
                                break;
                            }
                        }
                    }

                    return (_, index) => Array.IndexOf(indexes, index) != -1;
                }
                else
                {
                    var indexes = new BitArray(dictCount);
                    for (int i = 0; i < targetCount; i++)
                    {
                        while (true)
                        {
                            var next = rng.Next(dictCount);
                            if (!indexes[next])
                            {
                                indexes[next] = true;
                                break;
                            }
                        }
                    }

                    return (_, index) => indexes[index];
                }
            }
        }

        private static BitArray GetRandomIndexesUpToCount(int totalCount, int targetAmount)
        {
            var selected = new BitArray(totalCount);
            var selectedCount = 0;

            while (selectedCount < targetAmount)
            {
                var randomIndex = Random.Shared.Next(totalCount);
                if (!selected[randomIndex])
                {
                    selected[randomIndex] = true;
                    selectedCount++;
                }
            }

            return selected;
        }

        private static int[] GetRandomIndexesArray(int totalCount, int targetAmount)
        {
            var selectedSet = new HashSet<int>();

            while (selectedSet.Count < targetAmount)
            {
                var randomIndex = Random.Shared.Next(totalCount);
                selectedSet.Add(randomIndex);
            }

            return selectedSet.ToArray();
        }
    }
}

#nullable restore
// Edited by AI 🤖