using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Test;
[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    private IEnumerable<int> _values;

    [Params(1000, 1_000_000)]
    public int Count { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        var tempList = new List<int>(Count);
        for (int i = 0; i < Count;i++ )
        {
            tempList.Add(Random.Shared.Next(0, 500_001));
        }

        _values = tempList.Where(x => x > 50_000);
    }

    [Benchmark(Baseline = true)]
    public long ForEach()
    {
        var result = 0L;
        foreach (var val in _values)
        {
            result += val;
        }

        return result;
    }

    [Benchmark]
    public long ToListDotForEach()
    {
        var result = 0L;
        _values.ToList().ForEach(x => result += x);
        return result;
    }
}
