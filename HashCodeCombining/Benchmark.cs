namespace Test
{
    using BenchmarkDotNet.Attributes;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Benchmark
    {
        [Params(10, 1000)]
        public int Count { get; set; }

        private int[] _data;

        [GlobalSetup]
        public void GlobalSetup()
        {
            var l = new List<int>(Count);

            for (int i = 0; i < Count; i++)
            {
                l.Add(i);
            }

            _data = l.ToArray();
        }

        [Benchmark]
        public int BuiltInHashCodeCombine()
        {
            int result = 0;

            unchecked
            {
                for (int i = 0; i < Count; i++)
                {
                    result = HashCode.Combine(result, _data[i]);
                }
            }

            return result;
        }

        [Benchmark]
        public int CustomHashCodeCombine()
        {
            int result = 0;

            unchecked
            {
                for (int i = 0; i < Count; i++)
                {
                    result = DoCombineHashCodes(result, _data[i]);
                }
            }

            return result;
        }

        internal static int DoCombineHashCodes(int h1, int h2)
        {
            return (h1 << 5) + h1 ^ h2;
        }
    }
}
