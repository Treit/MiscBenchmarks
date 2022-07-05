namespace Test
{
    using BenchmarkDotNet.Attributes;
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics.X86;
    using System.Runtime.Intrinsics;

    public class Benchmark
    {
        [Params(1000, 100_000)]
        public int Count { get; set; }

        private int[] _array;
        private int[] _arraySorted;

        [GlobalSetup]
        public void GlobalSetup()
        {
            Random r = new Random();
            _array = new int[Count];
            _arraySorted = new int[Count];

            for (int i = 0; i < Count; i++)
            {
                int val = r.Next();
                _array[i] = val;
                _arraySorted[i] = val;
            }

            Array.Sort(_arraySorted);
        }

        [Benchmark]
        public long SumWithForEachUnsorted()
        {
            long result = 0;

            foreach (int val in _array)
            {
                result += val;
            }

            return result;
        }

        [Benchmark]
        public long SumWithForEachSorted()
        {
            long result = 0;

            foreach (int val in _arraySorted)
            {
                result += val;
            }

            return result;
        }

        [Benchmark]
        public int MaxWithForEachUnsorted()
        {
            int max = int.MinValue;

            foreach (int val in _array)
            {
                if (val > max)
                {
                    max = val;
                }
            }

            return max;
        }

        [Benchmark(Baseline = true)]
        public int MaxWithForEachSorted()
        {
            int max = int.MinValue;

            foreach (int val in _arraySorted)
            {
                if (val > max)
                {
                    max = val;
                }
            }

            return max;
        }

        [Benchmark]
        public int KoziMax()
        {
            int[] values = _array;
            ref int arrRef = ref values[0];
            nint arrLen = values.Length;
            if (values.Length == 1)
                return arrRef;
            Vector128<int> max = Unsafe.As<int, Vector128<int>>(ref arrRef);

            nint i = 0;
            do
            {
                var val = Unsafe.As<int, Vector128<int>>(ref Unsafe.Add(ref arrRef, i));
                var mask = Sse42.CompareGreaterThan(val, max);
                max = Sse41.BlendVariable(max, val, mask);
                i += 2;
            } while (i < (arrLen & ~1));

            var t = Sse41.Shuffle(max.AsInt32(), 0b0_01_11_10);
            var m = Sse42.CompareGreaterThan(t, max);
            max = Sse41.BlendVariable(max, t, m);

            if (i < arrLen)
            {
                var val = Vector128.CreateScalarUnsafe(Unsafe.Add(ref arrRef, i));
                var mask = Sse42.CompareGreaterThan(val, max);
                max = Sse41.BlendVariable(max, val, mask);
            }

            return max.ToScalar();
        }

        [Benchmark]
        public int KoziMaxSorted()
        {
            int[] values = _arraySorted;
            ref int arrRef = ref values[0];
            nint arrLen = values.Length;
            if (values.Length == 1)
                return arrRef;
            Vector128<int> max = Unsafe.As<int, Vector128<int>>(ref arrRef);

            nint i = 0;
            do
            {
                var val = Unsafe.As<int, Vector128<int>>(ref Unsafe.Add(ref arrRef, i));
                var mask = Sse42.CompareGreaterThan(val, max);
                max = Sse41.BlendVariable(max, val, mask);
                i += 2;
            } while (i < (arrLen & ~1));

            var t = Sse41.Shuffle(max.AsInt32(), 0b0_01_11_10);
            var m = Sse42.CompareGreaterThan(t, max);
            max = Sse41.BlendVariable(max, t, m);

            if (i < arrLen)
            {
                var val = Vector128.CreateScalarUnsafe(Unsafe.Add(ref arrRef, i));
                var mask = Sse42.CompareGreaterThan(val, max);
                max = Sse41.BlendVariable(max, val, mask);
            }

            return max.ToScalar();
        }
    }
}
