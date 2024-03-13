namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(100_000)]
        public int Count { get; set; }

        private const int DefaultInternalSetCapacity = 7;

        private List<int> _data;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _data = new List<int>(Count);

            var r = new Random(Count);

            for (int i = 0; i < Count; i++)
            {
               _data.Add(r.Next(10_001));
            }
        }

        [Benchmark]
        public long SumUsingForEach()
        {
            var result = 0L;
            var data = _data;

            foreach (int val in data)
            {
                result += val;
            }

            return result;
        }

        [Benchmark]
        public long SumUsingForEachCollectionMarshalAsSpan()
        {
            var result = 0L;
            var data = CollectionsMarshal.AsSpan(_data);

            foreach (int val in data)
            {
                result += val;
            }

            return result;
        }
    }
}
