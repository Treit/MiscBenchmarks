using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Test;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    private const int MaxBufferedValueCount = 1_048_576;

    private int[] _int32Values = Array.Empty<int>();
    private long[] _int64Values = Array.Empty<long>();
    private int _valueIndexMask;

    [Params(1_024, 1_048_576, 1_073_741_824)]
    public int Count { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        var bufferedValueCount = Math.Min(Count, MaxBufferedValueCount);

        _int32Values = new int[bufferedValueCount];
        _int64Values = new long[bufferedValueCount];
        _valueIndexMask = bufferedValueCount - 1;

        var random = new Random(42);

        for (var i = 0; i < bufferedValueCount; i++)
        {
            var value = random.Next(1, 100);
            _int32Values[i] = value;
            _int64Values[i] = value;
        }
    }

    [Benchmark(Baseline = true)]
    public int AddInt32Values()
    {
        var values = _int32Values;
        var indexMask = _valueIndexMask;
        var sum = 0;

        for (var i = 0; i < Count; i++)
        {
            sum += values[i & indexMask];
        }

        return sum;
    }

    [Benchmark]
    public long AddInt64Values()
    {
        var values = _int64Values;
        var indexMask = _valueIndexMask;
        var sum = 0L;

        for (var i = 0; i < Count; i++)
        {
            sum += values[i & indexMask];
        }

        return sum;
    }
}
