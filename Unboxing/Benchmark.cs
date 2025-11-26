namespace Test;
using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using BenchmarkDotNet.Jobs;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    [Params(1000, 100_000)]
    public int Count { get; set; }

    private List<int> _intList;
    private List<object> _boxedIntList;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _intList = new List<int>(Count);
        _boxedIntList = new List<object>(Count);

        for (int i = 0; i < Count; i++)
        {
            _intList.Add(i);
            _boxedIntList.Add(i);
        }
    }

    [Benchmark(Baseline = true)]
    public int SumIntListWithoutUnboxing()
    {
        int sum = 0;

        for (int i = 0; i < _intList.Count; i++)
        {
            sum += _intList[i];
        }

        return sum;
    }

    [Benchmark]
    public int SumObjectListWithUnboxing()
    {
        int sum = 0;

        for (int i = 0; i < _boxedIntList.Count; i++)
        {
            sum += (int)_boxedIntList[i];
        }

        return sum;
    }
}
