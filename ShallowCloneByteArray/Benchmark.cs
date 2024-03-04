namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using System;
    using System.Linq;

    [DisassemblyDiagnoser(exportDiff: true, exportHtml: true)]
    public class Benchmark
    {
        private byte[] _data;

        [Params(10, 100, 10_000)]
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            _data = new byte[Count];
            for (int i = 0; i < Count; i++)
            {
                _data[i] = (byte)(i % 256);
            }
        }

        [Benchmark(Baseline = true)]
        public byte[] CloneWithToArray()
        {
            return _data.ToArray();
        }

        [Benchmark]
        public byte[] CloneWithArrayCopy()
        {
            var result = new byte[_data.Length];
            Array.Copy(_data, result, _data.Length);
            return result;
        }

        [Benchmark]
        public byte[] CloneWithBufferBlockCopy()
        {
            var result = new byte[_data.Length];
            Buffer.BlockCopy(_data, 0, result, 0, _data.Length);
            return result;
        }
    }
}
