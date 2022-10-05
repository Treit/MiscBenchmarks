using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Test
{
    public class PerfTest
    {
        [Params(4, 8)]
        public int PredicateCount { get; set; }

        [Benchmark]
        public void Test()
        {
            IEnumerable<int> rows = new int[] { 1234 };
            var predicates = new Func<int, bool>[PredicateCount];

            for (int i = 0; i < PredicateCount; i++)
            {
                predicates[i] = x => true;
            }

            foreach (var predicate in predicates)
            {
                rows = rows.AsParallel().Where(predicate);
            }

            var x = rows.ToList();
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
