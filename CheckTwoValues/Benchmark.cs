namespace Test
{
    using System;
    using System.Collections.Generic;
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;

    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params("gibberish", "needle", "needle_in_a_haystack", "needle_in_a_haystac")]
        public string Value { get; set; }
        private static HashSet<string> _values = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "needle", "needle_in_a_haystack" };

        [GlobalSetup]
        public void GlobalSetup()
        {
        }

        [Benchmark]
        public bool CheckWithNewHashSet()
        {
            return new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "needle", "needle_in_a_haystack" }.Contains(Value);
        }

        [Benchmark(Baseline = true)]
        public bool CheckWithSimpleIf()
        {
            return Value.Equals("needle", StringComparison.OrdinalIgnoreCase)
                || Value.Equals("needle_in_a_haystack", StringComparison.OrdinalIgnoreCase);
        }

        [Benchmark]
        public bool CheckWithStaticHashSet()
        {
            return _values.Contains(Value);
        }

        [Benchmark]
        public bool CheckWithCharListPattern()
        {
            return Value switch
            {
                ['n' or 'N', 'e' or 'E', 'e' or 'E', 'd' or 'D', 'l' or 'L', 'e' or 'E'] => true,
                ['n' or 'N', 'e' or 'E', 'e' or 'E', 'd' or 'D', 'l' or 'L', 'e' or 'E',
                 '_', 'i' or 'I', 'n' or 'N', '_', 'a' or 'A', '_', 'h' or 'H', 'a' or 'A',
                 'y' or 'Y', 's' or 'S', 't' or 'T', 'a' or 'A', 'c' or 'C', 'k' or 'K'] => true,
                _ => false
            };
        }
    }
}
