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

    [Benchmark]
    public Instrument[] FilterUsingConvolutedLinq()
    {
        var validCandidates = _candidates
                               .Where(p => _profiles
                               .Where(kvp => !kvp.Value.IsLowConfidence
                               || (kvp.Value.IsLowConfidence && kvp.Value.IsOfInterest)
                               || (kvp.Value.IsLowConfidence && kvp.Value.IsLowLevel)
                               || (kvp.Value.IsLowConfidence && kvp.Value.IsFlagged))
                               .Select(d => d.Key).ToList().Contains(p.InstrumentId)).ToArray();

        return validCandidates;
    }

    [Benchmark(Baseline = true)]
    public Instrument[] FilterUsingCleanedUpPatternMatching()
    {
        var validCandidates = _candidates.Where(
                p => _profiles.TryGetValue(p.InstrumentId, out var item)
                && item is
                { IsLowConfidence: false } or
                { IsOfInterest: true } or
                { IsLowLevel: true } or
                { IsFlagged: true }).ToArray();

        return validCandidates;
    }
}
