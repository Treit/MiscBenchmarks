namespace InterlockedIncrement;

using BenchmarkDotNet.Attributes;
using System.Threading;

[MemoryDiagnoser]
public class Benchmark
{
    [Params(100, 10000)]
    public int Count { get; set; }

    private int _counter;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _counter = 0;
    }

    [Benchmark(Baseline = true)]
    public int PlainIncrement()
    {
        int result = 0;
        for (int i = 0; i < Count; i++)
        {
            result = ++_counter;
        }
        return result;
    }

    [Benchmark]
    public int InterlockedIncrementMethod()
    {
        int result = 0;
        for (int i = 0; i < Count; i++)
        {
            result = Interlocked.Increment(ref _counter);
        }
        return result;
    }
}
