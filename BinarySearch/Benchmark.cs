namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using BenchmarkDotNet.Jobs;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    private static int[] s_data = [];

    [Params(1_000_000)]
    public int Count { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        Random r = new Random();
        s_data = new int[Count];

        for (int i = 0; i < Count; i++)
        {
            s_data[i] = r.Next();
        }

        Array.Sort(s_data);
    }

    [Benchmark]
    public int BinarySearchWithDivide()
    {
        var target = 1_000_000;
        return BinarySearch(s_data, target);
    }

    [Benchmark(Baseline = true)]
    public int BinarySearchWithShift()
    {
        var target = 1_000_000;
        return BinarySearch2(s_data, target);
    }

    [Benchmark]
    public int BinarySearchBCLImplementation()
    {
        var target = 1_000_000;
        return Array.BinarySearch(s_data, target);
    }

    [Benchmark]
    public int BinarySearchGenericBCLImpl()
    {
        var target = 1_000_000;
        return BinarySearch<int>(s_data, 0, s_data.Length, target);
    }

    private static int BinarySearch(int[] array, int numberToFind)
    {
        int low = 0;
        int high = array.Length - 1;

        while (low <= high)
        {
            int mid = low + (high - low) / 2;

            if (array[mid] == numberToFind)
            {
                return mid;
            }

            if (numberToFind < array[mid])
            {
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }

        return -1;
    }

    private static int BinarySearch2(int[] array, int numberToFind)
    {
        int low = 0;
        int high = array.Length - 1;

        while (low <= high)
        {
            int mid = low + ((high - low) >> 1);

            if (array[mid] == numberToFind)
            {
                return mid;
            }

            if (numberToFind < array[mid])
            {
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }

        return -1;
    }

    private static int BinarySearch<T>(T[] array, int index, int length, T value)
        where T : IComparable<T>
    {
        int lo = index;
        int hi = index + length - 1;
        while (lo <= hi)
        {
            int i = lo + ((hi - lo) >> 1);
            int order;
            if (array[i] == null)
            {
                order = (value == null) ? 0 : -1;
            }
            else
            {
                order = array[i].CompareTo(value);
            }

            if (order == 0)
            {
                return i;
            }

            if (order < 0)
            {
                lo = i + 1;
            }
            else
            {
                hi = i - 1;
            }
        }

        return ~lo;
    }
}
