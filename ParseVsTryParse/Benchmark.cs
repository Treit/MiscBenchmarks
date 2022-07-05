namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using System;
    using System.Collections.Generic;

    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(100, 1000, 10_000, 100_000)]
        public int Count { get; set; }
        private List<string> _values;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _values = new List<string>(Count);

            Random r = new();

            for (int i = 0; i < this.Count; i++)
            {
                var str = i.ToString();

                if (r.Next(10) > 2)
                {
                    str = str + "garbage";
                }

                _values.Add(str);
            }
        }

        [Benchmark(Baseline = true)]
        public int FindValidIntsWithParse()
        {
            int validCount = 0;

            for (int i = 0; i < this.Count; i++)
            {
                try
                {
                    int.Parse(_values[i]);
                    validCount++;
                }
                catch
                {
                    // Not valid.
                }
            }

            return validCount;
        }

        [Benchmark]
        public int FindValidIntsWithTryParse()
        {
            int validCount = 0;

            for (int i = 0; i < this.Count; i++)
            {
                if (int.TryParse(_values[i], out _))
                {
                    validCount++;
                }
            }

            return validCount;
        }
    }
}
