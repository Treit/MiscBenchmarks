namespace Test;
using BenchmarkDotNet.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using BenchmarkDotNet.Jobs;

[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]

public class Benchmark
{
    HashSet<int> _hashset = new HashSet<int>(600);
    BitArray _bitarray = new BitArray(600);

    [GlobalSetup]
    public void GlobalSetup()
    {
        for (int i = 0; i < 600; i++)
        {
            var val = Random.Shared.Next(0, 600);
            _hashset.Add(val);
            _bitarray[val] = true;
        }
    }

    [Benchmark]
    public int LookupUsingHashSet()
    {
        var result = 0;
        for (int i = 0; i < 600; i++)
        {
            if (_hashset.Contains(i))
            {
                result++;
            }
        }

        return result;
    }

    [Benchmark(Baseline = true)]
    public int LookupUsingBitArray()
    {
        var result = 0;
        for (int i = 0; i < 600; i++)
        {
            if (_bitarray[i])
            {
                result++;
            }
        }

        return result;
    }
}
