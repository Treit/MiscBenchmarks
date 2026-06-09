namespace Test;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

public class OccurrencesItem
{
    public char Character { get; set; }
    public int Occurrences { get; set; }
    public int Code { get; set; }
}

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    private string _input = string.Empty;

    [Params(500)]
    public int Size { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        var rng = new Random(42);
        var chars = new char[Size];
        for (int i = 0; i < Size; i++)
        {
            chars[i] = (char)('a' + rng.Next(0, 26));
        }
        _input = new string(chars);
    }

    [Benchmark(Baseline = true)]
    public int GroupByWithOccurencesItem()
    {
        var total = 0;
        foreach (var item in OccurrencesGroupBy(_input))
        {
            total += item.Occurrences;
        }
        return total;
    }

    [Benchmark]
    public int CountBy()
    {
        var total = 0;
        foreach (var kvp in OccurrencesCountBy(_input))
        {
            total += kvp.Value;
        }
        return total;
    }

    [Benchmark]
    public int DictionaryLoop()
    {
        var total = 0;
        foreach (var kvp in OccurrencesDictionary(_input))
        {
            total += kvp.Value;
        }
        return total;
    }

    static IOrderedEnumerable<OccurrencesItem> OccurrencesGroupBy(string str) =>
        str
            .ToCharArray()
            .GroupBy(chr => chr)
            .Select(grp => new OccurrencesItem
            {
                Character = grp.Key,
                Occurrences = grp.Count(),
                Code = Convert.ToInt32((int)grp.Key)
            })
            .ToList()
            .OrderBy(item => item.Character.ToString());

    static IOrderedEnumerable<KeyValuePair<char, int>> OccurrencesCountBy(string str) =>
        str
            .CountBy(ch => ch)
            .OrderBy(x => x.Key);

    static IOrderedEnumerable<KeyValuePair<char, int>> OccurrencesDictionary(string str)
    {
        var counts = new Dictionary<char, int>();
        foreach (var ch in str)
        {
            counts.TryGetValue(ch, out var c);
            counts[ch] = c + 1;
        }
        return counts.OrderBy(x => x.Key);
    }
}
