namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [MemoryDiagnoser]
    [MemoryRandomization]
    public class Benchmark
    {
        private string[] _stringArray;

        [Params(10, 100_000)]
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            _stringArray = new string[Count];

            for (int i = 0; i < Count - 1; i++)
            {
                _stringArray[i] = null;
            }

            _stringArray[Count - 1] = "Some string";
        }

        [Benchmark(Baseline = true)]
        public int JustEnumerate()
        {
            var result = 0;

            foreach (var item in _stringArray)
            {
                if (item is not null)
                {
                    result += item.Length;
                }
            }

            return result;
        }

        [Benchmark]
        public int AnyCheckThenEnumerate()
        {
            var result = 0;

            if (_stringArray.Any(x => x is not null))
            {
                foreach (var item in _stringArray)
                {
                    if (item is not null)
                    {
                        result += item.Length;
                    }
                }
            }

            return result;
        }
    }
}
