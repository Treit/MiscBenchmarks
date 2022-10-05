using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace AsParallelBenchmark
{
    public class Keyword
    {
        public string Text { get; init; }

        public int Id { get; init; }

        public double Bid { get; init; }
    }

    public enum ParallelType { None, TypeA, TypeB, TypeC };

    [MemoryDiagnoser]
    public class PerfTest
    {
        [Params(100000)]
        public int ItemCount { get; set; }

        [Params(1, 4, 10)]
        public int PredicateCount { get; set; }

        private Keyword[] _keywords;

        Func<Keyword, bool>[] _predicates;

        [GlobalSetup]
        public void Setup()
        {
            var rnd = new Random();

            _keywords = new Keyword[ItemCount];

            for (int i = 0; i < ItemCount; i++)
            {
                _keywords[i] = new Keyword
                {
                    Text = "kw_" + rnd.Next(ItemCount),
                    Id = i,
                    Bid = rnd.NextDouble() * 10
                };
            }

            _predicates = new Func<Keyword, bool>[PredicateCount];

            for (int i = 0; i < PredicateCount; i++)
            {
                _predicates[i] = x => ContainsPredicate(x.Text, new[] { "12" });
            }
        }

        [Benchmark]
        public IList<Keyword> NoParallel() => RunFiltering(ParallelType.None);

        [Benchmark]
        public IList<Keyword> ParallelA() => RunFiltering(ParallelType.TypeA);

        [Benchmark]
        public IList<Keyword> ParallelB() => RunFiltering(ParallelType.TypeB);

        [Benchmark(Baseline = true)]
        public IList<Keyword> ParallelC() => RunFiltering(ParallelType.TypeC);

        public IList<Keyword> RunFiltering(ParallelType parallelType)
        {

            switch (parallelType)
            {
                case ParallelType.None:
                    {
                        IEnumerable<Keyword> rows = _keywords;

                        foreach (var predicate in _predicates)
                        {
                            rows = rows.Where(predicate);
                        }

                        return rows.ToList();
                    }
                case ParallelType.TypeA:
                    {
                        var rows = _keywords.AsParallel();

                        foreach (var predicate in _predicates)
                        {
                            rows = rows.Where(predicate);
                        }

                        return rows.ToList();
                    }
                case ParallelType.TypeB:
                    {
                        IEnumerable<Keyword> rows = _keywords.AsParallel();

                        foreach (var predicate in _predicates)
                        {
                            rows = rows.Where(predicate);
                        }

                        return rows.ToList();
                    }
                case ParallelType.TypeC:
                    {
                        IEnumerable<Keyword> rows = _keywords;

                        foreach (var predicate in _predicates)
                        {
                            rows = rows.AsParallel().Where(predicate);
                        }

                        return rows.ToList();
                    }
            }

            throw new InvalidOperationException("Unknown ParallelType");
        }

        private static bool ContainsPredicate(string str, IEnumerable<object> inputValues)
        {
            var pattern = ChangeType<string>(inputValues.First());

            return CultureInfo.InvariantCulture.CompareInfo.IndexOf(str, pattern, CompareOptions.IgnoreCase) >= 0;
        }

        public static T ChangeType<T>(object input)
        {
            return (T)Convert.ChangeType(input, typeof(T));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run(typeof(Program).Assembly);
        }
    }
}
