namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using System;
    using System.Linq;

    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(10_000)]
        public int Count { get; set; }

        private byte[] _bufferA;
        private byte[] _bufferB;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _bufferA = new byte[Count];
            _bufferB = new byte[Count];
        }

        [Benchmark(Baseline = true)]
        public bool CompareNormal()
        {
            return DoCompareNormal(_bufferA, _bufferB);
        }

        [Benchmark]
        public bool CompareUnsafeHandRolled()
        {
            return Compare(_bufferA, _bufferB);
        }

        [Benchmark]
        public bool CompareSpanSequenceEqual()
        {
            return _bufferA.AsSpan().SequenceEqual(_bufferB);
        }

        static bool DoCompareNormal(byte[] x, byte[] y)
        {
            if (x.Length != y.Length)
            {
                return false;
            }

            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] != y[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static bool Compare(byte[] x, byte[] y)
        {
            if (x == null && y == null)
            {
                return true;
            }
            else if (x == null || y == null)
            {
                return false;
            }

            return Compare(x, x.Length, y, y.Length);
        }

        private unsafe static bool Compare(byte[] x, int xLength, byte[] y, int yLength)
        {
            if (x == null || y == null || xLength != yLength)
            {
                return false;
            }

            fixed (byte* px = x, py = y)
            {
                byte* ex = px, ey = py;
                int l = xLength;
                for (int i = 0; i < l / 8; i++, ex += 8, ey += 8)
                {
                    if (*((long*)ex) != *((long*)ey))
                    {
                        return false;
                    }
                }

                if ((l & 4) != 0)
                {
                    if (*((int*)ex) != *((int*)ey))
                    {
                        return false;
                    }
                    ex += 4;
                    ey += 4;
                }

                if ((l & 2) != 0)
                {
                    if (*((short*)ex) != *((short*)ey))
                    {
                        return false;
                    }
                    ex += 2;
                    ey += 2;
                }

                if ((l & 1) != 0)
                {
                    if (*ex != *ey)
                    {
                        return false;
                    }
                }

                return true;
            }
        }
    }
}
