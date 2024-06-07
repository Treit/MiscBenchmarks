namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using System;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Security.Cryptography;
    using System.Text;

    [MemoryDiagnoser]
    public class Benchmark
    {
        private string[] _values;

        [Params(500)]
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            _values = new string[Count];
            for (int i = 0; i < Count; i++)
            {
                _values[i] = i.ToString();
            }
        }

        [Benchmark(Baseline = true)]
        public string HashWithStringBuilder()
        {
            StringBuilder sb = new();
            foreach (string value in _values)
            {
                sb.Append(value);
            }

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashValue = sha256.ComputeHash(Encoding.UTF8.GetBytes(sb.ToString()));
                return Convert.ToBase64String(hashValue);
            }
        }

        [Benchmark]
        public string HashWithStringDotJoin()
        {
            var str = string.Join("", _values);

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashValue = sha256.ComputeHash(Encoding.UTF8.GetBytes(str));
                return Convert.ToBase64String(hashValue);
            }
        }

        [Benchmark]
        public string HashWithMemoryMarshalCastAndStream()
        {
            var stream = new MemoryStream(_values.Length * 10);

            foreach (var value in _values)
            {
                stream.Write(MemoryMarshal.Cast<char, byte>(value.AsSpan()));
            }

            stream.Position = 0;

            using (SHA256 sha256 = SHA256.Create())
            {
                var hashValue = sha256.ComputeHash(stream);
                return Convert.ToBase64String(hashValue);
            }
        }

        [Benchmark]
        public string HashWithMemoryMarshalCastAndStreamPrecomputeLength()
        {
            var len = 0;

            foreach (var value in _values)
            {
                len += value.Length * 2; // 2 bytes per char
            }

            var stream = new MemoryStream(len);

            foreach (var value in _values)
            {
                stream.Write(MemoryMarshal.Cast<char, byte>(value.AsSpan()));
            }

            stream.Position = 0;

            using (SHA256 sha256 = SHA256.Create())
            {
                var hashValue = sha256.ComputeHash(stream);
                return Convert.ToBase64String(hashValue);
            }
        }
    }
}
