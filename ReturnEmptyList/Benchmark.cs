namespace Test
{
    using BenchmarkDotNet.Attributes;
    using System.Collections.Generic;
    using System;
    using System.Linq;

    [MemoryDiagnoser]
    [MemoryRandomization]
    public class Benchmark
    {
        private const int Iterations = 100_000;

        [GlobalSetup]
        public void GlobalSetup()
        {
        }

        [Benchmark]
        public int ReturnEnumerableEmpty()
        {
            int sum = 0;
            for (int i = 0; i < Iterations; i++)
            {
                var result = IndicateEmptyWithEnumerableDotEmpty();
                sum += result.Count();
            }
            return sum;
        }

        [Benchmark]
        public int ReturnArrayEmpty()
        {
            int sum = 0;
            for (int i = 0; i < Iterations; i++)
            {
                var result = IndicateEmptyWithArrayDotEmpty();
                sum += result.Count();
            }
            return sum;
        }

        [Benchmark]
        public int ReturnNewArray()
        {
            int sum = 0;
            for (int i = 0; i < Iterations; i++)
            {
                var result = IndicateEmptyWithNewEmptyArray();
                sum += result.Count();
            }
            return sum;
        }

        [Benchmark(Baseline = true)]
        public int ReturnNull()
        {
            int sum = 0;
            for (int i = 0; i < Iterations; i++)
            {
                var result = IndicateEmptyWithNull();
                sum += result?.Count() ?? 0;
            }
            return sum;
        }

        [Benchmark]
        public int ReturnCollectionExpression()
        {
            int sum = 0;
            for (int i = 0; i < Iterations; i++)
            {
                var result = IndicateEmptyWithCollectionExpression();
                sum += result.Count();
            }
            return sum;
        }

        // Different methods for returning empty collections
        private IEnumerable<int> IndicateEmptyWithEnumerableDotEmpty()
        {
            return Enumerable.Empty<int>();
        }

        private IEnumerable<int> IndicateEmptyWithArrayDotEmpty()
        {
            return Array.Empty<int>();
        }

        private IEnumerable<int> IndicateEmptyWithNewEmptyArray()
        {
            return new int[0];
        }

        private IEnumerable<int> IndicateEmptyWithNull()
        {
            return null;
        }

        private IEnumerable<int> IndicateEmptyWithCollectionExpression()
        {
            return [];
        }
    }
}

