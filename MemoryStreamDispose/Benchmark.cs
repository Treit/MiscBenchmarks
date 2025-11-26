namespace Test;
using BenchmarkDotNet.Attributes;
using System.IO;
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
    public byte[] WriteMemoryStream()
    {
        var ms = new MemoryStream();

        for (int i = 0; i < 1024; i++)
        {
            ms.WriteByte(123);
        }

        return ms.ToArray();
    }

    [Benchmark]
    public byte[] WriteMemoryStreamWithUsing()
    {
        using var ms = new MemoryStream();

        for (int i = 0; i < 1024; i++)
        {
            ms.WriteByte(123);
        }

        return ms.ToArray();
    }
}
