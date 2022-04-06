namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using System.Collections.Generic;

    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(10, 10000)]
        public int Count { get; set; }

        private KeyValuePair<string, int>[] _kvps { get; set; }

        private (string Column, int Index)[] _vtuples { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            _kvps = new KeyValuePair<string, int>[Count];
            _vtuples = new (string, int)[Count];

            for (int i = 0; i < Count; i++)
            {
                _kvps[i] = new KeyValuePair<string, int>(i.ToString(), i);
                _vtuples[i] = new(i.ToString(), i);
            }
        }

        [Benchmark]
        public long EnumerateValueTuplesUsingDestructuring()
        {
            long result = 0;

            foreach (var (_, index) in _vtuples)
            {
                result += index;
            }

            return result;
        }

        [Benchmark]
        public long EnumerateKvps()
        {
            long result = 0;

            foreach (var kvp in _kvps)
            {
                result += kvp.Value;
            }

            return result;
        }

        [Benchmark]
        public long EnumerateValueTuples()
        {
            long result = 0;

            foreach (var tup in _vtuples)
            {
                result += tup.Index;
            }

            return result;
        }
    }
}
