namespace Test
{
    using System;
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;

    [MemoryDiagnoser]
    public class Benchmark
    {
        private int[] _array;

        [Params(100_000)]
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

        [Benchmark(Baseline = true)]
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
        public ulong IsEvenUsingINumberIsEventInteger()
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
                return int.IsEvenInteger(i);
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

        [Benchmark]
        public ulong IsEvenMrCarrot()
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

            unsafe bool IsEven(int i)
            {
                i &= 1;
                return !(*((bool*)&i));
            }
        }

        [Benchmark]
        public ulong IsEvenAaron()
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
                return (~i & 1) == 1;
            }
        }

        [Benchmark]
        public ulong IsEvenAaronUnsafeBitConverter()
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

            unsafe bool IsEven(int i)
            {
                i &= 1;
                return !((bool*)&i)[BitConverter.IsLittleEndian ? 0 : 3];
            }
        }
    }
}
