namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using System.Collections.Frozen;
    using System.Collections.Generic;
    using System.Linq;

    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(1000)]
        public int Count { get; set; }

        private HashSet<string> _set;
        private FrozenSet<string> _frozenSet;
        private string _key;

        [GlobalSetup]
        public void GlobalSetup()
        {
            int len = Count;

            _set = new HashSet<string>(len);

            for (int i = 0; i < len; i++)
            {
                _set.Add(i.ToString());
            }

            _key = _set.ToList().Skip(len / 2).Take(1).First();

            _frozenSet = _set.ToFrozenSet();
        }

        [Benchmark(Baseline = true)]
        public bool LookupUsingSet()
        {
            return _set.Contains(_key);
        }

        [Benchmark]
        public bool LookupUsingFrozenSet()
        {
            return _frozenSet.Contains(_key);
        }
    }
}
