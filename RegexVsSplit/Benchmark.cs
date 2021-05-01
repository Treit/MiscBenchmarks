namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using Microsoft.Diagnostics.Tracing.Parsers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    [MemoryDiagnoser]
    [ShortRunJob]
    public class Benchmark
    {
        [Params(10, 100, 1000, 100_000, 1_000_000)]
        public int Count { get; set; }

        private List<string> _values;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _values = new List<string>(Count);

            for (int i = 0; i < this.Count; i++)
            {
                _values.Add($"{i},{i + 1},{i + 2},{i + 3},{i + 4},{i + 5},{i + 6},{i + 7},{i + 8},{i + 9},{i + 10}");
            }
        }

        [Benchmark(Baseline = true)]
        public int FindTokenUsingSplit()
        {
            Random r = new Random();
            string needle = r.Next(0, Count).ToString();
            int result = -1;

            for (int i = 0; i < _values.Count; i++)
            {
                string[] tokens = _values[i].Split(",");
                if (tokens[5] == needle)
                {
                    result = i;
                }
            }

            return result;
        }

        [Benchmark]
        public int FindTokenUsingRegex()
        {
            Random r = new Random();
            string needle = r.Next(0, Count).ToString();
            int result = -1;

            Regex re = new Regex("^.+,.+,.+,.+,.+,(.+?),");

            for (int i = 0; i < _values.Count; i++)
            {
                Match m = re.Match(_values[i]);
                if (m.Success && m.Result("$1") == needle)
                {
                    result = i;
                }
            }

            return result;
        }

        [Benchmark]
        public int FindTokenUsingCompiledRegex()
        {
            Random r = new Random();
            string needle = r.Next(0, Count).ToString();
            int result = -1;

            Regex re = new Regex("^.+,.+,.+,.+,.+,(.+?),", RegexOptions.Compiled);

            for (int i = 0; i < _values.Count; i++)
            {
                Match m = re.Match(_values[i]);
                if (m.Success && m.Result("$1") == needle)
                {
                    result = i;
                }
            }

            return result;
        }
    }
}
