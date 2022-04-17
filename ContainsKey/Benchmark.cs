namespace Test
{
    using BenchmarkDotNet.Attributes;
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;

    public class Benchmark
    {
        [Params(10, 10000)]
        public int Count { get; set; }

        private Dictionary<string, int> _dict = new();
        private ConcurrentDictionary<string, int> _condict = new();

        [GlobalSetup]
        public void GlobalSetup()
        {
            var l = new List<int>(Count);

            for (int i = 0; i < Count; i++)
            {
                _dict.Add(i.ToString(), i);
                _condict.TryAdd(i.ToString(), i);
            }
        }

        [Benchmark]
        public int DictionaryContainsKey()
        {
            var r = new Random(Count);
            int found = 0;

            for (int i = 0; i < Count; i++)
            {
                if (_dict.ContainsKey(r.Next().ToString()))
                {
                    found++;
                }
            }

            return found;
        }

        [Benchmark]
        public int ConcurrentDictionaryContainsKey()
        {
            var r = new Random(Count);
            int found = 0;

            for (int i = 0; i < Count; i++)
            {
                if (_condict.ContainsKey(r.Next().ToString()))
                {
                    found++;
                }
            }

            return found;
        }

        [Benchmark]
        public int DictionaryKeysDotContains()
        {
            var r = new Random(Count);
            int found = 0;

            for (int i = 0; i < Count; i++)
            {
                if (_dict.Keys.Contains(r.Next().ToString()))
                {
                    found++;
                }
            }

            return found;
        }

        [Benchmark]
        public int ConcurrentDictionaryKeysDotContains()
        {
            var r = new Random(Count);
            int found = 0;

            for (int i = 0; i < Count; i++)
            {
                if (_condict.Keys.Contains(r.Next().ToString()))
                {
                    found++;
                }
            }

            return found;
        }
    }
}
