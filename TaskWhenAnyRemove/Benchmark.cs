namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [MemoryDiagnoser]
    public class Benchmark
    {
        [GlobalSetup]
        public void GlobalSetup()
        {
        }

        [Benchmark(Baseline = true)]
        public async Task TaskWhenAnyRemoveWithHashSet()
        {
            var tasks = new HashSet<Task<float>>();
            for (int i = 0; i < 10; i++)
            {
                var task = Task.Run(() => SimulateWork());
                tasks.Add(task);
            }

            while (tasks.Any()) 
            {
                var completedTask = await Task.WhenAny(tasks);
                tasks.Remove(completedTask);
            }            
        }

        [Benchmark]
        public async Task TaskWhenAnyRemoveWithList()
        {
            var tasks = new List<Task<float>>();
            for (int i = 0; i < 10; i++)
            {
                var task = Task.Run(() => SimulateWork());
                tasks.Add(task);
            }

            while (tasks.Any()) 
            {
                var completedTask = await Task.WhenAny(tasks);
                tasks.Remove(completedTask);
            }            
        }        

        private static async Task<float> SimulateWork()
        {
            await Task.Yield();
            return 0.0f;
        }
    }
}
