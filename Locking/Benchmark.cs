namespace Test
{
#pragma warning disable VSTHRD200 // Use "Async" suffix for async methods
#pragma warning disable VSTHRD101 // Avoid unsupported async delegates
    using BenchmarkDotNet.Attributes;
    using Nito.AsyncEx;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    [MemoryDiagnoser]
    public class Benchmark
    {
        static object syncobj = new();
        static SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);
        static AsyncMonitor asyncMonitor = new AsyncMonitor();

        public int Count { get; set; } = 100;

        List<int> _data = new();

        [GlobalSetup]
        public void GlobalSetup()
        {
            _data.Clear();
        }

        [Benchmark]
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
        public void SemaphoreSlim()
        {
            Parallel.For(0, Count, async i =>
            {
                try
                {
                    await semaphore.WaitAsync();
                    _data.Add(i);
                }
                finally
                {
                    semaphore.Release();
                }

            });
        }

        [Benchmark]
        public void AsyncMonitor()
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
}

