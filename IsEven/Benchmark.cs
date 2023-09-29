namespace Test
{
    using System;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Runtime.Intrinsics;
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;

    [MemoryDiagnoser]
    [DisassemblyDiagnoser(exportDiff: true, exportHtml: true)]
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
                _array[i] = r.Next(1, 15);
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
        public ulong IsEvenUsingINumberIsEvenInteger()
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

        [Benchmark]
        public ulong IsEvenCrabFuelCursedRecursiveVersion()
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
                if (i == 1)
                {
                    return false;
                }

                return !IsEven(--i);
            }
        }

        [Benchmark]
        public ulong IsEvenNotWorthUsingJester()
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
                return
                Convert.
                ToString(i, 2).
                PadLeft(32, '0').
                Select(c => c.ToString()).
                Select(int.Parse).
                Last().
                CompareTo(0).
                Equals(0);
            }

        public ulong IsEvenAkseli()
        {
            var array = _array;
            ref int start = ref MemoryMarshal.GetArrayDataReference(array);
            nint i = 0;
            Vector256<int> vsum = Vector256<int>.Zero;
            for (; i <= array.Length - Vector256<int>.Count; i += Vector256<int>.Count)
            {
                vsum += Vector256.LoadUnsafe(ref start, (nuint)i) & Vector256.Create(1);
            }
            int count = Vector256.Sum(vsum);
            for (; i < array.Length; i++)
            {
                count += array[i];
            }
            return (ulong)(array.Length - count);
        }
    }
}
