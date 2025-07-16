namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using System;
using System.Collections.Generic;

[MemoryDiagnoser]
public class Benchmark
{
    [Params(10, 100, 10_000)]
    public int Count { get; set; }

    private List<string> _strings;
    private List<char[]> _stringAsChars;
    private List<int[]> _stringsAsInts;
    private readonly int[] _searchPositions = new int[4] { 0, 4, 10, 16 };
    private List<IntPtr> _stringsAsBytePointers;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _strings = new List<string>(Count);
        _stringAsChars = new List<char[]>(Count);
        _stringsAsInts = new List<int[]>(Count);
        _stringsAsBytePointers = new List<IntPtr>(Count);

        for (int i = 0; i < Count; i++)
        {
            string s = Guid.NewGuid().ToString();
            _strings.Add(s);
            _stringAsChars.Add(s.ToCharArray());

            unsafe
            {
                fixed (void* p = s)
                {
                    _stringsAsBytePointers.Add(new IntPtr(p));
                }
            }

            int[] intVals = new int[s.Length];

            for (int j = 0; j < s.Length; j++)
            {
                intVals[j] = s[j];
            }

            _stringsAsInts.Add(intVals);
        }
    }

    [Benchmark(Baseline = true)]
    public long FindIndexesInString()
    {
        long total = 0;

        foreach (var s in _strings)
        {
            foreach (int i in _searchPositions)
            {
                if (s[i] == 'f')
                {
                    total++;
                }
            }
        }

        return total;
    }

    [Benchmark]
    public long FindIndexesInIntArray()
    {
        long total = 0;

        foreach (var s in _stringsAsInts)
        {
            foreach (int i in _searchPositions)
            {
                if (s[i] == 'f')
                {
                    total++;
                }
            }
        }

        return total;
    }

    [Benchmark]
    public long FindIndexesInCharArray()
    {
        long total = 0;

        foreach (var s in _stringAsChars)
        {
            foreach (int i in _searchPositions)
            {
                if (s[i] == 'f')
                {
                    total++;
                }
            }
        }

        return total;
    }

    [Benchmark]
    public long FindIndexesPointerArithmeticIntoCharArray()
    {
        long total = 0;

        unsafe
        {
            foreach (var s in _stringAsChars)
            {
                fixed (char* p = s)
                {
                    foreach (int i in _searchPositions)
                    {
                        if (*(p + i) == 'f')
                        {
                            total++;
                        }
                    }
                }
            }
        }

        return total;
    }

    [Benchmark]
    public long FindIndexesBytePointers()
    {
        long total = 0;

        unsafe
        {
            foreach (var s in _stringsAsBytePointers)
            {
                foreach (int i in _searchPositions)
                {
                    if (*((byte*)(s.ToPointer()) + i) == 'f')
                    {
                        total++;
                    }
                }
            }
        }

        return total;
    }
}
