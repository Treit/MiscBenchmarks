using BenchmarkDotNet.Attributes;
using System;
using BenchmarkDotNet.Jobs;

namespace PropertyInitializationBenchmark
{
    [MemoryDiagnoser]
    [SimpleJob(RuntimeMoniker.Net90)]
    [SimpleJob(RuntimeMoniker.Net10_0)]
    public class Benchmark
    {
        [Params(10, 100000)]
        public int Count { get; set; }

        private readonly string _testEnvVar = "MONITORING_ROLE_INSTANCE";

        [GlobalSetup]
        public void GlobalSetup()
        {
            // Set a test environment variable for consistent testing
            Environment.SetEnvironmentVariable(_testEnvVar, "test-instance-12345");
        }

        [Benchmark]
        public string? ExpressionBodiedProperty()
        {
            string? result = null;
            var instance = new ExpressionBodiedClass();

            for (int i = 0; i < Count; i++)
            {
                result = instance.RoleInstance;
            }

            return result;
        }

        [Benchmark(Baseline = true)]
        public string? AutoPropertyWithInitializer()
        {
            string? result = null;
            var instance = new AutoPropertyClass();

            for (int i = 0; i < Count; i++)
            {
                result = instance.RoleInstance;
            }

            return result;
        }
    }

    // Class using expression-bodied property
    public class ExpressionBodiedClass
    {
        public string? RoleInstance => Environment.GetEnvironmentVariable("MONITORING_ROLE_INSTANCE");
    }

    // Class using auto-property with initializer
    public class AutoPropertyClass
    {
        public string? RoleInstance { get; } = Environment.GetEnvironmentVariable("MONITORING_ROLE_INSTANCE");
    }
}
