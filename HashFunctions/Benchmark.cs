namespace Test;
using BenchmarkDotNet.Attributes;
using System;
using System.Buffers.Binary;
using System.IO.Hashing;
using System.Runtime.InteropServices;

[MemoryDiagnoser]
public class Benchmark
{
    private byte[] _data;

    [Params(1024)]
    public int Size { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        _data = new byte[Size];
        var r = new Random(Size);
        r.NextBytes(_data);
    }

    [Benchmark]
    public int HashJenkins()
    {
        return HashUtils.JenkinsHash(_data);
    }

    [Benchmark]
    public uint HashCRC32()
    {
        return HashUtils.CRC32(_data);
    }

    [Benchmark]
    public int HashSystemIOHashingCRC32()
    {
        var crc32 = new Crc32();
        crc32.Append(_data);
        return BinaryPrimitives.ReadInt32LittleEndian(crc32.GetCurrentHash());
    }

    [Benchmark]
    public int HashMurmur32()
    {
        return (int)HashUtils.MurmurHash32(_data);
    }

    [Benchmark]
    public int HashFNV1_32()
    {
        return (int)HashUtils.FNV1_32(_data);
    }

    [Benchmark(Baseline = true)]
    public int HashMurmur64()
    {
        return (int)HashUtils.MurmurHash64(_data);
    }

    [Benchmark]
    public int HashMD5GoogleGemini()
    {
        return HashUtils.Get32BitHashCodeMD5(_data);
    }

    [Benchmark]
    public long HashFNV1_64()
    {
        return HashUtils.FNV1_64(_data);
    }

    [Benchmark]
    public int HashFNV1_32_StackOverflowLinq()
    {
        return FNVConstants.CreateHash(_data);
    }

    [Benchmark]
    public long Hash64BitUsingSHA2()
    {
        return HashUtils.GetInt64HashCode(_data);
    }

    [Benchmark]
    public long Hash64BitUsingMD5ChatGPT()
    {
        return HashUtils.Get64BitHashUsingMD5(_data);
    }
}
