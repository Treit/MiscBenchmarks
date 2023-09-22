namespace Test
{
    using System;
    using System.Linq;
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;

    [MemoryDiagnoser]
    public class Benchmark
    {
        private int[] _array;

        [Params(100, 100_000)]
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            _array = new int[Count];
            var r = new Random(Count);

            for (int i = 0; i < _array.Length; i++)
            {
                _array[i] = r.Next(32, 127);
            }
        }

        [Benchmark]
        public long StaticLambda()
        {
            var x = static (int a) =>
            {
                return a + 1;
            };

            long result = 0;

            foreach (var item in _array)
            {
                result += x(item);
            }

            return result;
        }

        [Benchmark]
        public long NormalLambda()
        {
            var x = (int a) =>
            {
                return a + 1;
            };

            long result = 0;

            foreach (var item in _array)
            {
                result += x(item);
            }

            return result;
        }
    }
}
