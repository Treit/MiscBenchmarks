namespace Test
{
    using System.Collections.Generic;
    using System.Linq;
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;

    [MemoryDiagnoser]
    public class Benchmark
    {
        private IEnumerable<string> _strings;

        [Params(10, 100_000)]
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            var strings = new string[Count];
            _strings = strings;

            for (int i = 0; i < Count; i++)
            {
                if (i % 10 == 0)
                {
                    strings[i] = ("");
                }
                else
                {
                    strings[i] = i.ToString();
                }
            }
        }

        [Benchmark]
        public bool ToArrayDotLengthGreaterThanZero()
        {
            return _strings.Where(x => x.Length > 0).ToArray().Length > 0;
        }

        [Benchmark]
        public bool LinqCountGreaterThanZero()
        {
            return _strings.Where(x => x.Length > 0).Count() > 0;
        }

        [Benchmark(Baseline = true)]
        public bool Any()
        {
            return _strings.Any(x => x.Length > 0);
        }
    }
}
