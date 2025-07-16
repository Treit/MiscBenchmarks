namespace Test;
using BenchmarkDotNet.Attributes;

public class Benchmark
{
    [Params(10, 1000, 1_000_000)]
    public int Count { get; set; }

    private object[] _objects;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _objects = new object[Count];

        for (int i = 0; i < Count; i++)
        {
            _objects[i] = i;
        }
    }

    [Benchmark(Baseline = true)]
    public long AsCast()
    {
        long result = 0;

        foreach (var obj in _objects)
        {
            result += (obj as int?).Value;
        }

        return result;
    }

    [Benchmark]
    public long DirectCast()
    {
        long result = 0;

        foreach (var obj in _objects)
        {
            result += ((int?)obj).Value;
        }

        return result;
    }
}
