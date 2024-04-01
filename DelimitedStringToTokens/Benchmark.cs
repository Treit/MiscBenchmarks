namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using System;

    [MemoryDiagnoser]
    public class Benchmark
    {
        string[] _delimitedStrings;

        [Params(1, 1000)]
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            _delimitedStrings = new string[Count];
            for (int i = 0; i < Count; i++)
            {
                _delimitedStrings[i] = $"SomeValue{i},SomeOtherValue{i}";
            }
        }

        [Benchmark]
        public (string, string) TokenizeWithStringSplit()
        {
            var result = ("", "");

            for (var i = 0; i < Count; i++)
            {
                var tokens = _delimitedStrings[i].Split(',');
                result = (tokens[0], tokens[1]);
            }

            return result;
        }

        [Benchmark(Baseline = true)]
        public (string, string) TokenizeWithSubstring()
        {
            var result = ("", "");

            for (var i = 0; i < Count; i++)
            {
                var index = _delimitedStrings[i].IndexOf(',');
                var strA = _delimitedStrings[i].Substring(0, index);
                var strB = _delimitedStrings[i].Substring(index + 1);
                result = (strA, strB);
            }

            return result;
        }

        [Benchmark]
        public (string, string) TokenizeWithRangeOperator()
        {
            var result = ("", "");

            for (var i = 0; i < Count; i++)
            {
                var index = _delimitedStrings[i].IndexOf(',');
                var strA = _delimitedStrings[i][..index];
                var strB = _delimitedStrings[i][(index + 1)..];
                result = (strA, strB);
            }

            return result;
        }
    }
}
