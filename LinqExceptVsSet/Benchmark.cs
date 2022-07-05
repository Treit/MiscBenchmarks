namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(10, 100, 1000, 100_000, 1_000_000)]
        public int Count { get; set; }

        private List<string> _firstList;
        private List<string> _secondList;
        private HashSet<string> _firstSet;
        private HashSet<string> _secondSet;

        private Regex _re;
        private Regex _rec;

        [GlobalSetup]
        public void GlobalSetup()
        {
            Random r = new Random();
            _firstList = new List<string>(Count);
            _secondList = new List<string>(Count);

            for (int i = 0; i < this.Count; i++)
            {
                _firstList.Add(i.ToString());
                _secondList.Add(i.ToString());
            }

            _firstList.Add("a");
            _firstList.Add("b");
            _firstList.Add("c");
            _firstList.Add("d");

            _firstSet = new HashSet<string>(_firstList);
            _secondSet = new HashSet<string>(_secondList);
        }

        [Benchmark]
        public int SetDifferenceUsingLinq()
        {
            var result = _firstList.Except(_secondList).Count();
            return result;
        }

        [Benchmark(Baseline = true)]
        public int SetDifferenceUsingHashSet()
        {
            _firstSet.ExceptWith(_secondSet);
            return _firstSet.Count;
        }
    }
}
