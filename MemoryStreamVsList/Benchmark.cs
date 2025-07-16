namespace Test;
using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using System.IO;

[MemoryDiagnoser]
public class Benchmark
{
    [Params(1, 1000, 100_000)]
    public int Count {  get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
    }

    [Benchmark(Baseline = true)]
    public byte[] WriteMemoryStream()
    {
        var ms = new MemoryStream();

        for (int i = 0; i < Count; i++)
        {
            ms.WriteByte(123);
        }

        return ms.ToArray();
    }

    [Benchmark]
    public byte[] WriteListOfByte()
    {
        var list = new List<byte>();

        for (int i = 0; i < Count; i++)
        {
            list.Add(123);
        }

        return list.ToArray();
    }

    [Benchmark]
    public byte[] WriteMemoryStreamWithInitialCapacity()
    {
        var ms = new MemoryStream(Count);

        for (int i = 0; i < Count; i++)
        {
            ms.WriteByte(123);
        }

        return ms.ToArray();
    }

    [Benchmark]
    public byte[] WriteListOfByteWithInitialCapacity()
    {
        var list = new List<byte>(Count);

        for (int i = 0; i < Count; i++)
        {
            list.Add(123);
        }

        return list.ToArray();
    }
}
