namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using Microsoft.Diagnostics.Tracing.Parsers;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(10, 1000, 100_000)]
        public int Count { get; set; }

        private List<int> _values;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _values = new List<int>(Count);

            for (int i = 0; i < this.Count; i++)
            {
                _values.Add(i);
            }
        }

        [Benchmark(Baseline = true)]
        public int FisherYates()
        {
            Random r = new Random();

            for (int i = _values.Count - 1; i > 0; --i)
            {
                int n = r.Next(i, _values.Count - 1);
                Swap(i, n);
            }

            void Swap(int x, int y)
            {
                int tmp = _values[x];
                _values[x] = _values[y];
                _values[y] = tmp;
            }

            return _values[0];
        }

        [Benchmark]
        public int FisherYatesAscending()
        {
            Random r = new Random();

            for (int i = 0; i < _values.Count - 1; i++)
            {
                int n = r.Next(i, _values.Count - 1);
                Swap(i, n);
            }

            void Swap(int x, int y)
            {
                int tmp = _values[x];
                _values[x] = _values[y];
                _values[y] = tmp;
            }

            return _values[0];
        }

        [Benchmark]
        public int Sattolo()
        {
            Random r = new Random();

            for (int i = 0; i < _values.Count - 1; i++)
            {
                int n = r.Next(i + 1, _values.Count - 1);
                Swap(i, n);
            }

            void Swap(int x, int y)
            {
                int tmp = _values[x];
                _values[x] = _values[y];
                _values[y] = tmp;
            }

            return _values[0];
        }

        [Benchmark]
        public int LinqWithRandom()
        {
            Random r = new Random();

            _values = _values.OrderBy(_ => r.Next()).ToList();

            return _values[0];
        }

        [Benchmark]
        public int LinqWithGuid()
        {
            Random r = new Random();

            _values = _values.OrderBy(_ => Guid.NewGuid()).ToList();

            return _values[0];
        }

        [Benchmark]
        public int PLinqWithRandom()
        {
            Random r = new Random();

            _values = _values.AsParallel().OrderBy(_ => r.Next()).ToList();

            return _values[0];
        }

        [Benchmark]
        public int PLinqWithGuid()
        {
            Random r = new Random();

            _values = _values.AsParallel().OrderBy(_ => Guid.NewGuid()).ToList();

            return _values[0];
        }
    }
}
