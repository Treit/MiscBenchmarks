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
        [Params(1000)]
        public int Count { get; set; }

        public int ItemsPerDictionary { get; set; } = 100;

        private IList<Dictionary<string, string>> _dictionaries;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _dictionaries = new List<Dictionary<string, string>>(Count);

            for (int i = 0; i < Count; i++)
            {
                var dict = new Dictionary<string, string>();
                var n = Random.Shared.Next(100);

                if (n < 90)
                {

                    for (int j = 0; j < ItemsPerDictionary; j++)
                    {
                        dict.Add(j.ToString(), $"{i}_{j}");
                    }
                }

                _dictionaries.Add(dict);
            }
        }

        [Benchmark(Baseline = true)]
        public int CheckDictionaryEmptyUsingCount()
        {
            int nonemptyCount = 0;

            for (int i = 0; i < _dictionaries.Count; i++)
            {
                if (_dictionaries[i].Count > 0)
                {
                    nonemptyCount++;
                }
            }

            return nonemptyCount;
        }

        [Benchmark]
        public int CheckDictionaryEmptyUsingAny()
        {
            int nonemptyCount = 0;

            for (int i = 0; i < _dictionaries.Count; i++)
            {
                if (_dictionaries[i].Any())
                {
                    nonemptyCount++;
                }
            }

            return nonemptyCount;
        }
    }
}
