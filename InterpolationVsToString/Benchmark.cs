namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    [MemoryDiagnoser]
    [MemoryRandomization]
    public class Benchmark
    {
        private Dictionary<string, uint> _dict;

        [Params(5000)]
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            _dict = new Dictionary<string, uint>(Count);

            for (int i = 0; i < Count; i++)
            {
                _dict.Add(i.ToString(), (uint)i);
            }
        }

        [Benchmark(Baseline = true)]
        public long LookupUsingToString()
        {
            var result = 0L;

            for (var i = 0; i < Count; i++)
            {
                if (_dict.TryGetValue(i.ToString(), out var value))
                {
                    result += value;
                }
            }

            return result;
        }

        [Benchmark]
        public long LookupUsingInterpolation()
        {
            var result = 0L;

            for (var i = 0; i < Count; i++)
            {
                if (_dict.TryGetValue($"{i}", out var value))
                {
                    result += value;
                }
            }

            return result;
        }
    }
}
