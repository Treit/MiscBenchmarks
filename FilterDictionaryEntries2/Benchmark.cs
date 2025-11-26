namespace Test;
using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Jobs;

public record Instrument(int InstrumentId, string InstrumentName);
public record Profile(
    string Value,
    bool IsLowConfidence,
    bool IsOfInterest,
    bool IsLowLevel,
    bool IsFlagged);

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    private List<Instrument> _candidates;
    private Dictionary<int, Profile> _profiles;

    [Params(100, 10_000)]
    public int Count { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        _candidates = new List<Instrument>(Count);
        var random = new Random(Count);

        for (int i = 0; i < Count; i++)
        {
            _candidates.Add(new Instrument(i, $"Instrument {i}"));
        }

        _profiles = new Dictionary<int, Profile>(Count);
        for (int i = 0; i < Count; i++)
        {
            _profiles.Add(i, new Profile(
                $"Profile {i}",
                true,
                random.Next(0, 10) == 0,
                random.Next(0, 10) == 0,
                random.Next(0, 10) == 0));
        }
    }

    [Benchmark(Baseline = true)]
    public Instrument[] FilterUsingContainsKey ()
    {
        var validCandidates = _candidates.Where(
                p => _profiles.ContainsKey(p.InstrumentId)).ToArray();

        return validCandidates;
    }

    [Benchmark]
    public Instrument[] FilterUsingSelectToListContains()
    {
        var validCandidates = _candidates.Where(
                p => _profiles.Select(x => x.Key).ToList().Contains(p.InstrumentId) ).ToArray();

        return validCandidates;
    }

    [Benchmark]
    public Instrument[] FilterUsingHashSet()
    {
        var profileKeys = new HashSet<int>(_profiles.Keys);
        var validCandidates = _candidates.Where(
                p => profileKeys.Contains(p.InstrumentId)).ToArray();

        return validCandidates;
    }
}
