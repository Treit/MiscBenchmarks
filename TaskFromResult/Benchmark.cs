namespace Test;
using BenchmarkDotNet.Attributes;
using System.Threading.Tasks;
using BenchmarkDotNet.Jobs;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{

    [GlobalSetup]
    public void GlobalSetup()
    {
    }

    [Benchmark(Baseline = true)]
    public Task<string> TaskFromResult()
    {
        return Task.FromResult("foo");
    }

    [Benchmark]
    public async Task<string> AwaitTaskFromResult()
    {
        return await Task.FromResult("foo");
    }

    [Benchmark]
    public Task ReturnCompletedTask()
    {
        return Task.CompletedTask;
    }

    [Benchmark]
    public async Task AwaitCompletedTask()
    {
        await Task.CompletedTask;
    }
}
