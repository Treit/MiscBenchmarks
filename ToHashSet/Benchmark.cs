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

        List<string> _values = new();

        [GlobalSetup]
        public void GlobalSetup()
        {
            for (int i = 0; i < Count; i++)
            {
                _values.Add(Guid.NewGuid().ToString());
            }
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
    }
}
