namespace Test
{
    using BenchmarkDotNet.Attributes;
    using System;
    using System.Buffers;
    using System.Collections.Generic;
    using System.Security.Cryptography;
    using System.Text;

    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(4, 100, 1024)]
        public int Size { get; set; }

        List<string> _strings;
        ArrayPool<byte> _bytePool;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _strings = new List<string>(Size);
            _bytePool = ArrayPool<byte>.Create(100, 25);
            var r = new Random(Size);

            for (int i = 0; i < Size; i++)
            {
                _strings.Add(GetRandomString(r, 100));
            }

            static string GetRandomString(Random r, int maxLength)
            {
                var alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz-_@!#$%^&*()+{}[]";
                var len = r.Next(maxLength);
                var sb = new StringBuilder(len);

                for (int i = 0; i < len; i++)
                {
                    sb.Append(alphabet[r.Next(alphabet.Length)]);
                }

                return sb.ToString();
            }
        }

        [Benchmark]
        public IList<Guid> TestBuildingGuidsWithStackAlloc()
        {
            var guids = new List<Guid>();

            foreach (var str in _strings)
            {
                var g = HashDataWithStackAlloc(Encoding.UTF8.GetBytes(str));
                guids.Add(g);
            }

            return guids;
        }

        [Benchmark]
        public IList<Guid> TestBuildingGuidsWithArrayPool()
        {
            var guids = new List<Guid>();

            foreach (var str in _strings)
            {
                var g = HashDataWithArrayPool(Encoding.UTF8.GetBytes(str));
                guids.Add(g);
            }

            return guids;
        }

        [Benchmark]
        public IList<Guid> TestBuildingGuidsWithNewArray()
        {
            var guids = new List<Guid>();

            foreach (var str in _strings)
            {
                var g = HashDataWithNewArray(Encoding.UTF8.GetBytes(str));
                guids.Add(g);
            }

            return guids;
        }

        // From: https://twitter.com/terrajobst/status/1507808952146223106?s=20&t=dDqQV5fSVJ4PG0eiz4WBpQ
        private static Guid HashDataWithStackAlloc(ReadOnlySpan<byte> bytes)
        {
            var hashBytes = (Span<byte>)stackalloc byte[16];
            var written = MD5.HashData(bytes, hashBytes);
            return new Guid(hashBytes);
        }

        private Guid HashDataWithArrayPool(ReadOnlySpan<byte> bytes)
        {
            var hashBytes = _bytePool.Rent(16);
            var written = MD5.HashData(bytes, hashBytes);
            var result = new Guid(hashBytes.AsSpan(0, 16));
            _bytePool.Return(hashBytes);

            return result;
        }

        private static Guid HashDataWithNewArray(ReadOnlySpan<byte> bytes)
        {
            var hashBytes = new byte[16];
            var written = MD5.HashData(bytes, hashBytes);
            var result = new Guid(hashBytes);

            return result;
        }
    }
}
