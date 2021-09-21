namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using System;
    using System.Collections.Generic;

    [ShortRunJob]
    public class Benchmark
    {
        [Params(100, 1000, 10_000, 100_000)]
        public int Count { get; set; }
        private List<string> _values;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _values = new List<string>(Count);

            Random r = new();

            for (int i = 0; i < this.Count; i++)
            {
                var str = i.ToString();

                if (r.Next(10) > 2)
                {
                    str = str + "garbage";
                }

                _values.Add(str);
            }
        }

        [Benchmark(Baseline = true)]
        public int CountUsingContains()
        {
            int garbageCount = 0;

            for (int i = 0; i < this.Count; i++)
            {
                if (_values[i].Contains("garbage"))
                {
                    garbageCount++;
                }
            }

            return garbageCount;
        }

        [Benchmark]
        public int CountUsingIndexOf()
        {
            int garbageCount = 0;

            for (int i = 0; i < this.Count; i++)
            {
                if (_values[i].IndexOf("garbage") != -1)
                {
                    garbageCount++;
                }
            }

            return garbageCount;
        }

        [Benchmark]
        public int CountUsingIndexOfOrdinal()
        {
            int garbageCount = 0;

            for (int i = 0; i < this.Count; i++)
            {
                if (_values[i].IndexOf("garbage", StringComparison.Ordinal) != -1)
                {
                    garbageCount++;
                }
            }

            return garbageCount;
        }
    }
}
