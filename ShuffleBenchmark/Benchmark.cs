namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;

    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(100_000)]
        public int Count { get; set; }

        private List<int> _values;

        private RandomNumberGenerator _rng = RandomNumberGenerator.Create();
        private byte[] _rngbuff = new byte[4];
        private Random _random;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _values = new List<int>(Count);

            for (int i = 0; i < this.Count; i++)
            {
                _values.Add(i);
            }

            _random = new Random(_values.Count);
        }

        [Benchmark(Baseline = true)]
        public int FisherYates()
        {
            for (int i = _values.Count - 1; i > 0; --i)
            {
                int n = _random.Next(i, _values.Count);
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
            for (int i = 0; i < _values.Count - 1; i++)
            {
                int n = _random.Next(i, _values.Count);
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
        public int FisherYatesUsingStrongCryptoRandom()
        {
            for (int i = _values.Count - 1; i > 0; --i)
            {
                var n = RandomNumberGenerator.GetInt32(i, _values.Count);
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
            for (int i = 0; i < _values.Count - 1; i++)
            {
                int n = _random.Next(i + 1, _values.Count);
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
