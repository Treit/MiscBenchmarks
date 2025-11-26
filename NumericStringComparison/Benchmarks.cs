using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace NumericStringComparison
{
    [MemoryDiagnoser]
    [SimpleJob(RuntimeMoniker.Net90)]
    [SimpleJob(RuntimeMoniker.Net10_0)]
    public class Benchmark
    {
        [Params(1000)]
        public int Count { get; set; }

        private string[] _numericStrings;
        private string _targetValue;
        private Random _random;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _random = new Random(42);
            _targetValue = "10000";
            int arraySize = Count > 0 ? Count : 1000;
            _numericStrings = new string[arraySize];

            for (int i = 0; i < arraySize; i++)
            {
                // Create mix of strings that match and don't match our target
                if (i % 10 == 0) // 10% will match
                {
                    _numericStrings[i] = _targetValue;
                }
                else
                {
                    int value = _random.Next(1, 99999);
                    _numericStrings[i] = value.ToString();
                }
            }
        }

        [Benchmark(Baseline = true)]
        public int EqualityOperator()
        {
            int matches = 0;
            for (int i = 0; i < _numericStrings.Length; i++)
            {
                if (_numericStrings[i] == _targetValue)
                {
                    matches++;
                }
            }
            return matches;
        }

        [Benchmark]
        public int StringEqualsOrdinal()
        {
            int matches = 0;
            for (int i = 0; i < _numericStrings.Length; i++)
            {
                if (string.Equals(_numericStrings[i], _targetValue, StringComparison.Ordinal))
                {
                    matches++;
                }
            }
            return matches;
        }

        [Benchmark]
        public int StringEqualsOrdinalIgnoreCase()
        {
            int matches = 0;
            for (int i = 0; i < _numericStrings.Length; i++)
            {
                if (string.Equals(_numericStrings[i], _targetValue, StringComparison.OrdinalIgnoreCase))
                {
                    matches++;
                }
            }
            return matches;
        }

        [Benchmark]
        public int StringInstanceEquals()
        {
            int matches = 0;
            for (int i = 0; i < _numericStrings.Length; i++)
            {
                if (_numericStrings[i].Equals(_targetValue))
                {
                    matches++;
                }
            }
            return matches;
        }

        [Benchmark]
        public int StringInstanceEqualsOrdinal()
        {
            int matches = 0;
            for (int i = 0; i < _numericStrings.Length; i++)
            {
                if (_numericStrings[i].Equals(_targetValue, StringComparison.Ordinal))
                {
                    matches++;
                }
            }
            return matches;
        }
    }
}
