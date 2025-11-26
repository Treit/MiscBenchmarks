namespace Test;
#pragma warning disable VSTHRD200 // Use "Async" suffix for async methods
#pragma warning disable VSTHRD101 // Avoid unsupported async delegates
using BenchmarkDotNet.Attributes;
using Nito.AsyncEx;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BenchmarkDotNet.Jobs;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    static object syncobj = new();
    static SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1, 1);
    static Semaphore semaphore = new Semaphore(1, 1);
    static AsyncMonitor asyncMonitor = new AsyncMonitor();

    public int Count { get; set; } = 10000;

    List<int> _data = new();

    [IterationSetup]
    public void IterationSetup()
    {
        _data.Clear();
    }

    [Benchmark(Baseline = true)]
    public void RegularLock()
    {
        Parallel.For(0, Count, i =>
        {
            lock (syncobj)
            {
                _data.Add(i);
            }
        });
    }

    [Benchmark]
    public void SemaphoreWait()
    {
        Parallel.For(0, Count, i =>
        {
            try
            {
                semaphore.WaitOne();
                _data.Add(i);
            }
            finally
            {
                semaphore.Release();
            }

        });
    }

    [Benchmark]
    public void SemaphoreSlimWait()
    {
        Parallel.For(0, Count, i =>
        {
            try
            {
                semaphoreSlim.Wait();
                _data.Add(i);
            }
            finally
            {
                semaphoreSlim.Release();
            }

        });
    }

    [Benchmark]
    public void SemaphoreSlimWaitAsync()
    {
        Parallel.For(0, Count, async i =>
        {
            try
            {
                await semaphoreSlim.WaitAsync();
                _data.Add(i);
            }
            finally
            {
                semaphoreSlim.Release();
            }

        });
    }

    [Benchmark]
    public void NitoAsyncMonitor()
    {
        Parallel.For(0, Count, async i =>
        {
            {
                using (await asyncMonitor.EnterAsync())
                {
                    _data.Add(i);
                }
            }
        });
    }
}

#pragma warning restore VSTHRD200 // Use "Async" suffix for async methods
#pragma warning restore VSTHRD101 // Avoid unsupported async delegates
