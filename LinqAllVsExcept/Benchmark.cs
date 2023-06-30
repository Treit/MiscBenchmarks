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
        [Params(10, 1000, 10_000)]
        public int Count { get; set; }

        private List<string> _firstList;
        private List<string> _secondList;

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
        }

        [Benchmark]
        public bool VerifySubsetUsingLinqAll()
        {
            var result = _firstList.All(x => _secondList.Any(y => y == x));
            return result;
        }

        [Benchmark(Baseline = true)]
        public bool VerifySubsetUsingLinqExcept()
        {
            var result = _firstList.Except(_secondList).Any();
            return !result;
        }
    }
}
