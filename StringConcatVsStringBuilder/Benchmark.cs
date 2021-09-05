namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;

    [MemoryDiagnoser]
    [ShortRunJob]
    public class Benchmark
    {
        [Params(2, 4, 10, 100, 1000, 10_000)]
        public int Count { get; set; }
        private List<string> _values;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _values = new List<string>(Count);

            for (int i = 0; i < this.Count; i++)
            {
                _values.Add(i.ToString());
            }
        }

        [Benchmark(Baseline = true)]
        public int BuildStringWithConcat()
        {
            string result = string.Empty;

            for (int i = 0; i < this.Count; i++)
            {
                result += _values[i];
            }

            return result.Length;
        }

        [Benchmark]
        public int BuildStringWithStringBuilder()
        {
            var sb = new StringBuilder();

            for (int i = 0; i < this.Count; i++)
            {
                sb.Append(_values[i]);
            }

            string result = sb.ToString();

            return result.Length;
        }
    }
}
