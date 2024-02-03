namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(10, 100_000)]
        public int Count { get; set; }

        private List<string> _listA;
        private List<string> _listB;

        [GlobalSetup]
        public void GlobalSetup()
        {
            Random r = new Random();

            _listA = new List<string>();
            _listB = new List<string>();

            for (int i = 0; i < Count; i++)
            {
                _listA.Add(RandomStringCreate(r, 50));
                _listB.Add(RandomStringCreate(r, 50));
            }

            // Ensure at least one match.
            _listB[Count / 2] = _listA[Count / 2];
        }

        [Benchmark(Baseline = true)]
        public bool IntersectAnyLinq()
        {
            return _listA.Intersect(_listB).Any();
        }

        [Benchmark]
        public bool IntersectAnyAsArray()
        {
            return _listA.IntersectAny(_listB);
        }

        static string RandomStringCreate(Random random, int maxLength)
        {
            const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz-_@!#$%^&*()+{}[]";
            var len = random.Next(maxLength);
            return string.Create(len, random, (buff, str) =>
            {
                for (int i = 0; i < buff.Length; i++)
                {
                    buff[i] = alphabet[random.Next(alphabet.Length)];
                }
            });
        }
    }

#nullable enable
    static class CollectionExtensions
    {
        /// <summary>
        /// Returns the collection as an array.
        /// If the collection is already an array, it will be returned,
        /// else creates a new array by copying the contents of the collection, which is an O(n) operation.
        /// </summary>
        /// <param name="source">The collection to return as a list</param>
        /// <typeparam name="T">The type of element in the collection.</typeparam>
        /// <returns>Array populated from the source collection or null.</returns>
        public static T[]? AsArray<T>(this ICollection<T>? source)
        {
            if (source == null)
            {
                return null;
            }

            if (source is T[] sourceConvertedAsArray)
            {
                return sourceConvertedAsArray;
            }

            T[] returnArray = new T[source.Count];
            source.CopyTo(returnArray, 0);
            return returnArray;
        }

        /// <summary>
        /// Determines there is a common element present in the two collections passed in by doing a case insensitive check.
        /// This is a fast, less allocation alternative to calling "Any" on the result of "Intersect".
        /// Returns false, If any of the collections parameter passed in is null.
        /// </summary>
        /// <param name="first">First collection.</param>
        /// <param name="second">Second collection.</param>
        /// <returns>True if a common element is present, else False.</returns>
        public static bool IntersectAny(this ICollection<string>? first, ICollection<string>? second)
        {
            // Working with a for loop on an array is faster than working with
            // an Enumerator(foreach). So we will first convert the ICollection to an array.
            // If the parameters are already an array, this method allocates zero bytes.

            string[]? firstArray = first.AsArray();
            string[]? secondArray = second.AsArray();

            if (firstArray == null || secondArray == null)
            {
                return false;
            }

            for (var i = 0; i < firstArray.Length; i++)
            {
                for (var j = 0; j < secondArray.Length; j++)
                {
                    if (firstArray[i].Equals(secondArray[j], StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
#nullable restore
}
