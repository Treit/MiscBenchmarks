namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Jobs;
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Numerics;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Runtime.Intrinsics;

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
        public long SumHandrolledAkseli()
        {
            var data = _handrolled;
            ref byte ptr = ref MemoryMarshal.GetArrayDataReference(data);
            Vector256<long> sum = Vector256<long>.Zero;
            Vector256<ushort> mask = Vector256.Create((ushort)0xff);
            Vector256<uint> widenMask = Vector256.Create((uint)ushort.MaxValue);
            nint i = 0;
            if (data.Length >= Vector256<byte>.Count * 4)
            {
                do
                {
                    Vector256<ushort> offload = Vector256<ushort>.Zero;
                    int index = 0;
                    while (index < 128 && i <= data.Length - Vector256<byte>.Count * 4)
                    {

                        Vector256<ushort> vec = Vector256.LoadUnsafe(ref Unsafe.Add(ref ptr, i)).AsUInt16();
                        offload += vec & mask;
                        offload += Vector256.ShiftRightLogical(vec, 8);

                        vec = Vector256.LoadUnsafe(ref Unsafe.Add(ref ptr, i + Vector256<byte>.Count)).AsUInt16();
                        offload += vec & mask;
                        offload += Vector256.ShiftRightLogical(vec, 8);

                        vec = Vector256.LoadUnsafe(ref Unsafe.Add(ref ptr, i + Vector256<byte>.Count * 2)).AsUInt16();
                        offload += vec & mask;
                        offload += Vector256.ShiftRightLogical(vec, 8);

                        vec = Vector256.LoadUnsafe(ref Unsafe.Add(ref ptr, i + Vector256<byte>.Count * 3)).AsUInt16();
                        offload += vec & mask;
                        offload += Vector256.ShiftRightLogical(vec, 8);

                        index += 4;
                        i += Vector256<byte>.Count * 4;

                    }
                    while (index < 128 && i <= data.Length - Vector256<byte>.Count)
                    {
                        index++;
                        Vector256<ushort> vec = Vector256.LoadUnsafe(ref Unsafe.Add(ref ptr, i)).AsUInt16();
                        offload += vec & mask;
                        offload += Vector256.ShiftRightLogical(vec, 8);
                        i += Vector256<byte>.Count;
                    }
                    (Vector256<long> lower, Vector256<long> upper) = Vector256.Widen((offload.AsUInt32() & widenMask).AsInt32());
                    sum += lower;
                    sum += upper;
                    (lower, upper) = Vector256.Widen(Vector256.ShiftRightLogical(offload.AsUInt32(), 16).AsInt32());
                    sum += lower;
                    sum += upper;

                } while (i <= data.Length - Vector256<byte>.Count);
            }
            long result = Vector256.Sum(sum);
            for (; i < data.Length; i++)
            {
                result += Unsafe.Add(ref ptr, i);
            }
            return result;
        }

        [Benchmark]
        public long SumJaggedLinq()
        {
            long result = 0;
            result = _jagged.Sum(x => x.Sum(x => x));

            return result;
        }

        [Benchmark]
        public long SumMultiDimensionalLinq()
        {
            long result = 0;
            result = _mdim.Cast<byte>().Sum(x => x);

            return result;
        }
    }
}
