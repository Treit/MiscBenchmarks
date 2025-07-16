namespace Test;
using BenchmarkDotNet.Attributes;
using System;
using System.Buffers.Binary;
using System.Linq;
using System.Text;

[MemoryDiagnoser]
public class Benchmark
{
    uint _encoded = 0x20584F56u;
    byte[] _buffer = new byte[4];

    [GlobalSetup]
    public void GlobalSetup()
    {
    }

    [Benchmark]
    public string UIntToStringUsingLINQ()
    {
        return new string(BitConverter.GetBytes(_encoded).Select(@byte => Convert.ToChar(@byte)).ToArray());
    }

    [Benchmark(Baseline = true)]
    public string UIntToStringUsingBinaryPrimitives()
    {
        var buffer = _buffer;
        BinaryPrimitives.WriteUInt32LittleEndian(buffer, _encoded);
        return Encoding.ASCII.GetString(buffer);
    }
}
