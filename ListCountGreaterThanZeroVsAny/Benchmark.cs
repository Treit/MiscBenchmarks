namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [MemoryDiagnoser]
    [ShortRunJob]
    public class Benchmark
    {
        [Params(10, 100_000)]
        public int Count { get; set; }

        public List<string> _strings;
        public IList<string> _toCheck;
        public IEnumerable<string> _toCheckEnumerable;

        [GlobalSetup]
        public void GlobalSetup()
        {
            this._strings = new List<string>(Count);
            for (int i = 0; i < this.Count; i++)
            {
                if (i % 10 == 0)
                {
                    _strings.Add("");
                }
                else
                {
                    _strings.Add(i.ToString());
                }
            }

            _toCheck = _strings.Where(x => x == "").ToList();
            _toCheckEnumerable = _toCheck.Select(x => x);
        }

        [Benchmark]
        public bool IListAnyResultsLinqAny()
        {
            return _toCheck.Any();
        }

        [Benchmark(Baseline = true)]
        public bool IListAnyResultsIListDotCount()
        {
            return _toCheck.Count > 0;
        }

        [Benchmark]
        public bool IListAnyResultsLinqCount()
        {
            return _toCheck.Count() > 0;
        }

        [Benchmark]
        public bool IListAnyResultsToListThenListDotCount()
        {
            return _toCheck.ToList().Count > 0;
        }

        [Benchmark]
        public bool IListAnyResultsPatternMatchOnCountPropertyKesa()
        {
            return _toCheck is { Count: > 0 };
        }

        [Benchmark]
        public bool IListAnyResultsPatternMatchOnListPatternAaron()
        {
            return _toCheck is [_, ..];
        }

        [Benchmark]
        public bool IEnumerableAnyResultsLinqAny()
        {
            return _toCheckEnumerable.Any();
        }

        [Benchmark]
        public bool IEnumerableAnyResultsToListThenListDotCount()
        {
            return _toCheckEnumerable.ToList().Count > 0;
        }        

        [Benchmark]
        public bool IEnumerableAnyResultsLinqCount()
        {
            return _toCheckEnumerable.Count() > 0;
        }        
    }
}
