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
    }
}
