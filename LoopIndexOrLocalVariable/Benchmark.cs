namespace Test
{
    using BenchmarkDotNet.Attributes;
    using System.Collections.Generic;

    public class Benchmark
    {
        [Params(10, 100, 1000, 100_000, 1_000_000)]
        public int Count { get; set; }

        private List<int> _data;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _data = new List<int>(Count);

            for (int i = 0; i < Count; i++)
            {
                _data.Add(i);
            }
        }

        [Benchmark]
        public long LoopUsingIndex()
        {
            long total = 0;

            for (int i = 0; i < _data.Count; i++)
            {
                total += _data[i] + _data[i] + _data[i] + _data[i];
            }

            return total;
        }

        [Benchmark(Baseline = true)]
        public long LoopUsingVariable()
        {
            long total = 0;
            int value;

            for (int i = 0; i < _data.Count; i++)
            {
                value = _data[i];
                total += value + value + value + value;
            }

            return total;
        }
    }
}
