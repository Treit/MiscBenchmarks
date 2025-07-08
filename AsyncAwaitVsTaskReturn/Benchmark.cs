namespace AsyncAwaitVsTaskReturn
{
    using BenchmarkDotNet.Attributes;
    using System;
    using System.Threading.Tasks;

    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(100)]
        public int Count { get; set; }


        [GlobalSetup]
        public void GlobalSetup()
        {
        }

        [Benchmark]
        public async Task<int> AsyncAwaitWithAwaitChain()
        {
            var sum = 0;
            for (int i = 0; i < Count; i++)
            {
                sum += await DoWorkAsync1();
            }

            return sum;
        }

        [Benchmark(Baseline = true)]
        public async Task<int> AsyncAwaitWithReturnChain()
        {
            var sum = 0;
            for (int i = 0; i < Count; i++)
            {
                sum += await DoWorkTaskReturn1();
            }

            return sum;
        }

        private async Task<int> DoWorkAsync1()
        {
            return await DoWorkAsync2();
        }

        private async Task<int> DoWorkAsync2()
        {
            return await DoActualAsyncWork();
        }

        private async Task<int> DoActualAsyncWork()
        {
            await Task.Yield();
            return Random.Shared.Next(1, 100);
        }

        private Task<int> DoWorkTaskReturn1()
        {
            return DoWorkTaskReturn2();
        }

        private Task<int> DoWorkTaskReturn2()
        {
            return DoActualAsyncWork();
        }
    }
}
