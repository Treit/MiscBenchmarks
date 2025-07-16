namespace Test;
using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;

public class Benchmark
{
    [Params(1000)]
    public int Count { get; set; }

    private int[] _values;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _values = new int[Count];

        // Use Count as the seed.
        var r = new Random(Count);

        for (int i = 0; i < Count; i++)
        {
            _values[i] = r.Next(16);
        }
    }

    [Benchmark]
    public void BubbleSortUsingTempVariable()
    {
        var cmp = Comparer<int>.Default;
        int temp = 0;

        for (int i = 0; i < _values.Length; i++)
        {
            for (int j = 0; j < _values.Length - i - 1; j++)
            {
                if (cmp.Compare(_values[j], _values[j + 1]) > 0)
                {
                    temp = _values[j + 1];
                    _values[j + 1] = _values[j];
                    _values[j] = temp;
                }
            }
        }
    }

    [Benchmark]
    public void BubbleSortUsingSwapFunction()
    {
        var cmp = Comparer<int>.Default;

        for (int i = 0; i < _values.Length; i++)
        {
            for (int j = 0; j < _values.Length - i - 1; j++)
            {
                if (cmp.Compare(_values[j], _values[j + 1]) > 0)
                {
                    Swap(_values, j, j + 1);
                }
            }
        }

        void Swap(int[] values, int i, int j)
        {
            int tmp = values[i];
            values[i] = values[j];
            values[j] = tmp;
        }
    }

    [Benchmark]
    public void BubbleSortUsingTupleToSwap()
    {
        var cmp = Comparer<int>.Default;

        for (int i = 0; i < _values.Length; i++)
        {
            for (int j = 0; j < _values.Length - i - 1; j++)
            {
                if (cmp.Compare(_values[j], _values[j + 1]) > 0)
                {
                    (_values[j], _values[j + 1]) = (_values[j + 1], _values[j]);
                }
            }
        }
    }
}
