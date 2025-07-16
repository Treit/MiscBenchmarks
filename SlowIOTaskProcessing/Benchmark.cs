namespace Test;
using BenchmarkDotNet.Attributes;
using System;
using System.Threading;
using System.Threading.Tasks;

[MemoryDiagnoser]
public class Benchmark
{
    [Params(10, 250, 1000)]
    public int Count { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
    }

    [Benchmark(Baseline = true)]
    public void TaskRun()
    {
        var tasks = new Task[Count];

        for (int i = 0; i < Count; i++)
        {
            var worker = new Worker();
            var task = Task.Run(worker.Dowork);
            tasks[i] = task;
        }

        Task.WaitAll(tasks);
    }

    [Benchmark]
    public async Task AsyncTask()
    {
        var tasks = new Task[Count];

        for (int i = 0; i < Count; i++)
        {
            var worker = new Worker();
            var task = worker.DoWorkAsync();
            tasks[i] = task;
        }

        await Task.WhenAll(tasks);
    }

    [Benchmark]
    public void TaskRunSetMinThreads100()
    {
        ThreadPool.SetMinThreads(100, 100);
        var tasks = new Task[Count];

        for (int i = 0; i < Count; i++)
        {
            var worker = new Worker();
            var task = Task.Run(worker.Dowork);
            tasks[i] = task;
        }

        Task.WaitAll(tasks);
    }

    [Benchmark]
    public void TaskRunSetMinThreads1000()
    {
        ThreadPool.SetMinThreads(1000, 1000);
        var tasks = new Task[Count];

        for (int i = 0; i < Count; i++)
        {
            var worker = new Worker();
            var task = Task.Run(worker.Dowork);
            tasks[i] = task;
        }

        Task.WaitAll(tasks);
    }


}

class Worker
{
    public long Result { get; set; }

    public void Dowork()
    {
        // Simulate doing something expensive like I/O
        Thread.Sleep(500);
    }

    public async Task DoWorkAsync()
    {
        await Task.Delay(500);
    }
}
