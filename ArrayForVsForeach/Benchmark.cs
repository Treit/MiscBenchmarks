namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [ShortRunJob]
    public class Benchmark
    {
        private string[] _strings;

        [Params(10, 100, 1000, 100_000, 1_000_000)]
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            _strings = new string[Count];
            for (int i = 0; i < Count; i++)
            {
                if (i % 10 == 0)
                {
                    _strings[i] = ("");
                }
                else
                {
                    _strings[i] = i.ToString();
                }
            }
        }

        [Benchmark]
        public int ForLoopCount()
        {
            int count = 0;
            for (int i = 0; i < _strings.Length; i++)
            {
                if (_strings[i].Length == 0)
                {
                    count++;
                }
            }

            return count;
        }

        [Benchmark(Baseline = true)]
        public int ForEachLoopCount()
        {
            int count = 0;
            foreach (string s in _strings)
            {
                if (s.Length == 0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
