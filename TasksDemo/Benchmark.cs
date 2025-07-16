namespace Test;
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
        for (int i = 0; i < NumberOfArrays; i++)
        {
            for (int j = 0; j < ArraySize; j++)
            {
                _arraysToFill[i][j] = Guid.NewGuid();
            }
        }
    }

    public Task GetBackgroundTask()
    {
        var task = Task.Factory.StartNew(() =>
        {
            // Long running background work goes here.
        },
         // Not 100% guaranteed to use a dedicated thread.
        TaskCreationOptions.LongRunning);

        return task;
    }

    [Benchmark]
    public async Task ParallelTasks()
    {
        var tasks = new Task[_arraysToFill.Count];

        for (int i = 0; i < _arraysToFill.Count; i++)
        {
            var target = _arraysToFill[i];

            var task = Task.Run(() => 
            {
                for (int i = 0; i < target.Length; i++)
                {
                    target[i] = Guid.NewGuid();
                }
            });

            tasks[i] = task;
        }

        await Task.WhenAll(tasks);
    }

    [Benchmark]
    public void ParallelThreads()
    {
        var threads = new Thread[_arraysToFill.Count];

        for (int i = 0; i < _arraysToFill.Count; i++)
        {
            var target = _arraysToFill[i];

            var thread = new Thread(() =>
            {
                for (int i = 0; i < target.Length; i++)
                {
                    target[i] = Guid.NewGuid();
                }
            });

            thread.Start();
            threads[i] = thread;
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
}
