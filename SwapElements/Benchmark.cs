namespace Test
{
    using System;
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;

    [MemoryDiagnoser]
    public class Benchmark
    {
        private char[] _array;

        [Params(10, 100_000)]
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            _array = new char[Count];
            var r = new Random(Count);

            for (int i = 0; i < _array.Length; i++)
            {
                _array[i] = (char)r.Next(32, 127);
            }
        }

        [Benchmark]
        public string SwapWithTempVariable()
        {
            for (int i = 0; i < _array.Length - 1; i++)
            {
                var tmp = _array[i];
                _array[i] = _array[i + 1];
                _array[i + 1] = tmp;
            }

            var str = new string(_array);
            return str;
        }

        [Benchmark]
        public string SwapWithLocalFunction()
        {
            for (int i = 0; i < _array.Length - 1; i++)
            {
                Swap(i, i + 1);
            }

            var str = new string(_array);
            return str;

            void Swap(int i, int j)
            {
                var temp = _array[i];
                _array[i] = _array[j];
                _array[j] = temp;
            }
        }

        [Benchmark]
        public string SwapWithTuple()
        {
            for (int i = 0; i < _array.Length - 1; i++)
            {
                (_array[i], _array[i + 1]) = (_array[i + 1], _array[i]);
            }

            var str = new string(_array);
            return str;
        }
    }
}
