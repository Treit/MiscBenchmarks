namespace Test;
using BenchmarkDotNet.Attributes;
using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using BenchmarkDotNet.Jobs;

[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]

public class Benchmark
{
    private List<byte[]> _data;

    [Params(100)]
    public int Size { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        _data = new List<byte[]>();

        var r = new Random(Size);

        for (int i = 0; i < Size; i++)
        {
            var buff = new byte[8];
            r.NextBytes(buff);
            _data.Add(buff);
        }
    }

    [Benchmark]
    public long ToLongBitConverter()
    {
        var result = 0L;

        foreach (var buff in _data)
        {
            var val = BitConverter.ToInt64(buff);
            result = Math.Max(result, val);
        }

        return result;
    }

    [Benchmark]
    public long ToLongBinaryPrimitivesLittleEndian()
    {
        var result = 0L;

        foreach (var buff in _data)
        {
            var val = BinaryPrimitives.ReadInt64LittleEndian(buff);
            result = Math.Max(result, val);
        }

        return result;
    }

    [Benchmark]
    public long ToLongMemoryMarshalCast()
    {
        var result = 0L;

        foreach (var buff in _data)
        {
            var val = MemoryMarshal.Read<long>(buff);
            result = Math.Max(result, val);
        }

        return result;
    }
}
