﻿namespace Test
{
    using BenchmarkDotNet.Attributes;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(10, 1000, 1_000_000)]
        public long ListSize { get; set; }

        [Params(5, 100)]
        public long RangeSize { get; set; }

        private List<long> _list;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _list = new List<long>(ListSize);
            var r = new Random(ListSize);

            for (long i = 0; i < ListSize; i++)
            {
                if (r.Next() % 2 == 0)
                {
                    _list.Add(i);
                }
                else
                {
                    _list.Add(-1);
                }
            }
        }

        [Benchmark]
        public long ToListDotGetRangeFirstN()
        {
            IEnumerable<long> list = _list;

            var start = 0;
            var end = Math.Min(start + RangeSize, ListSize);
            return list.ToList().GetRange(start, end - start).Max();
        }

        [Benchmark(Baseline = true)]
        public long LinqSkipTakeFirstN()
        {
            IEnumerable<long> list = _list;

            var start = 0;
            var end = Math.Min(start + RangeSize, ListSize);
            return list.Skip(start).Take(end - start).Max();
        }

        [Benchmark]
        public long ToListDotGetRangeLastN()
        {
            IEnumerable<long> list = _list;

            var start = ListSize - RangeSize;
            var end = Math.Min(start + RangeSize, ListSize);
            return list.ToList().GetRange(start, end - start).Max();
        }

        [Benchmark]
        public long LinqSkipTakeLastN()
        {
            IEnumerable<long> list = _list;

            var start = ListSize - RangeSize;
            var end = Math.Min(start + RangeSize, ListSize);
            return list.Skip(start).Take(end - start).Max();
        }
    }
}
