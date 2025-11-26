namespace Test;
using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using BenchmarkDotNet.Jobs;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    [Params(1)]
    public long Count { get; set; }

    [Params(16)]
    public long ThreadCount { get; set; }

    private List<Guid>[] _guids;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _guids = new List<Guid>[ThreadCount];
        for (long i = 0; i < ThreadCount; i++)
        {
            _guids[i] = new List<Guid>();
        }
    }

    [Benchmark]
    public void WaitAll()
    {
        var tasks = new Task[ThreadCount];

        for (long i = 0; i < ThreadCount; i++)
        {
            var slot = i;
            var task = Task.Run(() =>
            {
                for (long i = 0; i < Count; i++)
                {
                    _guids[slot].Add(Guid.NewGuid());
                }
            });

            tasks[i] = task;
        }

        Task.WaitAll(tasks);
    }

    [Benchmark]
    public async Task WhenAll()
    {
        var tasks = new Task[ThreadCount];

        for (long i = 0; i < ThreadCount; i++)
        {
            var slot = i;
            var task = Task.Run(() =>
            {
                for (long i = 0; i < Count; i++)
                {
                    _guids[slot].Add(Guid.NewGuid());
                }
            });

            tasks[i] = task;
        }

        await Task.WhenAll(tasks);
    }
}
