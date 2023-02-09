using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Jobs;
    using System;
    using System.Diagnostics;
    using System.Numerics;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

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
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector128<byte> CreateShuffleMask(
            byte p15, byte p14, byte p13, byte p12,
            byte p11, byte p10, byte p9, byte p8,
            byte p7, byte p6, byte p5, byte p4,
            byte p3, byte p2, byte p1, byte p0)
        {
            return Vector128.Create(p15, p14, p13, p12, p11, p10, p9, p8, p7, p6, p5, p4, p3, p2, p1, p0);
        }

        [Benchmark]
        public long SumMultiDimensionalVectorAkari()
        {
            unsafe
            {
                Vector128<byte> rotateMask = CreateShuffleMask(4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0, 1, 2, 3);
                long sum = 0;
                Vector128<int> brrrr = Vector128<int>.Zero;
                fixed (byte* data = _mdim)
                {
                    int stride = Vector128<byte>.Count;
                    var simdIterationCount = (int)((Size * Size) / (float)stride);
                    int remainderCount = (Size * Size) - (simdIterationCount * stride);
                    byte* mutablePtr = data;

                    for (var i = 0; i < simdIterationCount; i++)
                    {
                        var bytes = Unsafe.Read<Vector128<byte>>(mutablePtr);
                        for (var j = 0; j < 4; j++)
                        {
                            brrrr = Sse41.Add(brrrr, Sse41.ConvertToVector128Int32(bytes));
                            bytes = Sse41.Shuffle(bytes, rotateMask);
                        }
                        
                        mutablePtr += stride;
                    }

                    for (var i = 0; i < Vector128<int>.Count; ++i)
                    {
                        sum += brrrr.GetElement(i);
                    }

                    for (var i = 0; i < remainderCount; i++)
                    {
                        sum += *mutablePtr;
                        mutablePtr++;
                    }
                }

                return sum;
            }
        }        
        
        [Benchmark]
        public long SumMultiDimensionalVector256Akari()
        {
            unsafe
            {
                long sum = 0;
                Vector256<uint> brrrr = Vector256<uint>.Zero;
                fixed (byte* data = _mdim)
                {
                    int stride = Vector256<byte>.Count;
                    var simdIterationCount = (int)((Size * Size) / (float)stride);
                    int remainderCount = (Size * Size) - (simdIterationCount * stride);
                    byte* mutablePtr = data;

                    for (var i = 0; i < simdIterationCount; i++)
                    {
                        var bytes = Unsafe.Read<Vector256<byte>>(mutablePtr);
                        (Vector256<ushort> upperShort, Vector256<ushort> lowerShort) = Vector256.Widen(bytes);
                        (Vector256<uint> upperUpperInt, Vector256<uint> upperLowerInt) = Vector256.Widen(upperShort);
                        (Vector256<uint> lowerUpperInt, Vector256<uint> lowerLowerInt) = Vector256.Widen(lowerShort);

                        brrrr = Vector256.Add(brrrr, upperUpperInt);
                        brrrr = Vector256.Add(brrrr, upperLowerInt);
                        brrrr = Vector256.Add(brrrr, lowerUpperInt);
                        brrrr = Vector256.Add(brrrr, lowerLowerInt);
                        
                        mutablePtr += stride;
                    }

                    for (var i = 0; i < Vector256<uint>.Count; ++i)
                    {
                        sum += brrrr.GetElement(i);
                    }

                    for (var i = 0; i < remainderCount; i++)
                    {
                        sum += *mutablePtr;
                        mutablePtr++;
                    }
                }

                return sum;
            }
        }        
        
        [Benchmark]
        public long SumMultiDimensionalVector256AkariNoFixed()
        {
            ref byte baseArr = ref MemoryMarshal.GetArrayDataReference(this._mdim);
            uint sum;
            Vector256<uint> brrrr = Vector256<uint>.Zero;
            int stride = Vector256<byte>.Count;
            var simdIterationCount = (int)((Size * Size) / (float)stride);
            int remainderCount = (Size * Size) - (simdIterationCount * stride);

            for (var i = 0; i < simdIterationCount; i++)
            {
                Vector256<byte> bytes = Vector256.LoadUnsafe(ref baseArr);
                (Vector256<ushort> upperShort, Vector256<ushort> lowerShort) = Vector256.Widen(bytes);
                (Vector256<uint> upperUpperInt, Vector256<uint> upperLowerInt) = Vector256.Widen(upperShort);
                (Vector256<uint> lowerUpperInt, Vector256<uint> lowerLowerInt) = Vector256.Widen(lowerShort);

                brrrr = Vector256.Add(brrrr, upperUpperInt);
                brrrr = Vector256.Add(brrrr, upperLowerInt);
                brrrr = Vector256.Add(brrrr, lowerUpperInt);
                brrrr = Vector256.Add(brrrr, lowerLowerInt);
                
                baseArr = ref Unsafe.Add(ref baseArr, (nint)stride);
            }

            sum = Vector256.Sum(brrrr);
            for (var i = 0; i < remainderCount; i++)
            {
                sum += baseArr;        
                baseArr = Unsafe.Add(ref baseArr, stride);
            }

            return sum;
        }        
        
        [Benchmark]
        public long SumMultiDimensionalVector256AkariNoFixedWithIntermediateShorts()
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            static void OffloadShortVector(ref Vector256<ushort> lowerIntermediate, ref Vector256<ushort> upperIntermediate, ref Vector256<uint> brrrr)
            {
                (Vector256<uint> t1Upper, Vector256<uint> t1Lower) = Vector256.Widen(lowerIntermediate);
                (Vector256<uint> t2Upper, Vector256<uint> t2Lower) = Vector256.Widen(upperIntermediate);
                brrrr = Vector256.Add(brrrr, t1Upper);
                brrrr = Vector256.Add(brrrr, t1Lower);
                brrrr = Vector256.Add(brrrr, t2Upper);
                brrrr = Vector256.Add(brrrr, t2Lower);
                
                lowerIntermediate = Vector256<ushort>.Zero;
                upperIntermediate = Vector256<ushort>.Zero;
            }

            ref byte baseArr = ref MemoryMarshal.GetArrayDataReference(this._mdim);
            uint sum;
            Vector256<uint> brrrr = Vector256<uint>.Zero;
            int stride = Vector256<byte>.Count;
            var simdIterationCount = (int)((Size * Size) / (float)stride);
            int remainderCount = (Size * Size) - (simdIterationCount * stride);
            
            Vector256<ushort> lowerIntermediate = Vector256<ushort>.Zero;
            Vector256<ushort> upperIntermediate = Vector256<ushort>.Zero;
            for (var i = 0; i < simdIterationCount; i++)
            {
                if (i % 256 == 0)
                {
                    OffloadShortVector(ref lowerIntermediate, ref upperIntermediate, ref brrrr);
                }
                
                Vector256<byte> bytes = Vector256.LoadUnsafe(ref baseArr);
                (Vector256<ushort> upperShort, Vector256<ushort> lowerShort) = Vector256.Widen(bytes);
                lowerIntermediate = Vector256.Add(lowerIntermediate, lowerShort);
                upperIntermediate = Vector256.Add(upperIntermediate, upperShort);
                
                baseArr = ref Unsafe.Add(ref baseArr, (nint)stride);
            }

            OffloadShortVector(ref lowerIntermediate, ref upperIntermediate, ref brrrr);
            sum = Vector256.Sum(brrrr);
            for (var i = 0; i < remainderCount; i++)
            {
                sum += baseArr;        
                baseArr = Unsafe.Add(ref baseArr, stride);
            }

            return sum;
        }        

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
    }
}