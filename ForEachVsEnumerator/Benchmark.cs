namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using System;
    using System.Collections.Generic;

    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(1000, 100_000, 1_000_000)]
        public int Count { get; set; }

        private List<int> _data;

        [GlobalSetup]
        public void GlobalSetup()
        {
            Random r = new Random();

            _data = new List<int>(Count);

            for (int i = 0; i < Count; i++)
            {
                _data.Add(r.Next());
            }
        }

        [Benchmark]
        public int MaxUsingEnumerator()
        {
            int value;
            using (IEnumerator<int> e = _data.GetEnumerator())
            {
                value = e.Current;
                while (e.MoveNext())
                {
                    int x = e.Current;
                    if (x > value)
                    {
                        value = x;
                    }
                }
            }

            return value;
        }

        [Benchmark(Baseline = true)]
        public int MaxUsingForEach()
        {
            int value = 0;

            foreach (int x in _data)
            {
                if (x > value)
                {
                    value = x;
                }
            }

            return value;
        }
    }
}
