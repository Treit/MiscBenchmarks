namespace Test;
using BenchmarkDotNet.Attributes;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

[MemoryDiagnoser]
public class Benchmark
{
    MemoryStream _ms;

    [Params(1000, 100_000, 1_000_000)]
    public int Count { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        var r = new Random();
        _ms = new MemoryStream();
        var buffer = new byte[Count];
        r.NextBytes(buffer);

        _ms.Write(buffer, 0, Count);
    }

    [Benchmark(Baseline = true)]
    public byte[] ReadMemoryStream()
    {
        var buffer = new byte[256];

        while (true)
        {
            var read = _ms.Read(buffer, 0, buffer.Length);

            if (read == 0)
            {
                break;
            }
        }

        return buffer;
    }

    [Benchmark]
    public async Task<byte[]> ReadMemoryStreamAsync()
    {
        var buffer = new byte[256];

        while (true)
        {
            var read = await _ms.ReadAsync(buffer, 0, buffer.Length);

            if (read == 0)
            {
                break;
            }
        }

        return buffer;
    }

    [Benchmark]
    public async Task<byte[]> ReadMemoryStreamAsyncCancelTokenOverload()
    {
        var buffer = new byte[256];

        while (true)
        {
            var read = await _ms.ReadAsync(buffer, CancellationToken.None);

            if (read == 0)
            {
                break;
            }
        }

        return buffer;
    }
}
