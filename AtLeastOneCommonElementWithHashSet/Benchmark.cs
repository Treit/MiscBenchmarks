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
        [Params(100)]
        public int Count { get; set; }

        private string[] _array;
        private string[] _arrayWithNoOverlap;
        private HashSet<string> _hashSet;
        private HashSet<string> _hashSetWithNoOverlap;

        [GlobalSetup]

        public void GlobalSetup()
        {
            var smallCount = 10;
            _array = new string[smallCount];
            _arrayWithNoOverlap = new string[smallCount];
            _hashSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            _hashSetWithNoOverlap = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            for (int i = 0; i < smallCount; i++)
            {
                var str = $"string {i}";
                _array[i] = str;
                _arrayWithNoOverlap[i] = $"{str}!!!";
                _hashSetWithNoOverlap.Add($"{str}!!!");
            }

            for (int i = 0; i < Count; i++)
            {
                var str = $"string {i}";
                _hashSet.Add(str);
            }
        }

        [Benchmark]
        public bool ArrayWalkAndHashSetLookupWithIEnumerableContains()
        {
            if (!_array.Any(x => _hashSet.Contains(x, StringComparer.OrdinalIgnoreCase)))
            {
                return false;
            }

            return true;
        }

        [Benchmark]
        public bool ArrayWalkAndHashSetLookupWithIEnumerableContainsNoOverlap()
        {
            if (!_arrayWithNoOverlap.Any(x => _hashSet.Contains(x, StringComparer.OrdinalIgnoreCase)))
            {
                return false;
            }

            return true;
        }

        [Benchmark]
        public bool ArrayWalkAndHashSetLookupWithHashSetContains()
        {
            if (!_array.Any(x => _hashSet.Contains(x)))
            {
                return false;
            }

            return true;
        }

        [Benchmark]
        public bool ArrayWalkAndHashSetLookupWithHashSetContainsNoOverlap()
        {
            if (!_arrayWithNoOverlap.Any(x => _hashSet.Contains(x)))
            {
                return false;
            }

            return true;
        }

        [Benchmark(Baseline = true)]
        public bool HashSetOverlapsMethod()
        {
            if (!_hashSet.Overlaps(_array))
            {
                return false;
            }

            return true;
        }

        [Benchmark]
        public bool HashSetOverlapsMethodWithNoOverlap()
        {
            if (!_hashSet.Overlaps(_arrayWithNoOverlap))
            {
                return false;
            }

            return true;
        }
    }
}
