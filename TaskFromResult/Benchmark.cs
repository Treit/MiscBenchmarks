namespace Test
{
    using BenchmarkDotNet.Attributes;
    using System.Threading.Tasks;

    public class Benchmark
    {

        [GlobalSetup]
        public void GlobalSetup()
        {
        }

        [Benchmark(Baseline = true)]
        public Task<string> TaskFromResult()
        {
            return Task.FromResult("foo");
        }

        [Benchmark]
        public async Task<string> AwaitTaskFromResult()
        {
            return await Task.FromResult("foo");
        }
    }
}


