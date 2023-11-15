namespace Test
{
    using System;
    using System.Collections.Generic;
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;

    [MemoryDiagnoser]
    public class Benchmark
    {
        private string _value;

        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            _value = "something";
        }

        [Benchmark(Baseline = true)]
        public bool CheckWithSimpleIf()
        {
            return _value == "wpxfeed" || _value == "wpohp";
        }

        [Benchmark]
        public bool CheckWithNewHashTable()
        {
            return new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "wpoxfeed", "wpodhp" }.Contains(_value);
        }
    }
}
