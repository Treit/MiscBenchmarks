namespace Test
{
    using BenchmarkDotNet.Attributes;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Benchmark
    {
        private List<string> _strings;

        [Params(10000)]
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            _strings = new List<string>(Count);
            for (int i = 0; i < Count; i++)
            {
                _strings.Add(Guid.NewGuid().ToString());
            }
        }

        [Benchmark(Baseline = true)]
        public int ReplaceNoStringComparison()
        {
            int total = 0;

            for (int i = 0; i < _strings.Count; i++)
            {
                total += _strings[i].Replace("-", string.Empty).Length; ;
            }

            return total;
        }

        [Benchmark]
        public int ReplaceStringComparisonOrdinal()
        {
            int total = 0;

            for (int i = 0; i < _strings.Count; i++)
            {
                total += _strings[i].Replace("-", string.Empty, StringComparison.Ordinal).Length; ;
            }

            return total;
        }

        [Benchmark]
        public int ReplaceStringComparisonOrdinalIgnoreCase()
        {
            int total = 0;

            for (int i = 0; i < _strings.Count; i++)
            {
                total += _strings[i].Replace("-", string.Empty, StringComparison.OrdinalIgnoreCase).Length; ;
            }

            return total;
        }
    }
}
