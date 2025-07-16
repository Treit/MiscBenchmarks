namespace Test;
using BenchmarkDotNet.Attributes;
using System;
using System.Buffers.Binary;
using System.IO;
using System.Numerics;
using System.Runtime.InteropServices;

[MemoryDiagnoser]
public class Benchmark
{
    static string s_fileName = "nums.bin";

    [Params(100, 1_000_000)]
    public int Count;

    [GlobalSetup]
    public void GlobalSetup()
    {
        using var fs = new FileStream(s_fileName, FileMode.Create, FileAccess.Write);
        var random = new Random(Count);

        for (int i = 0; i < Count; i++)
        {
            var num = random.Next(1_000_000);
            fs.Write(BitConverter.GetBytes(num));
        }
    }

    [GlobalCleanup]
    public void GlobalCleanup()
    {
        Console.WriteLine("DELETING!");
        File.Delete(s_fileName);
    }

    [Benchmark]
    public long SumDataBitConverter()
    {
        using var fs = new FileStream(s_fileName, FileMode.Open, FileAccess.Read);
        var buffer = new byte[sizeof(int)];
        long sum = 0;

        for (int i = 0; i < Count; i++)
        {
            fs.Read(buffer, 0, sizeof(int));
            sum += BitConverter.ToInt32(buffer);
        }

        return sum;
    }

    [Benchmark]
    public long SumDataBinaryPrimitives
        ()
    {
        var buffer = new byte[1024 * 4];
        using var fs = new FileStream(s_fileName, FileMode.Open, FileAccess.Read);
        var read = 0;
        var sum = 0L;

        while ((read = fs.Read(buffer)) > 0)
        {
            if (read < 4)
            {
                break;
            }

            var span = buffer.AsSpan(0, read);
            while (span.Length >= 4)
            {
                var num = BinaryPrimitives.ReadInt32LittleEndian(span);
                span = span[4..];
                sum += num;
            }
        }

        return sum;
    }

    [Benchmark]
    public long SumDataMemoryMarshalCast()
    {
        var buffer = new byte[1024 * 4];
        using var fs = new FileStream(s_fileName, FileMode.Open, FileAccess.Read);
        var read = 0;
        var sum = 0L;

        while ((read = fs.Read(buffer)) > 0)
        {
            if (read < 4)
            {
                break;
            }

            var span = buffer.AsSpan(0, read);
            var integers = MemoryMarshal.Cast<byte, int>(span);
            foreach (var num in integers)
            {
                sum += num;
            }
        }

        return sum;
    }

    [Benchmark(Baseline = true)]
    public long SumDataMemoryMarshalCastAndVectorizedSum()
    {
        var buffer = new byte[1024 * 4];
        using var fs = new FileStream(s_fileName, FileMode.Open, FileAccess.Read);
        var read = 0;
        var sum = 0L;

        while ((read = fs.Read(buffer)) > 0)
        {
            if (read < 4)
            {
                break;
            }

            var span = buffer.AsSpan(0, read);
            var integers = MemoryMarshal.Cast<byte, int>(span);
            int vectorSize = Vector<int>.Count;
            Vector<int> vectorSum = Vector<int>.Zero;

            int i = 0;
            for (; i <= integers.Length - vectorSize; i += vectorSize)
            {
                var v = new Vector<int>(integers.Slice(i, vectorSize));
                vectorSum += v;
            }

            sum += Vector.Dot(vectorSum, Vector<int>.One);
            for (; i < integers.Length; i++)
            {
                sum += integers[i];
            }
        }

        return sum;
    }
}
