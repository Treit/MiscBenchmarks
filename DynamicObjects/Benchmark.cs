namespace Test
{
    using BenchmarkDotNet.Attributes;
    using System;

    [MemoryDiagnoser]
    public class Benchmark
    {
        private byte[][] _jagged;
        private dynamic[][] _dynamicjagged;

        [Params(1024)]
        public int Size { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
        }

        [Benchmark]
        public void InitJaggedArray()
        {
            _jagged = new byte[Size][];

            for (int i = 0; i < Size; i++)
            {
                _jagged[i] = new byte[Size];

                for (int j = 0; j < Size; j++)
                {
                    _jagged[i][j] = 0xFF;
                }
            }
        }

        [Benchmark]
        public void InitDynamicJaggedArray()
        {
            _dynamicjagged = new dynamic[Size][];

            for (int i = 0; i < Size; i++)
            {
                _dynamicjagged[i] = new dynamic[Size];

                for (int j = 0; j < Size; j++)
                {
                    _dynamicjagged[i][j] = 0xFF;
                }
            }
        }
    }
}
