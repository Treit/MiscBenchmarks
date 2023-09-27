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
        [Params(100, 10_000)]
        public int Count { get; set; }

        IEnumerable<string> _valuesEnumerable;
        List<string> _values;

        [GlobalSetup]
        public void GlobalSetup()
        {
            var tmp = new List<string>();
            for (int i = 0; i < Count; i++)
            {
                tmp.Add(Guid.NewGuid().ToString());
            }

            _values = tmp;
            _valuesEnumerable = tmp;
        }

        [Benchmark(Baseline = true)]
        public HashSet<string> NewHashSet()
        {
            return new HashSet<string>(_values);
        }

        [Benchmark]
        public HashSet<string> LinqToHashSet()
        {
            return _values.ToHashSet();
        }

        [Benchmark]
        public HashSet<string> LinqToImmutableHashSet()
        {
            return _values.ToHashSet();
        }

        [Benchmark]
        public HashSet<string> ManualAddViaLoop()
        {
            var hs = new HashSet<string>();
            foreach (var val in _values)
            {
                hs.Add(val);
            }

            return hs;
        }

        // Yes this is a silly benchmark, but this code was found in the real world,
        // even though Add will not actually throw when adding an existing entry 😐.
        [Benchmark]
        public HashSet<string> CollisionSafeImplementation()
        {
            // collision safe implementation
            var hashSet = new HashSet<string>();
            _values.ForEach(item => {
                try { hashSet.Add(item); }
                catch { }
            });
            return hashSet;
        }

        [Benchmark]
        public HashSet<string> CollisionSafeImplementationWithExtraToList()
        {
            var hashSet = new HashSet<string>();
            _valuesEnumerable.ToList().ForEach(item => {
                try { hashSet.Add(item); }
                catch { }
            });

            return hashSet;
        }
    }
}
