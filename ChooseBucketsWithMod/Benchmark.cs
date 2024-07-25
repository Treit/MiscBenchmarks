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
        [Params(2, 100_000)]
        public int BucketCount { get; set; }

        [Params(2, 1_000)]
        public int KeyCount { get; set; }

        private IList<long> _buckets;
        private IList<string> _keys;

        public IList<long> Buckets => _buckets;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _buckets = new long[BucketCount];
            _keys = new string[KeyCount];

            for (var i = 0; i < KeyCount; i++)
            {
                _keys[i] = i.ToString();
            }
        }

        [Benchmark]
        public void IndexViaAdditionAndTwoMods()
        {
            for (var i = 0; i < KeyCount; i++)
            {
                var str = _keys[i];
                var idx = (str.GetDeterministicHashCode() % _buckets.Count + _buckets.Count) % _buckets.Count;
                _buckets[idx]++;
            }
        }

        [Benchmark]
        public void IndexViaMathAbs()
        {
            for (var i = 0; i < KeyCount; i++)
            {
                var str = _keys[i];
                var idx = Math.Abs(str.GetDeterministicHashCode()) % _buckets.Count;
                _buckets[idx]++;
            }
        }

        [Benchmark]
        public void IndexViaHandlingNegativeExplicitly()
        {
            for (var i = 0; i < KeyCount; i++)
            {
                var str = _keys[i];
                var hash = str.GetDeterministicHashCode();
                var idx = (hash < 0 ? -hash : hash) % _buckets.Count;
                _buckets[idx]++;
            }
        }
    }
}
