namespace Test
{
    using BenchmarkDotNet.Attributes;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [DisassemblyDiagnoser]
    [MemoryDiagnoser]
    public class Benchmark
    {
        private (string, string)[] _stringPairs;

        [Params(1000)]
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            _stringPairs = new (string, string)[Count];
            var random = new Random(Count);

            for (int i = 0; i < Count; i++)
            {
                var strA = RandomStringCreate(random, 50);
                var strB = (random.Next() % 2) switch
                {
                    0 => strA.ToUpperInvariant(),
                    _ => RandomStringCreate(random, 50)
                };

                _stringPairs[i] = (strA, strB);
            }
        }

        [Benchmark(Baseline = true)]
        public int ToLower()
        {
            var pairs = _stringPairs;
            var result = 0;

            foreach (var (first, second) in pairs)
            {
                if (first.ToLower() == second.ToLower())
                {
                    result++;
                }
            }

            return result;
        }

        [Benchmark]
        public int ToUpper()
        {
            var pairs = _stringPairs;
            var result = 0;

            foreach (var (first, second) in pairs)
            {
                if (first.ToUpper() == second.ToUpper())
                {
                    result++;
                }
            }

            return result;
        }

        [Benchmark]
        public int ToLowerInvariant()
        {
            var pairs = _stringPairs;
            var result = 0;

            foreach (var (first, second) in pairs)
            {
                if (first.ToLowerInvariant() == second.ToLowerInvariant())
                {
                    result++;
                }
            }

            return result;
        }

        [Benchmark]
        public int ToUpperInvariant()
        {
            var pairs = _stringPairs;
            var result = 0;

            foreach (var (first, second) in pairs)
            {
                if (first.ToUpperInvariant() == second.ToUpperInvariant())
                {
                    result++;
                }
            }

            return result;
        }

        [Benchmark]
        public int StringComparisonIgnoreCaseFlag()
        {
            var pairs = _stringPairs;
            var result = 0;

            foreach (var (first, second) in pairs)
            {
                if (string.Compare(first, second, true) == 0)
                {
                    result++;
                }
            }

            return result;
        }

        [Benchmark]
        public int StringComparisonOrdinalIgnoreCase()
        {
            var pairs = _stringPairs;
            var result = 0;

            foreach (var (first, second) in pairs)
            {
                if (string.Compare(first, second, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    result++;
                }
            }

            return result;
        }

        [Benchmark]
        public int StringComparisonInvariantCultureIgnoreCase()
        {
            var pairs = _stringPairs;
            var result = 0;

            foreach (var (first, second) in pairs)
            {
                if (string.Compare(first, second, StringComparison.InvariantCultureIgnoreCase) == 0)
                {
                    result++;
                }
            }

            return result;
        }

        [Benchmark]
        public int StringComparisonCurrentCultureIgnoreCase()
        {
            var pairs = _stringPairs;
            var result = 0;

            foreach (var (first, second) in pairs)
            {
                if (string.Compare(first, second, StringComparison.CurrentCultureIgnoreCase) == 0)
                {
                    result++;
                }
            }

            return result;
        }

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
}
