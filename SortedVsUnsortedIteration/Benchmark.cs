namespace Test
{
    using BenchmarkDotNet.Attributes;
    using System;

    public class Benchmark
    {
        [Params(1000, 100_000)]
        public int Count { get; set; }

        private int[] _array;
        private int[] _arraySorted;

        [GlobalSetup]
        public void GlobalSetup()
        {
            Random r = new Random();
            _array = new int[Count];
            _arraySorted = new int[Count];

            for (int i = 0; i < Count; i++)
            {
                int val = r.Next();
                _array[i] = val;
                _arraySorted[i] = val;
            }

            Array.Sort(_arraySorted);
        }

        [Benchmark]
        public long SumWithForEachUnsorted()
        {
            long result = 0;

            foreach (int val in _array)
            {
                result += val;
            }

            return result;
        }

        [Benchmark]
        public long SumWithForEachSorted()
        {
            long result = 0;

            foreach (int val in _arraySorted)
            {
                result += val;
            }

            return result;
        }

        [Benchmark]
        public int MaxWithForEachUnsorted()
        {
            int max = int.MinValue;

            foreach (int val in _array)
            {
                if (val > max)
                {
                    max = val;
                }
            }

            return max;
        }

        [Benchmark(Baseline = true)]
        public int MaxWithForEachSorted()
        {
            int max = int.MinValue;

            foreach (int val in _arraySorted)
            {
                if (val > max)
                {
                    max = val;
                }
            }

            return max;
        }
    }
}
