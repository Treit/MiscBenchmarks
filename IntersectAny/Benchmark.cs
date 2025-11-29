namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using BenchmarkDotNet.Jobs;

public enum NeedleLocation
{
    AtBeginning,
    InMiddle,
    AtEnd
}

[MemoryDiagnoser]
[MemoryRandomization]
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    [Params(10, 100_000)]
    public int Count { get; set; }

    [Params(NeedleLocation.AtBeginning, NeedleLocation.InMiddle, NeedleLocation.AtEnd)]
    public NeedleLocation Location { get; set; }

    private List<string> _listA;
    private List<string> _listB;
    private string[] _arrayA;
    private string[] _arrayB;
    private Random _random;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _random = new Random(Count);

        _listA = new List<string>();
        _listB = new List<string>();

        for (int i = 0; i < Count; i++)
        {
            _listA.Add(RandomStringCreate(_random, 50));
            _listB.Add(RandomStringCreate(_random, 50));
        }

        // Choose the middle
        var needleLocation = Location switch
        {
            NeedleLocation.AtBeginning => 1,
            NeedleLocation.InMiddle => _listA.Count / 2,
            _ => _listA.Count - 1
        };

        // Ensure at least one match.
        _listA[needleLocation] = _listB[needleLocation];

        _arrayA = _listA.ToArray();
        _arrayB = _listB.ToArray();
    }

    [IterationSetup]
    public void IterationSetup()
    {
    }

    [Benchmark(Baseline = true)]
    public bool ListIntersectAnyLinq()
    {
        return _listA.Intersect(_listB).Any();
    }

    [Benchmark]
    public bool ListIntersectAnyNestedLoopAsArray()
    {
        return _listA.IntersectAny(_listB);
    }

    [Benchmark]
    public bool ListIntersectAnyWithHashSet()
    {
        var set = new HashSet<string>(_listA);

        foreach (var item in CollectionsMarshal.AsSpan(_listB))
        {
            if (set.Contains(item))
            {
                return true;
            }
        }

        return false;
    }

    [Benchmark]
    public bool ListIntersectAnyNestedLoop()
    {
        var listA = _listA;
        var listB = _listB;

        for (var i = 0; i < _listA.Count; i++)
        {
            for (var j = 0; j < _listB.Count; j++)
            {
                if (_listA[i] == _listB[j])
                {
                    return true;
                }
            }
        }

        return false;
    }

    [Benchmark]
    public bool ListIntersectAnyNestedLoopWithSpan()
    {
        var spanA = CollectionsMarshal.AsSpan(_listA);
        var spanB = CollectionsMarshal.AsSpan(_listB);

        for (var i = 0; i < spanA.Length; i++)
        {
            for (var j = 0; j < spanB.Length; j++)
            {
                if (spanA[i] == spanB[j])
                {
                    return true;
                }
            }
        }

        return false;
    }

    [Benchmark]
    public bool ArrayIntersectAnyLinq()
    {
        return _arrayA.Intersect(_arrayB).Any();
    }

    [Benchmark]
    public bool ArrayIntersectAnyNestedLoopAsArray()
    {
        return _arrayA.IntersectAny(_arrayB);
    }

    [Benchmark]
    public bool ArrayIntersectAnyWithHashSet()
    {
        var set = new HashSet<string>(_arrayA);

        foreach (var item in _arrayB)
        {
            if (set.Contains(item))
            {
                return true;
            }
        }

        return false;
    }

    [Benchmark]
    public bool ArrayIntersectAnyNestedLoopWithSpan()
    {
        Span<string> spanA = _arrayA;
        Span<string> spanB = _arrayB;

        for (var i = 0; i < spanA.Length; i++)
        {
            for (var j = 0; j < spanB.Length; j++)
            {
                if (spanA[i] == spanB[j])
                {
                    return true;
                }
            }
        }

        return false;
    }

    static string RandomStringCreate(Random random, int maxLength)
    {
        const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz-_@!#$%^&*()+{}[]";
        var len = random.Next(maxLength);
        return string.Create(len, random, (buff, str) =>
        {
            for (int i = 0; i < buff.Length; i++)
            {
                buff[i] = alphabet[random.Next(alphabet.Length)];
            }
        });
    }
}

#nullable enable
static class CollectionExtensions
{
    /// <summary>
    /// Returns the collection as an array.
    /// If the collection is already an array, it will be returned,
    /// else creates a new array by copying the contents of the collection, which is an O(n) operation.
    /// </summary>
    /// <param name="source">The collection to return as a list</param>
    /// <typeparam name="T">The type of element in the collection.</typeparam>
    /// <returns>Array populated from the source collection or null.</returns>
    public static T[]? AsArray<T>(this ICollection<T>? source)
    {
        if (source == null)
        {
            return null;
        }

        if (source is T[] sourceConvertedAsArray)
        {
            return sourceConvertedAsArray;
        }

        T[] returnArray = new T[source.Count];
        source.CopyTo(returnArray, 0);
        return returnArray;
    }

    /// <summary>
    /// Determines there is a common element present in the two collections passed in by doing a case insensitive check.
    /// This is a fast, less allocation alternative to calling "Any" on the result of "Intersect".
    /// Returns false, If any of the collections parameter passed in is null.
    /// </summary>
    /// <param name="first">First collection.</param>
    /// <param name="second">Second collection.</param>
    /// <returns>True if a common element is present, else False.</returns>
    public static bool IntersectAny(this ICollection<string>? first, ICollection<string>? second)
    {
        // Working with a for loop on an array is faster than working with
        // an Enumerator(foreach). So we will first convert the ICollection to an array.
        // If the parameters are already an array, this method allocates zero bytes.

        string[]? firstArray = first.AsArray();
        string[]? secondArray = second.AsArray();

        if (firstArray == null || secondArray == null)
        {
            return false;
        }

        for (var i = 0; i < firstArray.Length; i++)
        {
            for (var j = 0; j < secondArray.Length; j++)
            {
                if (firstArray[i].Equals(secondArray[j], StringComparison.Ordinal))
                {
                    return true;
                }
            }
        }

        return false;
    }
}
#nullable restore
