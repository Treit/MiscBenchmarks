namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(1000, 100_000)]
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
        }

        [Benchmark(Baseline = true)]
        public long EnumerateUsingEnumerableAndForEach()
        {
            long result = 0;

            foreach (var number in GetNumbers())
            {
                result += number;
            }

            return result;
        }

        [Benchmark]
        public long EnumerateUsingToListAndForEach()
        {
            long result = 0;

            foreach (var number in GetNumbers().ToList())
            {
                result += number;
            }

            return result;
        }

        IEnumerable<int> GetNumbers()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return i;
            }
        }
    }
}
