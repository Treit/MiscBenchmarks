namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using Microsoft.Diagnostics.Tracing.Parsers.MicrosoftWindowsTCPIP;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(10, 100, 1000)]
        public int Count { get; set; }

        Task[] _tasks;

        [IterationSetup]
        public void IterationSetup()
        {
            _tasks = new Task[Count];

            for (int i = 0; i < Count; i++)
            {
                string fname = i.ToString();

                _tasks[i] = Task.Factory.StartNew(async () =>
                {
                    File.Create(fname);
                    await File.WriteAllTextAsync(fname, "Test!");
                    File.Delete(fname);
                });
            }
        }

        [Benchmark(Baseline = true)]
        public async Task AwaitTasksSequentially()
        {
            foreach (var task in _tasks)
            {
                await task;
            }
        }

        [Benchmark]
        public async Task AwaitTasksUsingWhenAll()
        {
            await Task.WhenAll(_tasks);
        }
    }
}


