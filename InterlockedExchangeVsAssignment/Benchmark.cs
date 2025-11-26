namespace Test;
using BenchmarkDotNet.Attributes;
using System.Threading;
using BenchmarkDotNet.Jobs;

[DisassemblyDiagnoser(exportDiff: true, exportHtml: true)]
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    object _lock = new();
    long _target;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _target = 1234;
    }

    [Benchmark(Baseline = true)]
    public long SetToZeroSimpleAssignment()
    {
        _target = 0;
        return _target;
    }

    [Benchmark]
    public long SetToZeroWithInterlockedExchange()
    {
        Interlocked.Exchange(ref _target, 0);
        return _target;
    }
}
