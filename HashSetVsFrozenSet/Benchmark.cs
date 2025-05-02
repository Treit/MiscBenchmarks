namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using System.Collections.Frozen;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(1000)]
        public int Count { get; set; }

        private HashSet<string> _set;
        private FrozenSet<string> _frozenSet;
        private IReadOnlySet<string> _readOnlySet;
        private ReadOnlySet<string> _readOnlySetType;
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
            _readOnlySet = _set;
            _readOnlySetType = new ReadOnlySet<string>(_set);
        }

        [Benchmark(Baseline = true)]
        public bool LookupUsingHashSet()
        {
            return _set.Contains(_key);
        }

        [Benchmark]
        public bool LookupUsingFrozenSet()
        {
            return _frozenSet.Contains(_key);
        }

        [Benchmark]
        public bool LookupUsingIReadOnlySet()
        {
            return _readOnlySet.Contains(_key);
        }

        [Benchmark]
        public bool LookupUsingReadOnlySetType()
        {
            return _readOnlySetType.Contains(_key);
        }
    }
}
