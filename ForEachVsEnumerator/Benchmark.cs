namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(1000, 100_000)]
        public int Count { get; set; }

        private List<int> _data;
        private int[] _array;

        [GlobalSetup]
        public void GlobalSetup()
        {
            Random r = new Random();

            _data = new List<int>(Count);

            for (int i = 0; i < Count; i++)
            {
                _data.Add(r.Next());
                _array = _data.ToArray();
            }
        }

        [Benchmark]
        public int MaxUsingEnumeratorList()
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
        public int MaxUsingForEachList()
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

        [Benchmark]
        public int MaxUsingForLoopList()
        {
            int value = 0;

            for (int i = 0; i < _data.Count; i++)
            {
                int x = _data[i];

                if (x > value)
                {
                    value = x;
                }
            }

            return value;
        }

        [Benchmark]
        public int MaxUsingEnumeratorArray()
        {
            int value = int.MinValue;
            IEnumerator e = _array.GetEnumerator();

            while (e.MoveNext())
            {
                int x = (int)e.Current;

                if (x > value)
                {
                    value = x;
                }
            }

            return value;
        }

        public int MaxUsingForEachArray()
        {
            int value = 0;

            foreach (int x in _array)
            {
                if (x > value)
                {
                    value = x;
                }
            }

            return value;
        }

        [Benchmark]
        public int MaxUsingForLoopArray()
        {
            int value = 0;

            for (int i = 0; i < _array.Length; i++)
            {
                int x = _array[i];

                if (x > value)
                {
                    value = x;
                }
            }

            return value;
        }
    }
}
