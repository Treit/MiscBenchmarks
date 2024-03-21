namespace Test
{
    using BenchmarkDotNet.Attributes;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(1, 50)]
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
        }

        [Benchmark(Baseline = true)]
        public async Task<List<string>> AlreadyCompletedTaskDotResult()
        {
            var tasks = new List<Task<string>>();
            for (var i = 0; i < Count; i++)
            {
                tasks.Add(Task.Run(() => Guid.NewGuid().ToString()));
            }

            var results = new List<string>();

            await Task.WhenAll();

            foreach (var task in tasks)
            {
                results.Add(task.Result);
            }

            return results;
        }

        [Benchmark]
        public async Task<List<string>> AlreadyCompletedTaskAwait()
        {
            var tasks = new List<Task<string>>();
            for (var i = 0; i < Count; i++)
            {
                tasks.Add(Task.Run(() => Guid.NewGuid().ToString()));
            }

            var results = new List<string>();

            await Task.WhenAll();

            foreach (var task in tasks)
            {
                results.Add(await task);
            }

            return results;
        }

    }
}

