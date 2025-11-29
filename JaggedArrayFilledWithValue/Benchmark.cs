namespace Test;

using BenchmarkDotNet.Attributes;
using System;
using System.Threading;
using BenchmarkDotNet.Jobs;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    [Params(10, 100, 10_000)]
    public int ElementCount { get; set; } = 100;

    CancellationTokenSource _cts;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _cts = new CancellationTokenSource();
    }

    [Benchmark]
    public int[][] CreateJaggedArrayWithValueWithCancelCheck()
    {
        return CreateArrWithValueWithCancelCheck(ElementCount, ElementCount, 0xFF);
    }

    [Benchmark]
    public int[][] CreateJaggedArrayWithValue()
    {
        return CreateArrWithValue(ElementCount, ElementCount, 0xFF);
    }

    [Benchmark(Baseline = true)]
    public int[][] CreateJaggedArrayWithValueWithArrayFill()
    {
        return CreateArrWithValueUsingFill(ElementCount, ElementCount, 0xFF);
    }

    private T[][] CreateArrWithValueUsingFill<T>(int m, int n, T v)
    {
        T[][] arr = new T[m][];
        for (int i = 0; i < m; i++)
        {
            arr[i] = new T[n];
            Array.Fill(arr[i], v);
        }

        return arr;
    }

    private T[][] CreateArrWithValue<T>(int m, int n, T v)
    {
        T[][] arr = new T[m][];
        for (int i = 0; i < m; i++)
        {
            arr[i] = new T[n];
            for (int j = 0; j < n; j++)
            {
                arr[i][j] = v;
            }
        }

        return arr;
    }

    // create an m by n array with value v
    private T[][] CreateArrWithValueWithCancelCheck<T>(int m, int n, T v)
    {
        T[][] arr = new T[m][];
        for (int i = 0; i < m; i++)
        {
            ThrowIfCancellationRequested();
            arr[i] = new T[n];
            for (int j = 0; j < n; j++)
            {
                ThrowIfCancellationRequested();
                arr[i][j] = v;
            }
        }

        return arr;
    }

    private void ThrowIfCancellationRequested()
    {
        _cts.Token.ThrowIfCancellationRequested();
    }
}