namespace Test;

using BenchmarkDotNet.Attributes;
using System;
using System.Threading;

[MemoryDiagnoser]
public class Benchmark
{
    [Params(10, 100, 10_000)]
    public int Count { get; set; } = 100_000;

    CancellationTokenSource _cts;

    Random _rnd;
    double[] _numbers;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _cts = new CancellationTokenSource();
        _rnd = new Random(1);
        _numbers = new double[Count];
        for (var i = 0; i < Count; i++)
        {
            _numbers[i] = _rnd.NextDouble();
        }
    }

    [Benchmark(Baseline = true)]
    public int IndexOfMaxForLoop()
    {
        var nums = _numbers;
        return IndexOfMaxForLoop(nums);
    }

    [Benchmark]
    public int IndexOfMaxForLoopWithCancelCheck()
    {
        var nums = _numbers;
        return IndexOfMaxForLoopCancelCheck(nums);
    }

    private int IndexOfMaxForLoopCancelCheck(double[] arr)
    {
        int indexOfMax = 0;
        double currentVal = arr[0];
        for (int i = 1; i < arr.Length; i++)
        {
            ThrowIfCancellationRequested();
            if (arr[i] > currentVal)
            {
                indexOfMax = i;
                currentVal = arr[i];
            }
        }

        return indexOfMax;
    }

    private int IndexOfMaxForLoop(double[] arr)
    {
        int indexOfMax = 0;
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] > arr[indexOfMax])
            {
                indexOfMax = i;
            }
        }

        return indexOfMax;
    }

    private void ThrowIfCancellationRequested()
    {
        _cts.Token.ThrowIfCancellationRequested();
    }
}