namespace Test
{
    using BenchmarkDotNet.Attributes;
    using System;
    using System.Threading.Tasks;

    [MemoryDiagnoser]
    public class Benchmark
    {
        [GlobalSetup]
        public void GlobalSetup()
        {
        }

        [Benchmark(Baseline = true)]
        public async Task<string> AwaitAsyncMethodCallDirectly()
        {
            return await SomeAsyncTask();
        }

        [Benchmark]
        public async Task<string> AwaitAsyncMethodCallWithTaskDotRunWrapper()
        {
            return await Task.Run(() => SomeAsyncTask());
        }

        async Task<string> SomeAsyncTask()
        {
            await Task.Yield();
            return Guid.NewGuid().ToString();
        }
    }
}

