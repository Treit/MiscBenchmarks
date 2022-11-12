namespace Test
{
    using BenchmarkDotNet.Attributes;
    using System.Collections.Generic;
    using System.Linq;

    [MemoryDiagnoser]
    public class Benchmark
    {
        [GlobalSetup]
        public void GlobalSetup()
        {
        }

        [Benchmark(Baseline = true)]
        public string EnumerableDotEmpty()
        {
            return Enumerable.Empty<string>().FirstOrDefault();
        }

        [Benchmark]
        public string NewEmptyArray()
        {
            return new string[0].FirstOrDefault();
        }

        [Benchmark]
        public string NewEmptyList()
        {
            return new List<string>().FirstOrDefault();
        }
    }
}

