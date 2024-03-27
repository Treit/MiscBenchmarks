namespace Test
{
    using BenchmarkDotNet.Attributes;
    using System.Collections.Generic;
    using System.Linq;

    public class Benchmark
    {
        private List<string> _strings;
        private string needle = "find_me";

        [Params(100, 1_000_000)]
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            _strings = new List<string>(Count);
            for (int i = 0; i < Count; i++)
            {
                _strings.Add(i.ToString());
            }

            _strings[_strings.Count - 1] = needle;
        }

        [Benchmark]
        public string WhereThenFirstOrDefault()
        {
            return _strings.Where(x => x == needle).FirstOrDefault();
        }

        [Benchmark(Baseline = true)]
        public string FirstOrDefault()
        {
            return _strings.FirstOrDefault(x => x == needle);
        }
    }
}
