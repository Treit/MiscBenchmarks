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

        private Dictionary<int, string> _dictionary;
        private FrozenDictionary<int, string> _frozenDictionary;
        private int _key;

        [GlobalSetup]
        public void GlobalSetup()
        {
            int len = Count;

            _dictionary = new Dictionary<int, string>(len);

            for (int i = 0; i < len; i++)
            {
                _dictionary.Add(i, i.ToString());
            }

            _key = _dictionary.Keys.Skip(len / 2).Take(1).First();

            _frozenDictionary = FrozenDictionary.ToFrozenDictionary(_dictionary);
        }

        [Benchmark(Baseline = true)]
        public string LookupUsingDictionary()
        {
            return _dictionary[_key];
        }

        [Benchmark]
        public string LookupUsingFrozenDictionary()
        {
            return _frozenDictionary[_key];
        }
    }
}
