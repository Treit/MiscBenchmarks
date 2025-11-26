using System.Text;

namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using System;
using System.Linq;
using System.Text.Json;
using BenchmarkDotNet.Jobs;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    [Params(10, 1000, 1_000_000)]
    public int Count { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
    }

    [Benchmark(Baseline = true)]
    public long SerializeGCMemoryInfo()
    {
        var memoryInfo = GC.GetGCMemoryInfo(GCKind.FullBlocking);
        long total = 0;

        for (int i = 0; i < Count; i++)
        {
            var serializedMemoryInfo = JsonSerializer.Serialize(new
            {
                memoryInfo.HighMemoryLoadThresholdBytes,
                memoryInfo.MemoryLoadBytes,
                memoryInfo.TotalAvailableMemoryBytes,
                memoryInfo.HeapSizeBytes,
                memoryInfo.FragmentedBytes,
                memoryInfo.Index,
                memoryInfo.Generation,
                memoryInfo.Compacted,
                memoryInfo.Concurrent,
                memoryInfo.TotalCommittedBytes,
                memoryInfo.PromotedBytes,
                memoryInfo.PinnedObjectsCount,
                memoryInfo.FinalizationPendingCount,
                PauseDurations = memoryInfo.PauseDurations.ToArray(),
                memoryInfo.PauseTimePercentage,
                GenerationInfo = memoryInfo.GenerationInfo.ToArray()
            });

            total += serializedMemoryInfo.Length;
        }

        return total;
    }

    [Benchmark]
    public long SerializeGCMemoryInfoWithUnnecessarySelect()
    {
        var memoryInfo = GC.GetGCMemoryInfo(GCKind.FullBlocking);
        long total = 0;

        for (int i = 0; i < Count; i++)
        {
            var serializedMemoryInfo = JsonSerializer.Serialize(new
            {
                memoryInfo.HighMemoryLoadThresholdBytes,
                memoryInfo.MemoryLoadBytes,
                memoryInfo.TotalAvailableMemoryBytes,
                memoryInfo.HeapSizeBytes,
                memoryInfo.FragmentedBytes,
                memoryInfo.Index,
                memoryInfo.Generation,
                memoryInfo.Compacted,
                memoryInfo.Concurrent,
                memoryInfo.TotalCommittedBytes,
                memoryInfo.PromotedBytes,
                memoryInfo.PinnedObjectsCount,
                memoryInfo.FinalizationPendingCount,
                PauseDurations = memoryInfo.PauseDurations.ToArray().Select(x => x.ToString()),
                memoryInfo.PauseTimePercentage,
                GenerationInfo = memoryInfo.GenerationInfo.ToArray()
            });

            total += serializedMemoryInfo.Length;
        }

        return total;
    }
}
