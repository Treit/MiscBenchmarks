namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using System.Threading;
using System.Threading.Tasks;

[MemoryDiagnoser]
public class Benchmark
{
    [Params(10_000)]
    public int Count { get; set; }

    int _counter = 0;
    object _lock = new object();
    Semaphore _semaphore = new Semaphore(1, 1);
    SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(1, 1);

    [GlobalSetup]
    public void GlobalSetup()
    {
    }

    [IterationSetup]
    public void IterationSetup()
    {
        _counter = 0;
    }

    [Benchmark(Baseline = true)]
    public int IncrementUsingInterlocked()
    {
        Parallel.For(0, Count, _ =>
        {
            Interlocked.Increment(ref _counter);
        });

        return _counter;
    }

    [Benchmark]
    public int IncrementUsingLock()
    {
        Parallel.For(0, Count, _ =>
        {
            lock (_lock)
            {
                _counter++;
            }
        });

        return _counter;

    }

    [Benchmark]
    public int IncrementUsingSemaphore()
    {
        Parallel.For(0, Count, _ =>
        {
            _semaphore.WaitOne();
            try 
            {
                _counter++; 
            }
            finally
            {
                _semaphore.Release();
            }
        });

        return _counter;

    }

    [Benchmark]
    public int IncrementUsingSemaphoreSlim()
    {
        Parallel.For(0, Count, _ =>
        {
            _semaphoreSlim.Wait();
            try 
            {
                _counter++; 
            }
            finally
            {
                _semaphoreSlim.Release();
            }
        });

        return _counter;

    }
}
