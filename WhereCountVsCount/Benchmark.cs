namespace Test;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Jobs;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    private IEnumerable<string> _strings;

    [Params(10, 10_000)]
    public int Count { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        var strings = new string[Count];
        _strings = strings;

        for (int i = 0; i < Count; i++)
        {
            if (i % 10 == 0)
            {
                strings[i] = ("");
            }
            else
            {
                strings[i] = i.ToString();
            }
        }
    }

    [Benchmark]
    public int WhereDotCount()
    {
        return _strings.Where(x => x.Length > 0).Count();
    }

    [Benchmark(Baseline = true)]
    public int CountWithPredicate()
    {
        return _strings.Count(x => x.Length > 0);
    }
}
