namespace Test
{
    using System;
    using System.Collections.Generic;
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;

    [MemoryDiagnoser]
    public class Benchmark
    {
        private static string _value = "something";
        private static HashSet<string> _values = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "wpox", "wpod" };

        [GlobalSetup]
        public void GlobalSetup()
        {
        }

        [Benchmark(Baseline = true)]
        public bool CheckWithSimpleIf()
        {
            return _value.Equals("wpxfeed", StringComparison.OrdinalIgnoreCase)
                || _value.Equals("wpohp", StringComparison.OrdinalIgnoreCase);
        }

        [Benchmark]
        public bool CheckWitStaticHashSet()
        {
            return _values.Contains(_value);
        }

        [Benchmark]
        public bool CheckWithNewHashSet()
        {
            return new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "wpox", "wpod" }.Contains(_value);
        }
    }
}
