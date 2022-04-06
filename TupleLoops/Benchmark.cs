namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using System.Collections.Generic;

    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(3, 50, 1000)]
        public int Count { get; set; }

        private IList<(string column, int index)> _tuples { get; set; }

        private KeyValuePair<string, int>[] _tuples2 { get; set; }

        private (string column, int index)[] _tuples3 { get; set; }

        private IList<(string column, int index)> _tuples4 { get; set; }

        private List<(string column, int index)> _tuples5 { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            _tuples = new List<(string, int)>();
            _tuples2 = new KeyValuePair<string, int>[Count];
            _tuples3 = new (string, int)[Count];
            _tuples4 = new (string, int)[Count];
            _tuples5 = new List<(string, int)>();

            for (int i = 0; i < Count; i++)
            {
                _tuples.Add(new(i.ToString(), i));
                _tuples2[i] = new KeyValuePair<string, int>(i.ToString(), i);
                _tuples3[i] = new(i.ToString(), i);
                _tuples4[i] = new(i.ToString(), i);
                _tuples5.Add(new(i.ToString(), i));
            }
        }

        [Benchmark(Baseline = true)]
        public long ForEachOfIListOfValueTupleBackedByList()
        {
            long result = 0;

            for (int i = 0; i < Count; i++)
            {
                foreach (var (_, index) in _tuples)
                {
                    result += index;
                }
            }

            return result;
        }

        [Benchmark]
        public long ForEachOfArrayOfKeyValuePair()
        {
            long result = 0;

            for (int i = 0; i < Count; i++)
            {
                foreach (var kvp in _tuples2)
                {
                    result += kvp.Value;
                }
            }

            return result;
        }

        [Benchmark]
        public long ForEachOfArrayOfValueTuple()
        {
            long result = 0;

            for (int i = 0; i < Count; i++)
            {
                foreach (var (_, index) in _tuples3)
                {
                    result += index;
                }
            }

            return result;
        }

        [Benchmark]
        public long ForEachOfIListOfValueTupleBackedByArray()
        {
            long result = 0;

            for (int i = 0; i < Count; i++)
            {
                foreach (var (_, index) in _tuples4)
                {
                    result += index;
                }
            }

            return result;
        }

        [Benchmark]
        public long ForEachOfConcreteListOfValueTuple()
        {
            long result = 0;

            for (int i = 0; i < Count; i++)
            {
                foreach (var (_, index) in _tuples5)
                {
                    result += index;
                }
            }

            return result;
        }
    }
}
