namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Jobs;
    using System;
    using System.Diagnostics;
    using System.Numerics;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Runtime.Intrinsics;

    [SimpleJob(RuntimeMoniker.Net70)]
    public class Benchmark
    {
        private byte[,] _mdim;
        private byte[][] _jagged;
        private byte[] _handrolled;

        [Params(1000)]
        public int Size { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            _mdim = new byte[Size, Size];
            _jagged = new byte[Size][];
            _handrolled = new byte[Size * Size];

            var r = new Random();

            for (int i = 0; i < Size; i++)
            {
                _jagged[i] = new byte[Size];

                for (int j = 0; j < Size; j++)
                {
                    byte b = (byte)r.Next(256);
                    _mdim[i, j] = b;
                    _jagged[i][j] = b;
                    _handrolled[j + i * Size] = b;
                }
            }
        }

        [Benchmark]
        public long SumJagged()
        {
            long result = 0;
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    result += _jagged[i][j];
                }
            }

            return result;
        }

        [Benchmark(Baseline = true)]
        public long SumMultiDimensional()
        {
            long result = 0;
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    result += _mdim[i, j];
                }
            }

            return result;
        }

        [Benchmark]
        public long SumMultiDimensionalReversedIndexes()
        {
            long result = 0;
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    result += _mdim[j, i];
                }
            }

            return result;
        }

        [Benchmark]
        public long SumJaggedReversedIndexes()
        {
            long result = 0;
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    result += _jagged[j][i];
                }
            }

            return result;
        }

        [Benchmark]
        public long SumJaggedOptimizedKozi()
        {
            var arr = _jagged;
            long result = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                var a = arr[i];
                for (int j = 0; j < a.Length; j++)
                {
                    result += a[j];
                }
            }

            return result;
        }

        [Benchmark]
        public long SumMultiDimensionalLocalVariableGoose()
        {
            long result = 0;

            var arr = _mdim;
            var size = Size;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    result += arr[i, j];
                }
            }

            return result;
        }

        [Benchmark]
        public long SumJaggedLocalVariableGoose()
        {
            long result = 0;
            var arr = _jagged;

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    result += _jagged[i][j];
                }
            }

            return result;
        }

        [Benchmark]
        public long SumWithReadOnlySpanKozi()
        {
            var span = MemoryMarshal.CreateReadOnlySpan(
                ref MemoryMarshal.GetArrayDataReference(_mdim),
                _mdim.Length);

            long n = 0;

            foreach (var b in span)
            {
                n += b;
            }

            return n;
        }

        [Benchmark]
        public long SumMultiDimensionalAkari()
        {
            unsafe
            {
                long sum = 0;
                fixed (byte* data = _mdim)
                {
                    byte* mutablePtr = data;

                    for (int i = 0; i < Size * Size; i++)
                    {
                        sum += *mutablePtr;
                        mutablePtr++;
                    }
                }

                return sum;
            }
        }

        // GIVES WRONG ANSWER 😬
        /*
        [Benchmark]
        public long SumMultiDimensionalVectorAkari()
        {
            unsafe
            {
                Debug.Assert(Vector<int>.IsSupported, "System.Numerics.Vector<int>.IsSupported");

                long sum = 0;
                Vector<int> brrrr = Vector<int>.Zero;
                fixed (byte* data = _mdim)
                {
                    int stride = Vector<int>.Count;
                    int simdIterationCount = (int)((Size * Size) / (float)stride);
                    var remainderCount = (Size * Size) - (simdIterationCount * stride);
                    byte* mutablePtr = data;

                    int test = 0;
                    for (int i = 0; i < simdIterationCount; i++)
                    {
                        test += sizeof(int) * stride;
                        var t = Unsafe.Read<Vector<int>>(mutablePtr);
                        brrrr += Unsafe.Read<Vector<int>>(mutablePtr);
                        mutablePtr += stride;
                    }

                    for (var i = 0; i < Vector<int>.Count; ++i)
                    {
                        sum += brrrr[i];
                    }

                    for (int i = 0; i < remainderCount; i++)
                    {
                        sum += *mutablePtr;
                        mutablePtr++;
                    }
                }

                return sum;
            }
        }
        */

        [Benchmark]
        public long SumHandrolledAkseli()
        {
            long result = 0;
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    result += _handrolled[j + i * Size];
                }
            }

            return result;
        }

        [Benchmark]
        public long SumHandRolledVectorizedAkseli()
        {
            var pin = _handrolled;

            ref byte r0 = ref MemoryMarshal.GetArrayDataReference(pin);

            Vector256<ulong> sum = Vector256<ulong>.Zero;

            int i = 0;
            for (; i < pin.Length - Vector256<byte>.Count; i += Vector256<byte>.Count)
            {
                var v0 = Vector256.Widen(Vector256.LoadUnsafe(ref Unsafe.Add(ref r0, i)));
                var vR = Vector256.Widen(v0.Lower);
                var vL = Vector256.Widen(v0.Upper);
                var vR1 = Vector256.Widen(vR.Lower);
                var vR2 = Vector256.Widen(vR.Upper);
                var vL1 = Vector256.Widen(vL.Lower);
                var vL2 = Vector256.Widen(vL.Upper);
                sum += vR1.Lower;
                sum += vR1.Upper;
                sum += vR2.Lower;
                sum += vR2.Upper;
                sum += vL1.Lower;
                sum += vL1.Upper;
                sum += vL2.Lower;
                sum += vL2.Upper;
            }

            long result = (long)Vector256.Sum(sum);

            for (; i < pin.Length; i++)
            {
                result += Unsafe.Add(ref r0, i);
            }

            return result;
        }
    }
}
