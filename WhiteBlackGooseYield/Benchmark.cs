namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using BenchmarkDotNet.Jobs;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    [Params(10_000)]
    public int Count { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    static void BlackBox<T>(T _) {}

    [Benchmark(Baseline = true)]
    public Task NoYield()
    {
        for (int i = 0; i < Count; i++)
        {
            BlackBox(i);
        }

        return Task.CompletedTask;
    }

    [Benchmark]
    public async Task TaskYield()
    {
        for (int i = 0; i < Count; i++)
        {
            BlackBox(i);
            await Task.Yield();
        }
    }

    [Benchmark]
    public Task ThreadYield()
    {
        for (int i = 0; i < Count; i++)
        {
            BlackBox(i);
            Thread.Yield();
        }

        return Task.CompletedTask;
    }
}
