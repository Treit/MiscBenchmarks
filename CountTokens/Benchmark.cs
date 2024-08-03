namespace Test
{
    using BenchmarkDotNet.Attributes;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [MemoryDiagnoser]
    public class Benchmark
    {
        private static readonly char _separator = '-';

        [Params(1000)]
        public int Count { get; set; }

        private List<string> _delimitedStrings;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _delimitedStrings = new List<string>(Count);
            var random = new Random(Count);
            for (var i = 0; i < Count; i++)
            {
                if (random.Next() % 2 == 0)
                {
                    _delimitedStrings.Add($"{random.Next(0, 1000)}{_separator}{random.Next(0, 1000)}");
                }
                else
                {
                    _delimitedStrings.Add($"{random.Next(0, 1000)}{_separator}{random.Next(0, 1000)}{_separator}{random.Next(0, 1000)}");
                }
            }
        }

        [Benchmark]
        public long CountTokensUsingLinqCount()
        {
            var result = 0L;
            foreach (var s in _delimitedStrings)
            {
                var count = s.Count(c => c == _separator);
                if (count == 1)
                {
                    result++;
                }
            }

            return result;
        }

        [Benchmark(Baseline = true)]
        public long CountTokensUsingSpanCount()
        {
            var result = 0L;
            foreach (var s in _delimitedStrings)
            {
                var count = s.AsSpan().Count(_separator);
                if (count == 1)
                {
                    result++;
                }
            }

            return result;
        }

        [Benchmark]
        public long CountTokensUsingSplitAndLength()
        {
            var result = 0L;
            foreach (var s in _delimitedStrings)
            {
                var count = s.Split(_separator).Length;
                if (count == 2)
                {
                    result++;
                }
            }

            return result;
        }

        [Benchmark]
        public long CountTokensUsingSplitToListAndCount()
        {
            var result = 0L;
            foreach (var s in _delimitedStrings)
            {
                var count = s.Split(_separator).ToList().Count;
                if (count == 2)
                {
                    result++;
                }
            }

            return result;
        }
    }
}

