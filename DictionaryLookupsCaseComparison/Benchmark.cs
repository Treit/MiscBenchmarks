namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;

    public class SomeClass
    {
        public int DoSomething()
        {
            return (int)DateTime.UtcNow.Ticks;
        }
    }

    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(10, 100_000)]
        public int Iterations { get; set; }

        private string _needle;

        private Dictionary<string, SomeClass> _ordinal = new Dictionary<string, SomeClass>(StringComparer.Ordinal);
        private Dictionary<string, SomeClass> _ordinalIgnoreCase = new Dictionary<string, SomeClass>(StringComparer.OrdinalIgnoreCase);
        private Dictionary<string, SomeClass> _invariantCulture = new Dictionary<string, SomeClass>(StringComparer.InvariantCulture);
        private Dictionary<string, SomeClass> _invariantCultureIgnoreCase = new Dictionary<string, SomeClass>(StringComparer.InvariantCultureIgnoreCase);

        [GlobalSetup]
        public void GlobalSetup()
        {
            var len = 50;

            for (int i = 0; i < len; i++)
            {
                var key = Guid.NewGuid().ToString();

                _ordinal.Add(key, new SomeClass());
                _ordinalIgnoreCase.Add(key, new SomeClass());
                _invariantCulture.Add(key, new SomeClass());
                _invariantCultureIgnoreCase.TryAdd(key, new SomeClass());

                _needle = key;
            }
        }

        [Benchmark(Baseline = true)]
        public long DictonaryLookupUsingOrdinal()
        {
            long result = 0;

            for (int i = 0; i < this.Iterations; i++)
            {
                for (int j = 0; j < _ordinal.Count; j++)
                {
                    SomeClass c = _ordinal[_needle];
                    result += c.DoSomething();
                }
            }

            return result;
        }

        [Benchmark]
        public long DictonaryLookupUsingOrdinalIgnoreCase()
        {
            long result = 0;

            for (int i = 0; i < this.Iterations; i++)
            {
                for (int j = 0; j < _ordinal.Count; j++)
                {
                    SomeClass c = _ordinalIgnoreCase[_needle];
                    result += c.DoSomething();
                }
            }

            return result;
        }

        [Benchmark]
        public long DictonaryLookupUsingInvariantCulture()
        {
            long result = 0;

            for (int i = 0; i < this.Iterations; i++)
            {
                for (int j = 0; j < _ordinal.Count; j++)
                {
                    SomeClass c = _invariantCulture[_needle];
                    result += c.DoSomething();
                }
            }

            return result;
        }

        [Benchmark]
        public long DictonaryLookupUsingInvariantCultureIgnoreCase()
        {
            long result = 0;

            for (int i = 0; i < this.Iterations; i++)
            {
                for (int j = 0; j < _ordinal.Count; j++)
                {
                    SomeClass c = _invariantCultureIgnoreCase[_needle];
                    result += c.DoSomething();
                }
            }

            return result;
        }
    }
}
