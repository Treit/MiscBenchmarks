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

        [Benchmark(Baseline = true)]
        public long ClassicForLoop()
        {
            long result = 0;

            for (int i = 0; i < Count; i++)
            {
                result += _data[i];
            }

            return result;
        }

        [Benchmark]
        public long ForLoopPrefixIncrementInsideConditionCheck()
        {
            long result = 0;

            for (int i = -1; ++i < Count;)
            {
                result += _data[i];
            }

            return result;
        }

        [Benchmark]
        public long LoopUsingGoto()
        {
            long result = 0;

            int i = 0;
        loop:
            result += _data[i];

            if (++i < Count)
            {
                goto loop;
            }

            return result;
        }
    }
}
