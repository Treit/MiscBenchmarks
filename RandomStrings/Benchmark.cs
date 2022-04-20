namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using System;
    using System.Linq;
    using System.Text;

    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(10, 100, 1000)]
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
        }

        [Benchmark(Baseline = true)]
        public long RandomStringsUsingStringBuilder()
        {
            long result = 0;
            var r = new Random(Count);

            for (int i = 0; i < Count; i++)
            {
                var s = GetRandomString(r, 50);
                result += s.Length;
            }

            return result;

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
        public long RandomStringsTCMVersion()
        {
            long result = 0;
            var r = new Random(Count);

            for (int i = 0; i < Count; i++)
            {
                var s = GenerateRandomString(50);
                result += s.Length;
            }

            return result;

            string GenerateRandomString(int length)
            {
                Random rnd = new Random((int)(DateTime.Now.Ticks % int.MaxValue));
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < length; i++)
                {
                    sb.Append((char)rnd.Next(32, 126));//32-126 usable ascii characters
                }
                return sb.ToString();
            }
        }

        [Benchmark]
        public long RandomStringsStackOverflowLinqVersion()
        {
            long result = 0;
            var r = new Random(Count);

            for (int i = 0; i < Count; i++)
            {
                var s = RandomString(r, 50);
                result += s.Length;
            }

            return result;

            static string RandomString(Random random, int length)
            {
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                return new string(Enumerable.Repeat(chars, length)
                    .Select(s => s[random.Next(s.Length)]).ToArray());
            }
        }
    }
}
