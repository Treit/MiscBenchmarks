namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Jobs;
    using System.Collections.Generic;

    [SimpleJob(RuntimeMoniker.Net60)]
    [SimpleJob(RuntimeMoniker.Net70)]
    public class Benchmark
    {
        [Params(100, 1_000_000)]
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
