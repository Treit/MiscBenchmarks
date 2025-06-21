namespace ImmutableArrayVsReadOnlyList
{    using BenchmarkDotNet.Attributes;
    using System;
    using System.Buffers;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Linq;

    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(10, 100_000)]
        public int Iterations { get; set; }

        private int[] _sourceData = null!;
        private const int DataSize = 1000;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _sourceData = Enumerable.Range(0, DataSize).ToArray();
        }

        [Benchmark]
        public long GetAsImmutableArray()
        {
            long sum = 0;

            for (int i = 0; i < Iterations; i++)
            {
                var immutableArray = GetDataAsImmutableArray();
                sum += immutableArray.Length;
            }

            return sum;
        }

        [Benchmark(Baseline = true)]
        public long GetAsReadOnlyList()
        {
            long sum = 0;

            for (int i = 0; i < Iterations; i++)
            {
                var readOnlyList = GetDataAsReadOnlyList();
                sum += readOnlyList.Count;
            }

            return sum;
        }

        private ImmutableArray<int> GetDataAsImmutableArray()
        {
            return _sourceData.ToImmutableArray();
        }

        private IReadOnlyList<int> GetDataAsReadOnlyList()
        {
            return _sourceData;
        }
    }
}
