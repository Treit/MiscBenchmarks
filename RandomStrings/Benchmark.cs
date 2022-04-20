namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using BenchmarkDotNet.Order;
    using System;
    using System.Linq;
    using System.Text;

    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    public class Benchmark
    {
        public static Random random;

        [Params(100)]
        public int Count { get; set; }

        [Params(100)]
        public int MaxLen { get; set; }


        [GlobalSetup]
        public void GlobalSetup()
        {
            random = new Random(Count);
        }

        [Benchmark(Baseline = true)]
        public long RandomStringsUsingStringBuilder()
        {
            long result = 0;
            var r = new Random(Count);

            for (int i = 0; i < Count; i++)
            {
                var s = GetRandomString(r, MaxLen);
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
                var s = GenerateRandomString(MaxLen);
                result += s.Length;
            }

            return result;

            string GenerateRandomString(int maxLength)
            {
                var len = r.Next(maxLength);
                Random rnd = new Random((int)(DateTime.Now.Ticks % int.MaxValue));
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < len; i++)
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
                var s = RandomString(r, MaxLen);
                result += s.Length;
            }

            return result;

            static string RandomString(Random random, int maxLength)
            {
                var len = random.Next(maxLength);
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                return new string(Enumerable.Repeat(chars, len)
                    .Select(s => s[random.Next(s.Length)]).ToArray());
            }
        }

        [Benchmark]
        public long RandomStringsUsingStringDotCreate()
        {
            long result = 0;
            byte[] buffer = new byte[MaxLen];
            var r = new Random(Count);

            for (int i = 0; i < Count; i++)
            {
                var s = RandomStringCreate(r, MaxLen);
                result += s.Length;
            }

            return result;

            static string RandomStringCreate(Random random, int maxLength)
            {
                var alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz-_@!#$%^&*()+{}[]";

                var len = random.Next(maxLength);
                return string.Create(len, random, (buff, str) =>
                {
                    for (int i = 0; i < buff.Length; i++)
                    {
                        buff[i] = alphabet[random.Next(alphabet.Length)];
                    }

                });
            }
        }

        [Benchmark]
        public long RandomStringsUsingStringDotCreateConstAlpha()
        {
            long result = 0;
            byte[] buffer = new byte[MaxLen];
            var r = new Random(Count);

            for (int i = 0; i < Count; i++)
            {
                var s = RandomStringCreate(r, MaxLen);
                result += s.Length;
            }

            return result;

            static string RandomStringCreate(Random random, int maxLength)
            {
                const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz-_@!#$%^&*()+{}[]";
                var len = random.Next(maxLength);
                return string.Create(len, random, (buff, str) =>
                {
                    for (int i = 0; i < buff.Length; i++)
                    {
                        buff[i] = alphabet[random.Next(alphabet.Length)];
                    }
                });
            }
        }

        [Benchmark]
        public long RandomStringsUsingStringDotCreateConstAlphaStaticRandom()
        {
            long result = 0;
            byte[] buffer = new byte[MaxLen];

            for (int i = 0; i < Count; i++)
            {
                var s = RandomStringCreate(MaxLen);
                result += s.Length;
            }

            return result;

            static string RandomStringCreate(int maxLength)
            {
                const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz-_@!#$%^&*()+{}[]";
                var len = random.Next(maxLength);
                return string.Create(len, random, (buff, str) =>
                {
                    for (int i = 0; i < buff.Length; i++)
                    {
                        buff[i] = alphabet[random.Next(alphabet.Length)];
                    }
                });
            }
        }

        [Benchmark]
        public long RandomStringAkari()
        {
            long result = 0;
            var r = new Random(Count);

            for (int i = 0; i < Count; i++)
            {
                var s = GetRandomString(r, MaxLen);
                result += s.Length;
            }

            return result;
            static string GetRandomString(Random r, int maxLength)
            {
                const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz-_@!#$%^&*()+{}[]";
                unsafe
                {
                    char* str = stackalloc char[maxLength];
                    for (var i = 0; i < maxLength; i++)
                    {
                        (*str++) = alphabet[r.Next(alphabet.Length)];
                    }

                    return new(str);
                }
            }
        }
    }
}
