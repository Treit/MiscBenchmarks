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
            string needle = "104";
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
            string needle = "104";
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
            string needle = "104";
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

        [Benchmark]
        public int FindTokenUsingSpan()
        {
            string needle = "104";
            int result = -1;

            for (int i = 0; i < _values.Count; i++)
            {
                string value = _values[i];
                int cc = 0;
                int start = 0;
                int end = 0;

                for (int j = 0; j < value.Length; j++)
                {
                    if (value[j] == ',')
                    {
                        cc++;
                    }

                    if (cc == 5)
                    {
                        if (start == 0)
                        {
                            start = j;
                        }
                    }

                    if (cc == 6)
                    {
                        end = j;
                        break;
                    }
                }

                ReadOnlySpan<char> span = value.AsSpan(start + 1, end - start - 1);

                if (span.CompareTo(needle.AsSpan(), StringComparison.Ordinal) == 0)
                {
                    result = i;
                }

            }

            return result;
        }
    }
}
