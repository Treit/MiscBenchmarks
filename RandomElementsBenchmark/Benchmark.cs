#nullable disable
using BenchmarkDotNet.Attributes;
using System.Collections;
using System.Security.Cryptography;

namespace RandomElementsBenchmark
{
    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(20, 1000)]
        public int SourceCount { get; set; }

        [Params(3, 50)]
        public int SelectCount { get; set; }

        private IReadOnlyList<int> _source;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _source = Enumerable.Range(0, SourceCount).ToArray();
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

        [Benchmark(Baseline = true)]
        public IReadOnlyList<int> SharedRandomWithWithStackAllocBitSet()
        {
            return _source.GetRandomElementsStackAllocBitSet(SelectCount);
        }

        [Benchmark]
        public IReadOnlyList<int> SharedRandomWithBitArray()
        {
            return _source.GetRandomElementsBitArray(SelectCount);
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
    }
}

#nullable restore