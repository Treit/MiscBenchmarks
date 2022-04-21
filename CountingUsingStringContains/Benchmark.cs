namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using System;
    using System.Collections.Generic;

    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    public class Benchmark
    {
        [Params(10, 1000, 1_000_000)]
        public int Count { get; set; }

        private List<string> _values;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _values = new List<string>(Count);

            for (int i = 0; i < Count; i++)
            {
                if (i % 7 == 0)
                {
                    _values.Add($"Some Value {i} - Deck");
                }
                else if (i % 8 == 0)
                {
                    _values.Add($"Some Value {i} - deck");
                }
                else
                {
                    _values.Add($"Some Value {i}");
                }
            }
        }

        [Benchmark(Baseline = true)]
        public long CountUsingTwoChecks()
        {
            long total = 0;

            for (int i = 0; i < Count; i++)
            {
                if (_values[i].Contains("Deck") || _values[i].Contains("deck"))
                {
                    total++;
                }
            }

            return total;
        }

        [Benchmark]
        public long CountUsingOrdinalIgnoreCase()
        {
            long total = 0;

            for (int i = 0; i < Count; i++)
            {
                if (_values[i].Contains("Deck", StringComparison.OrdinalIgnoreCase))
                {
                    total++;
                }
            }

            return total;
        }

        [Benchmark]
        public long CountUsingInvariantCultureIgnoreCase()
        {
            long total = 0;

            for (int i = 0; i < Count; i++)
            {
                if (_values[i].Contains("Deck", StringComparison.InvariantCultureIgnoreCase))
                {
                    total++;
                }
            }

            return total;
        }

        [Benchmark]
        public long CountUsingCurrentCultureIgnoreCase()
        {
            long total = 0;

            for (int i = 0; i < Count; i++)
            {
                if (_values[i].Contains("Deck", StringComparison.CurrentCultureIgnoreCase))
                {
                    total++;
                }
            }

            return total;
        }
    }
}


