namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using System.Collections.Generic;
using System.Linq;

[MemoryDiagnoser]
public class Benchmark
{
    private static Dictionary<string, string> _defaultDimensions;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _defaultDimensions = new Dictionary<string, string>()
        {
            { "dim1", "value1" },
            { "dim2", "value2" },
            { "dim3", "value3" },
            { "dim4", "value4" },
            { "dim5", "value5" },
            { "dim6", "value6" },
            { "dim7", "value7" },
            { "dim8", "value8" },
            { "dim9", "value9" },
            { "dim10", "value10" },
        };
    }

    [Benchmark]
    public int BuildDictionaryAndThenUseToArray()
    {
        var dimensions = new Dictionary<string, string>()
        {
            { "adim1", "value1" },
            { "adim2", "value2" },
            { "adim3", "value3" },
            { "adim4", "value4" },
            { "adim5", "value5" },
            { "adim6", "value6" },
            { "adim7", "value7" },
            { "adim8", "value8" },
            { "adim9", "value9" },
            { "adim10", "value10" },
        };

        var updated = MergeAndSanitizeDimensionsToDictionary(dimensions);

        var first = DoSomething(updated.Keys.ToArray());
        var second = DoSomething(updated.Values.ToArray());

        return first + second;
    }

    [Benchmark(Baseline = true)]
    public int BuildTwoArraysDirectly()
    {
        var dimensions = new Dictionary<string, string>()
        {
            { "adim1", "value1" },
            { "adim2", "value2" },
            { "adim3", "value3" },
            { "adim4", "value4" },
            { "adim5", "value5" },
            { "adim6", "value6" },
            { "adim7", "value7" },
            { "adim8", "value8" },
            { "adim9", "value9" },
            { "adim10", "value10" },
        };

        var (keys, values) = MergeAndSanitizeDimensionsToArrays(dimensions);

        var first = DoSomething(keys);
        var second = DoSomething(values);

        return first + second;
    }

    private static int DoSomething(params string[] items)
    {
        int i = 0;

        foreach (var item in items)
        {
            i += item.Length;
        }

        return i;
    }

    private static IDictionary<string, string> MergeAndSanitizeDimensionsToDictionary(
        IDictionary<string, string> dimensions)
    {
        var cleanDimensions = new Dictionary<string, string>(_defaultDimensions);
        foreach (var kvp in dimensions)
        {
            if (!string.IsNullOrWhiteSpace(kvp.Key))
            {
                cleanDimensions[kvp.Key] = string.IsNullOrWhiteSpace(kvp.Value) ? "NULL" : kvp.Value;
            }
        }

        return cleanDimensions;
    }

    private static (string[], string[]) MergeAndSanitizeDimensionsToArrays(
        IDictionary<string, string> dimensions)
    {
        var dimensionsCount = dimensions?.Count ?? 0;
        var finalCount = dimensionsCount + _defaultDimensions.Count;

        var cleanedKeys = new string[finalCount];
        var cleanedValues = new string[finalCount];
        var i = 0;

        foreach (var kvp in _defaultDimensions)
        {
            cleanedKeys[i] = kvp.Key;
            cleanedValues[i] = kvp.Value;
            i++;
        }

        if (dimensions is null || dimensions.Count == 0)
        {
            return (cleanedKeys, cleanedValues);
        }

        foreach (var kvp in dimensions)
        {
            if (!string.IsNullOrWhiteSpace(kvp.Key))
            {
                cleanedKeys[i] = kvp.Key;
                cleanedValues[i] = string.IsNullOrWhiteSpace(kvp.Value) ? "NULL" : kvp.Value;
                i++;
            }
        }

        return (cleanedKeys, cleanedValues);
    }
}
