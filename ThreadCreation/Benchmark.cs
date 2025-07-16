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

    [Benchmark]
    public void ThreadStart()
    {
        var threads = new Thread[Count];

        for (int i = 0; i < Count; i++)
        {
            var worker = new Worker();
            var ts = new ThreadStart(worker.Dowork);
            Thread t = new Thread(ts);
            t.Start();
            threads[i] = t;
        }

        for (int i = 0; i < Count; i++)
        {
            threads[i].Join();
        }
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
    public void TaskFactoryStartNew()
    {
        var tasks = new Task[Count];

        for (int i = 0; i < Count; i++)
        {
            var worker = new Worker();
            var task = Task.Factory.StartNew(worker.Dowork);
            tasks[i] = task;
        }

        Task.WaitAll(tasks);
    }

    [Benchmark]
    public void TaskFactoryStartNewLongRunning()
    {
        var tasks = new Task[Count];

        for (int i = 0; i < Count; i++)
        {
            var worker = new Worker();
            var task = Task.Factory.StartNew(worker.Dowork, TaskCreationOptions.LongRunning);
            tasks[i] = task;
        }

        Task.WaitAll(tasks);
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
        long result = 0;

        // Simulate doing some work that uses both CPU and memory.
        for (int i = 0; i < 100; i++)
        {
            result += Guid.NewGuid().ToByteArray().Length;
        }

        Result = result;
    }
}
