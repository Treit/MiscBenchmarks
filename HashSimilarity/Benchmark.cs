namespace Test;
using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using BenchmarkDotNet.Jobs;

[MemoryRandomization]
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    [Params(100, 10_000)]
    public int Count { get; set; }

    private List<byte[]> _buffers;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _buffers = new List<byte[]>(Count);
        var r = new Random();

        for (int i = 0; i < Count; i++)
        {
            var buffer = new byte[64];
            r.NextBytes(buffer);
            _buffers.Add(buffer);
        }
    }

    [Benchmark]
    public int CheckHashesNoLookup()
    {
        Span<byte> target = _buffers[0].AsSpan();
        int maxConfidence = 0;

        foreach (var buffer in _buffers)
        {
            var confidence = LSHash.ConfidenceNoLookup(target, buffer.AsSpan());

            if (confidence > maxConfidence)
            {
                maxConfidence = confidence;
            }
        }

        return maxConfidence;
    }

    [Benchmark]
    public int CheckHashesOriginalWithLookup()
    {
        Span<byte> target = _buffers[0].AsSpan();
        int maxConfidence = 0;

        foreach (var buffer in _buffers)
        {
            var confidence = LSHash.Confidence(target, buffer.AsSpan());
            if (confidence > maxConfidence)
            {
                maxConfidence = confidence;
            }
        }

        return maxConfidence;
    }

    [Benchmark]
    public int CheckHashesWithSpanTable()
    {
        Span<byte> target = _buffers[0].AsSpan();
        int maxConfidence = 0;

        foreach (var buffer in _buffers)
        {
            var confidence = LSHash.ConfidenceWithSpanTable(target, buffer.AsSpan());
            if (confidence > maxConfidence)
            {
                maxConfidence = confidence;
            }
        }

        return maxConfidence;
    }

    [Benchmark]
    public int CheckHashesKozi()
    {
        Span<byte> target = _buffers[0].AsSpan();
        int maxConfidence = 0;

        foreach (var buffer in _buffers)
        {
            var confidence = LSHash.ConfidenceWithSpanTableKozi(target, buffer.AsSpan());
            if (confidence > maxConfidence)
            {
                maxConfidence = confidence;
            }
        }

        return maxConfidence;
    }

    [Benchmark]
    public uint CheckHashesTechPizza()
    {
        Span<byte> target = _buffers[0].AsSpan();
        uint maxConfidence = 0;

        foreach (var buffer in _buffers)
        {
            var confidence = LSHash.ConfidenceWithSpanTableTechPizza(target, buffer.AsSpan());
            if (confidence > maxConfidence)
            {
                maxConfidence = confidence;
            }
        }

        return maxConfidence;
    }

    [Benchmark]
    public uint CheckHashesSauceControl()
    {
        Span<byte> target = _buffers[0].AsSpan();
        uint maxConfidence = 0;

        foreach (var buffer in _buffers)
        {
            var confidence = LSHash.ConfidenceSauceControl(target, buffer.AsSpan());
            if (confidence > maxConfidence)
            {
                maxConfidence = confidence;
            }
        }

        return maxConfidence;
    }

    [Benchmark]
    public uint CheckHashesSauceControlUnrolledKozi()
    {
        Span<byte> target = _buffers[0].AsSpan();
        uint maxConfidence = 0;

        foreach (var buffer in _buffers)
        {
            var confidence = LSHash.ConfidenceSauceControlUnrolledKozi(target, buffer.AsSpan());
            if (confidence > maxConfidence)
            {
                maxConfidence = confidence;
            }
        }

        return maxConfidence;
    }

    [Benchmark]
    public int CheckHashesHugeLookupTable()
    {
        var target = MemoryMarshal.Cast<byte, ushort>(_buffers[0].AsSpan());
        int maxConfidence = 0;

        foreach (var buffer in _buffers)
        {
            var confidence = LSHash.ConfidenceWithUShortTable(target, MemoryMarshal.Cast<byte, ushort>(buffer.AsSpan()));
            if (confidence > maxConfidence)
            {
                maxConfidence = confidence;
            }
        }

        return maxConfidence;
    }

    [Benchmark]
    public int CheckHashesSauceControlUnrolled()
    {
        Span<byte> target = _buffers[0].AsSpan();
        int maxConfidence = 0;

        foreach (var buffer in _buffers)
        {
            var confidence = LSHash.ConfidenceSauceControlUnrolled(target, buffer.AsSpan());
            if (confidence > maxConfidence)
            {
                maxConfidence = confidence;
            }
        }

        return maxConfidence;
    }

    [Benchmark]
    public int CheckHashesSauceControlUnrolledHugeLookup()
    {
        var target = MemoryMarshal.Cast<byte, ushort>(_buffers[0].AsSpan());
        int maxConfidence = 0;

        foreach (var buffer in _buffers)
        {
            var confidence = LSHash.ConfidenceSauceControlUnrolledHugeLookup(target, MemoryMarshal.Cast<byte, ushort>(buffer.AsSpan()));
            if (confidence > maxConfidence)
            {
                maxConfidence = confidence;
            }
        }

        return maxConfidence;
    }

    [Benchmark]
    public int CheckHashesSseKozidHugeLookup()
    {
        var target = MemoryMarshal.Cast<byte, ushort>(_buffers[0].AsSpan());
        int maxConfidence = 0;

        foreach (var buffer in _buffers)
        {
            var confidence = LSHash.ConfidenceSseKozi(target, MemoryMarshal.Cast<byte, ushort>(buffer.AsSpan()));
            if (confidence > maxConfidence)
            {
                maxConfidence = confidence;
            }
        }

        return maxConfidence;
    }

    [Benchmark]
    public int CheckHashesSauceControlSse()
    {
        var target = _buffers[0];
        int maxConfidence = 0;

        foreach (var buffer in _buffers)
        {
            var confidence = LSHash.ConfidenceSauceControlSse2(target, buffer);
            if (confidence > maxConfidence)
            {
                maxConfidence = confidence;
            }
        }

        return maxConfidence;
    }

    [Benchmark]
    public int CheckHashesSauceControlFirstAvx()
    {
        var target = _buffers[0];
        int maxConfidence = 0;

        foreach (var buffer in _buffers)
        {
            var confidence = LSHash.ConfidenceSauceControlFirstAvx2(target, buffer);
            if (confidence > maxConfidence)
            {
                maxConfidence = confidence;
            }
        }

        return maxConfidence;
    }

    [Benchmark]
    public int CheckHashesSauceControlSecondAvx()
    {
        var target = _buffers[0];
        int maxConfidence = 0;

        foreach (var buffer in _buffers)
        {
            var confidence = LSHash.ConfidenceSauceControlSecondAvx2(target, buffer);

            if (confidence > maxConfidence)
            {
                maxConfidence = confidence;
            }
        }

        return maxConfidence;
    }

    [Benchmark]
    public int CheckHashesSauceControlThirdAvx()
    {
        var target = _buffers[0];
        int maxConfidence = 0;

        foreach (var buffer in _buffers)
        {
            var confidence = LSHash.ConfidenceSauceControlThirdAvx2(target, buffer);

            if (confidence > maxConfidence)
            {
                maxConfidence = confidence;
            }
        }

        return maxConfidence;
    }

    [Benchmark(Baseline = true)]
    public int CheckHashesSauceControlFourthAvx()
    {
        var target = _buffers[0];
        int maxConfidence = 0;

        foreach (var buffer in _buffers)
        {
            var confidence = LSHash.ConfidenceSauceControlFourthAvx2(target, buffer);

            if (confidence > maxConfidence)
            {
                maxConfidence = confidence;
            }
        }

        return maxConfidence;
    }
}
