namespace Test
{
    using BenchmarkDotNet.Attributes;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(10_000)]
        public int ArraySize { get; set; }

        [Params(4, 8, 64)]
        public int NumberOfArrays { get; set; }

        List<Guid[]> _arraysToFill;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _arraysToFill = new List<Guid[]>(NumberOfArrays);

            for (int i = 0; i < NumberOfArrays; i++)
            {
                _arraysToFill.Add(new Guid[ArraySize]);
            }
        }

        [Benchmark(Baseline = true)]
        public void Sequential()
        {
            for (int i = 0; i < ArraySize; i++)
            {
                for (int j = 0; j < NumberOfArrays; j++)
                {
                    _arraysToFill[j][i] = Guid.NewGuid();
                }
            }
        }

        [Benchmark]
        public void ParallelTasks()
        {
            var tasks = new Task[NumberOfArrays];

            for (int i = 0; i < NumberOfArrays; i++)
            {
                tasks[i] = StartTask(_arraysToFill[i]);
            }

            Task.WaitAll(tasks);
        }

        [Benchmark]
        public void ParallelThreads()
        {
            var threads = new Thread[NumberOfArrays];

            for (int i = 0; i < NumberOfArrays; i++)
            {
                threads[i] = StartThread(_arraysToFill[i]);
            }

            foreach(var thread in threads)
            {
                thread.Join();
            }
        }

        [Benchmark]
        public void ParallelForEach()
        {
            Parallel.ForEach(_arraysToFill, target =>
            {
                for (int i = 0; i < target.Length; i++)
                {
                    target[i] = Guid.NewGuid();
                }
            });
        }

        [Benchmark]
        public void ParallelFor()
        {
            Parallel.For(0, _arraysToFill.Count, idx =>
            {
                var target = _arraysToFill[idx];
                for (int i = 0; i < target.Length; i++)
                {
                    target[i] = Guid.NewGuid();
                }
            });
        }

        static Task StartTask(Guid[] target)
        {
            return Task.Run(() => 
            {
                for (int i = 0; i < target.Length; i++)
                {
                    target[i] = Guid.NewGuid();
                }
            });
        }

        static Thread StartThread(Guid[] target)
        {
            var thread = new Thread(() =>
            {
                for (int i = 0; i < target.Length; i++)
                {
                    target[i] = Guid.NewGuid();
                }
            });

            thread.Start();
            return thread;
        }
    }
}


