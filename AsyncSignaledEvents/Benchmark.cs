namespace Benchmark
{
    using BenchmarkDotNet.Attributes;
    using Microsoft.VisualStudio.Threading;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    [MemoryDiagnoser]
    public class Benchmark
    {
        const string tmpfile = "03916c44-4be6-40cb-904c-1403dd6c4f3e.tmp";
        FileStream _fs;
        SemaphoreSlim _semaphore;
        AsyncSemaphore _asyncsemaphore;
        AsyncManualResetEvent _asyncmre;

        [Params(100)]
        public int Count;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _fs = new FileStream(tmpfile, FileMode.Create, FileAccess.Write);
            _semaphore = new SemaphoreSlim(1, 1);
            _asyncsemaphore = new AsyncSemaphore(1);
            _asyncmre = new AsyncManualResetEvent(true);
        }

        [GlobalCleanup]
        public void GlobalCleanup()
        {
            _fs.Dispose();
            File.Delete(tmpfile);
        }

        [Benchmark]
        public async Task SemaphoreSlimAsync()
        {
            var tasks = new List<Task>();

            for (int i = 0; i < Count; i++)
            {
                var t = Task.Run(async () =>
                {
                    await _semaphore.WaitAsync();
                    try
                    {
                        _fs.WriteByte(0xFF);
                    }
                    finally
                    {
                        _semaphore.Release();
                    }
                });

                tasks.Add(t);
            }

            await Task.WhenAll(tasks);
        }

        [Benchmark]
        public async Task AsyncSemaphoreAsync()
        {
            var tasks = new List<Task>();

            for (int i = 0; i < Count; i++)
            {
                var t = Task.Run(async () =>
                {
                    using var releaser = await _asyncsemaphore.EnterAsync();
                    _fs.WriteByte(0xFF);
                });

                tasks.Add(t);
            }

            await Task.WhenAll(tasks);
        }

        [Benchmark]
        public async Task AsyncManualResetEventAsync()
        {
            var tasks = new List<Task>();

            for (int i = 0; i < Count; i++)
            {
                var t = Task.Run(async () =>
                {
                    await _asyncmre.WaitAsync();
                    try
                    {
                        _fs.WriteByte(0xFF);
                    }
                    finally
                    {
                        _asyncmre.Set();
                    }
                });

                tasks.Add(t);
            }

            await Task.WhenAll(tasks);
        }
    }
}
