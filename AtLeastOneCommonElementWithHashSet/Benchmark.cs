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
        private HashSet<string> _hashSetA;
        private HashSet<string> _hashSetB;

        [GlobalSetup]
        public void GlobalSetup()
        {
            var smallCount = 10;
            _array = new string[smallCount];
            _hashSetA = new HashSet<string>();
            _hashSetB = new HashSet<string>();

            for (int i = 0; i < smallCount; i++)
            {
                _hashSetA.Add(i.ToString());
                _array[i] = i.ToString();
            }

            for (int i = 0; i < Count; i++)
            {
                _hashSetB.Add(i.ToString());
            }
        }

        [Benchmark]
        public bool ArrayWalkAndHashSetLookupAndIEnumerableContains()
        {
            if (!_array.Any(x => _hashSetB.Contains(x, StringComparer.OrdinalIgnoreCase)))
            {
                return false;
            }

            return true;
        }

        [Benchmark]
        public bool ArrayWalkAndHashSetLookupAndHashSetContains()
        {
            if (!_array.Any(x => _hashSetB.Contains(x)))
            {
                return false;
            }

            return true;
        }

        [Benchmark(Baseline = true)]
        public bool HashSetOverlap()
        {
            if (!_hashSetA.Overlaps(_hashSetB))
            {
                return false;
            }

            return true;
        }
    }
}
