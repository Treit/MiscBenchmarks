namespace Test
{
    using System;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Runtime.Intrinsics;
    using BenchmarkDotNet.Attributes;

    [MemoryDiagnoser]
    [DisassemblyDiagnoser(exportDiff: true, exportHtml: true)]
    public class Benchmark
    {
        private int[] _array;

        [Params(10000)]
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
        }

        [Benchmark]
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
                count += array[i] & 1;
            }
            return (ulong)(array.Length - count);
        }

        [Benchmark]
        public ulong IsEvenAkseliV2()
        {
            var array = _array;
            ref int start = ref MemoryMarshal.GetArrayDataReference(array);
            nint i = 0;
            Vector256<int> vsum = Vector256<int>.Zero;

            for (; i <= array.Length - Vector256<int>.Count * 4; i += Vector256<int>.Count * 4)
            {
                vsum += Vector256.LoadUnsafe(ref start, (nuint)i) & Vector256.Create(1);
                vsum += Vector256.LoadUnsafe(ref start, (nuint)(i + Vector256<int>.Count)) & Vector256.Create(1);
                vsum += Vector256.LoadUnsafe(ref start, (nuint)(i + Vector256<int>.Count * 2)) & Vector256.Create(1);
                vsum += Vector256.LoadUnsafe(ref start, (nuint)(i + Vector256<int>.Count * 3)) & Vector256.Create(1);
            }
            if (i <= array.Length - Vector256<int>.Count * 2)
            {
                vsum += Vector256.LoadUnsafe(ref start, (nuint)i) & Vector256.Create(1);
                vsum += Vector256.LoadUnsafe(ref start, (nuint)(i + Vector256<int>.Count)) & Vector256.Create(1);
                i += Vector256<int>.Count * 2;
            }
            if (i <= array.Length - Vector256<int>.Count)
            {
                vsum += Vector256.LoadUnsafe(ref start, (nuint)i) & Vector256.Create(1);
                i += Vector256<int>.Count;
            }
            int count = Vector256.Sum(vsum);
            for (; i < array.Length; i++)
            {
                count += array[i] & 1;
            }
            return (ulong)(array.Length - count);
        }
        
        [Benchmark]
        public ulong IsEvenSandra()
        {
            var array = _array;
            ref readonly int start = ref MemoryMarshal.GetArrayDataReference(array);

            Vector256<int> oddsum1 = Vector256<int>.Zero;
            Vector256<int> oddsum2 = Vector256<int>.Zero;
            Vector256<int> oddsum3 = Vector256<int>.Zero;
            Vector256<int> oddsum4 = Vector256<int>.Zero;

            var ander = Vector256.Create(1);

            nuint arrlen = (nuint)array.Length;
            nuint offset = 0;
            for (; offset < arrlen - 8 * 8; offset += 8 * 8)
            {
                Vector256<int> reg1, reg2, reg3, reg4;
                reg1 = Vector256.LoadUnsafe(in start, offset) & ander;
                reg2 = Vector256.LoadUnsafe(in start, offset + 8) & ander;
                oddsum1 += reg1;
                oddsum2 += reg2;

                reg3 = Vector256.LoadUnsafe(in start, offset + 8 * 2) & ander;
                reg4 = Vector256.LoadUnsafe(in start, offset + 8 * 3) & ander;
                oddsum3 += reg3;
                oddsum4 += reg4;

                reg1 = Vector256.LoadUnsafe(in start, offset + 8 * 4) & ander;
                reg2 = Vector256.LoadUnsafe(in start, offset + 8 * 5) & ander;
                oddsum1 += reg1;
                oddsum2 += reg2;

                reg3 = Vector256.LoadUnsafe(in start, offset + 8 * 6) & ander;
                reg4 = Vector256.LoadUnsafe(in start, offset + 8 * 7) & ander;
                oddsum3 += reg3;
                oddsum4 += reg4;
            }

            for (; offset < arrlen - 8; offset += 8)
            {
                oddsum1 += Vector256.LoadUnsafe(in start, offset) & ander;
            }

            int sum = Vector256.Sum(oddsum1 + oddsum2 + oddsum3 + oddsum4);

            for (; offset < arrlen; offset++)
            {
                sum += Unsafe.Add(ref Unsafe.AsRef(in start), offset) & 1;
            }

            return (ulong)(array.Length - sum);
        }
    }
}
