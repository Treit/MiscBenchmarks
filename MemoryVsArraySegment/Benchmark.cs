namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using System;
    using System.Collections.Generic;

    [MemoryDiagnoser]
    [ShortRunJob]
    public class Benchmark
    {
        private byte[] _array;

        [Params(3200, 32768, 33554432)]
        public int Size{ get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
        }

        [Benchmark]
        public int PaginateWithArraySegment()
        {
            Random r = new();
            _array = new byte[Size];
            r.NextBytes(_array);

            List<string> results = new(_array.Length / 32);

            foreach (var hash in EnumerateRecordsArraySegment())
            {
                results.Add(Convert.ToHexString(hash));
            }

            return results.Count;
        }

        [Benchmark]
        public int PaginateWithMemory()
        {
            Random r = new();
            _array = new byte[Size];
            r.NextBytes(_array);

            List<string> results = new(_array.Length / 32);

            foreach (var hash in EnumerateRecordsMemory())
            {
                results.Add(Convert.ToHexString(hash.Span));
            }

            return results.Count;
        }

        private IEnumerable<ArraySegment<byte>> EnumerateRecordsArraySegment()
        {
            for (int i = 0; i < _array.Length; i += 32)
            {
                yield return new ArraySegment<byte>(_array, i, 32);
            }
        }

        private IEnumerable<Memory<byte>> EnumerateRecordsMemory()
        {
            for (int i = 0; i < _array.Length; i += 32)
            {
                yield return new Memory<byte>(_array, i, 32);
            }
        }
    }
}
