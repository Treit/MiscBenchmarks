namespace Test
{
    using BenchmarkDotNet.Attributes;
    using System;
using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;

    [MemoryDiagnoser]
    [ShortRunJob]
    public class Benchmark
    {
        [Params(10, 100, 10_000, 100_000)]
        public int Count { get; set; }
        private List<string> _values;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _values = new List<string>(Count);

            for (int i = 0; i < this.Count; i++)
            {
                var str = i.ToString();
                _values.Add(str);
            }
        }

        [Benchmark(Baseline = true)]
        public int StringToIntUsingConvert()
        {
            int last = 0;

            for (int i = 0; i < this.Count; i++)
            {
                int v = Convert.ToInt32(_values[i]);
                last = v;
            }

            return last;
        }

        [Benchmark]
        public int StringToIntUsingParse()
        {
            int last = 0;

            for (int i = 0; i < this.Count; i++)
            {
                int v = int.Parse(_values[i]);
                last = v;
            }

            return last;
        }

        [Benchmark]
        public int StringToIntUsingTryParse()
        {
            int last = 0;

            for (int i = 0; i < this.Count; i++)
            {
                if (int.TryParse(_values[i], out int v))
                {
                    last = v;
                }
            }

            return last;
        }
    }
}
