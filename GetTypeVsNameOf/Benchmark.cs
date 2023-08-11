namespace Test
{
    using System;
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using Microsoft.CodeAnalysis.Operations;

    [MemoryDiagnoser]
    public class Benchmark
    {
        [GlobalSetup]
        public void GlobalSetup()
        {
        }

        [Benchmark(Baseline = true)]
        public string NameViaNameOf()
        {
            return nameof(Benchmark);
        }

        [Benchmark]
        public string NameViaGetType()
        {
            return GetType().Name;
        }
    }
}
