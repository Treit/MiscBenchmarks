namespace Test
{
    using BenchmarkDotNet.Attributes;
    using System.Reflection;

    public class Benchmark
    {
        [GlobalSetup]
        public void GlobalSetup()
        {
        }

        [Benchmark(Baseline = true)]
        public Assembly GetExecutingAssembly()
        {
            return Assembly.GetExecutingAssembly();
        }

        [Benchmark]
        public Assembly TypeofDotAssembly()
        {
            return typeof(Benchmark).Assembly;
        }
    }
}
