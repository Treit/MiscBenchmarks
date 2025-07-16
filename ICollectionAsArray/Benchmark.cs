namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using System;
using System.Collections.Generic;
using System.Linq;

[MemoryDiagnoser]
public class Benchmark
{
    [Params(10, 100_000)]
    public int Count { get; set; }

    private List<string> _collection;

    [GlobalSetup]
    public void GlobalSetup()
    {
        Random r = new Random();

        _collection = new List<string>();

        for (int i = 0; i < Count; i++)
        {
            _collection.Add(RandomStringCreate(r, 50));
        }
    }

    [Benchmark(Baseline = true)]
    public long IterateUsingNormalForEachLoop()
    {
        var result = 0L;
        var items = _collection;

        foreach (var str in items)
        {
            result += str.Length;
        }

        return result;
    }

    [Benchmark]
    public long IterateUsingNormalForLoop()
    {
        var result = 0L;
        var items = _collection;

        for (int i = 0; i < items.Count; i++)
        {
            result += items[i].Length;
        }

        return result;
    }

    [Benchmark]
    public long IterateUsingAsArrayForLoop()
    {
        var result = 0L;
        var items = _collection.AsArray();

        for (int i = 0; i < items.Length; i++)
        {
            result += items[i].Length;
        }

        return result;
    }

    [Benchmark]
    public long IterateUsingAsArrayForEachLoop()
    {
        var result = 0L;
        var items = _collection.AsArray();

        foreach (var str in items)
        {
            result += str.Length;
        }

        return result;
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
}
#nullable restore
