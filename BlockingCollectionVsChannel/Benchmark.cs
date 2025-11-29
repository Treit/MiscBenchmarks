namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Channels;
using BenchmarkDotNet.Jobs;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    [Params(1000, 10_000)]
    public int Count { get; set; }

    private List<byte[]> _data;

    private int _totalProcessed;

    private long _totalCount;

    BlockingCollection<byte[]> _workQueue;

    Channel<byte[]> _channel;

    [GlobalSetup]
    public void GlobalSetup()
    {
        ThreadPool.SetMinThreads(100, 100);
        Random r = new Random();

        _data = new List<byte[]>();

        for (int i = 0; i < Count; i++)
        {
            int size = r.Next(1, 1000);
            var values = new byte[size];
            r.NextBytes(values);

            _data.Add(values);
        }
    }

    [Benchmark(Baseline = true)]
    public long GetTotalUsingBlockingCollectionSingleTask()
    {
        _workQueue = new BlockingCollection<byte[]>();
        _totalCount = 0;
        _totalProcessed = 0;

        Task<long> t = Task.Factory.StartNew(() =>
        {
            long value = 0;
            while (true)
            {
                if (_workQueue.TryTake(out var buffer))
                {
                    Interlocked.Increment(ref _totalProcessed);

                    foreach (var b in buffer)
                    {
                        value += b;
                        Interlocked.Add(ref _totalCount, b);
                    }
                }
                else if (_workQueue.IsCompleted)
                {
                    return value;
                }
            }
        });

        foreach (var workChunk in _data)
        {
            _workQueue.Add(workChunk);
        }

        _workQueue.CompleteAdding();

        t.Wait();

        if (t.Result != _totalCount)
        {
            throw new InvalidOperationException($"Unexpected result of adding up all of the values. {t.Result} != {_totalCount}.");
        }

        return t.Result;
    }

    [Benchmark]
    public long GetTotalUsingChannelSingleTask()
    {
        _channel = Channel.CreateUnbounded<byte[]>();
        _totalCount = 0;
        _totalProcessed = 0;

        Task<long> t = Task.Factory.StartNew(() =>
        {
            long value = 0;
            while (true)
            {
                bool avail = _channel.Reader.WaitToReadAsync().AsTask().Result;

                if (avail && _channel.Reader.TryRead(out var buffer))
                {
                    Interlocked.Increment(ref _totalProcessed);

                    foreach (var b in buffer)
                    {
                        value += b;
                        Interlocked.Add(ref _totalCount, b);
                    }
                }
                else if (_channel.Reader.Completion.IsCompleted)
                {
                    return value;
                }
            }
        });

        foreach (var workChunk in _data)
        {
            _channel.Writer.TryWrite(workChunk);
        }

        _channel.Writer.Complete();

        t.Wait();

        if (t.Result != _totalCount)
        {
            throw new InvalidOperationException($"Unexpected result of adding up all of the values. {t.Result} != {_totalCount}.");
        }

        return t.Result;
    }

    [Benchmark]
    public long GetTotalUsingBlockingCollectionMultipleTasks()
    {
        _workQueue = new BlockingCollection<byte[]>();
        _totalCount = 0;
        _totalProcessed = 0;

        int taskCount = 32;
        var tasks = new List<Task<long>>();

        for (int i = 0; i < taskCount; i++)
        {
            Task<long> t = Task.Factory.StartNew(() =>
            {
                long value = 0;
                while (true)
                {
                    if (_workQueue.TryTake(out var buffer))
                    {
                        Interlocked.Increment(ref _totalProcessed);

                        foreach (var b in buffer)
                        {
                            value += b;
                            Interlocked.Add(ref _totalCount, b);
                        }
                    }
                    else if (_workQueue.IsCompleted)
                    {
                        return value;
                    }
                }
            });

            tasks.Add(t);
        }

        foreach (var workChunk in _data)
        {
            _workQueue.Add(workChunk);
        }

        _workQueue.CompleteAdding();

        Task.WaitAll(tasks.ToArray());

        long total = 0;

        foreach (var task in tasks)
        {
            total += task.Result;
        }

        if (total != _totalCount)
        {
            throw new InvalidOperationException($"Unexpected result of adding up all of the values. {total} != {_totalCount}.");
        }

        return total;
    }

    [Benchmark]
    public long GetTotalUsingChannelMultipleTasks()
    {
        _channel = Channel.CreateUnbounded<byte[]>();
        _totalCount = 0;
        _totalProcessed = 0;

        int taskCount = 32;
        var tasks = new List<Task<long>>();

        for (int i = 0; i < taskCount; i++)
        {
            Task<long> t = Task.Factory.StartNew(() =>
            {
                long value = 0;
                while (true)
                {
                    bool avail = _channel.Reader.WaitToReadAsync().AsTask().Result;

                    if (avail && _channel.Reader.TryRead(out var buffer))
                    {
                        Interlocked.Increment(ref _totalProcessed);

                        foreach (var b in buffer)
                        {
                            value += b;
                            Interlocked.Add(ref _totalCount, b);
                        }
                    }
                    else if (_channel.Reader.Completion.IsCompleted)
                    {
                        return value;
                    }
                }
            });


            tasks.Add(t);
        }

        foreach (var workChunk in _data)
        {
            _channel.Writer.TryWrite(workChunk);
        }

        _channel.Writer.Complete();

        Task.WaitAll(tasks.ToArray());

        long total = 0;

        foreach (var task in tasks)
        {
            total += task.Result;
        }

        if (total != _totalCount)
        {
            throw new InvalidOperationException($"Unexpected result of adding up all of the values. {total} != {_totalCount}.");
        }

        return total;
    }
}
