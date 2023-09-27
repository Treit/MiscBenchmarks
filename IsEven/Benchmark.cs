namespace Test
{
    using System;
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;

    [MemoryDiagnoser]
    public class Benchmark
    {
        private int[] _array;

        [Params(10, 100_000)]
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            _array = new int[Count];
            var r = new Random(Count);

            for (int i = 0; i < _array.Length; i++)
            {
                _array[i] = r.Next();
            }
        }

        [Benchmark]
        public ulong IsEvenUsingMod()
        {
            var arr = _array;
            var result = 0UL;

            for (int i = 0; i < _array.Length; i++)
            {
                if (IsEven(arr[i]))
                {
                    result++;
                }
            }

            return result;

            bool IsEven(int x)
            {
                return x % 2 == 0;
            }
        }

        [Benchmark]
        public ulong IsEvenlyxerexyl()
        {
            var arr = _array;
            var result = 0UL;

            for (int i = 0; i < _array.Length; i++)
            {
                if (IsEven(arr[i]))
                {
                    result++;
                }
            }

            return result;

            bool IsEven(int i)
            {
                string s = i.ToString();

                switch (s[s.Length - 1])
                {
                    case '2':
                    case '4':
                    case '6':
                    case '8':
                    case '0':
                        return true;
                    default:
                        return false;
                }
            }
        }
    }
}
