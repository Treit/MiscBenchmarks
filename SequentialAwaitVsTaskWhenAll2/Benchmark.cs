namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using Microsoft.Diagnostics.Tracing.Parsers.MicrosoftWindowsTCPIP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BenchmarkDotNet.Jobs;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    [Benchmark(Baseline = true)]
    public async Task AwaitTasksSequentially()
    {
        var taskA = SomeTask();
        var taskB = SomeTask();
        var taskC = SomeTask();
        var taskD = SomeTask();
        var taskE = SomeTask();
        var taskF = SomeTask();
        var taskG = SomeTask();
        var taskH = SomeTask();
        var taskI = SomeTask();
        var taskJ = SomeTask();
        var taskK = SomeTask();
        var taskL = SomeTask();
        var taskM = SomeTask();
        var taskN = SomeTask();
        var taskO = SomeTask();

        await taskA.ConfigureAwait(false);
        await taskB.ConfigureAwait(false);
        await taskC.ConfigureAwait(false);
        await taskD.ConfigureAwait(false);
        await taskE.ConfigureAwait(false);
        await taskF.ConfigureAwait(false);
        await taskG.ConfigureAwait(false);
        await taskH.ConfigureAwait(false);
        await taskI.ConfigureAwait(false);
        await taskJ.ConfigureAwait(false);
        await taskK.ConfigureAwait(false);
        await taskL.ConfigureAwait(false);
        await taskM.ConfigureAwait(false);
        await taskN.ConfigureAwait(false);
        await taskO.ConfigureAwait(false);
    }

    [Benchmark]
    public async Task AwaitTasksUsingWhenAll()
    {
        var tasks = new List<Task>()
        {
            SomeTask(),
            SomeTask(),
            SomeTask(),
            SomeTask(),
            SomeTask(),
            SomeTask(),
            SomeTask(),
            SomeTask(),
            SomeTask(),
            SomeTask(),
            SomeTask(),
            SomeTask(),
            SomeTask(),
            SomeTask(),
            SomeTask(),
        };

        await Task.WhenAll(tasks).ConfigureAwait(false);
    }

    public async Task SomeTask()
    {
        await Task.Delay(500);
    }
}
