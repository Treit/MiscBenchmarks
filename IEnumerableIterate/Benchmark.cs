namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

[MemoryDiagnoser]
[MemoryRandomization]
public class Benchmark
{
    private string[] _stringArray;
    private List<string> _stringList;
    private HashSet<string> _stringSet;
    private Dictionary<string, uint> _dict;

    [Params(10, 5000)]
    public int Count { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        _stringArray = new string[Count];
        _stringList = new List<string>(Count);
        _stringSet = new HashSet<string>(Count);
        _dict = new Dictionary<string, uint>(Count);

        for (int i = 0; i < Count; i++)
        {
            var str = i.ToString();
            _stringArray[i] = str;
            _stringList.Add(str);
            _stringSet.Add(str);
            _dict.Add(str, (uint)i);
        }
    }

    [Benchmark(Baseline = true)]
    public long IEnumerableForLoopWithCastToArray()
    {
        return DoLoopOnIEnumerable(_stringArray, true);
    }

    [Benchmark]
    public long IEnumerableForEachLoopWithArrayAsIEnumerable()
    {
        return DoLoopOnIEnumerable(_stringArray, false);
    }

    [Benchmark]
    public long IEnumerableForEachLoopWithListAsIEnumerable()
    {
        return DoLoopOnIEnumerable(_stringList, false);
    }

    [Benchmark]
    public long IEnumerableForEachLoopWithCastToArray()
    {
        return DoForEachLoopOnIEnumerable(_stringArray, false);
    }

    [Benchmark]
    public long IEnumerableForEachLoopWithCastToList()
    {
        return DoForEachLoopOnIEnumerable(_stringList, false);
    }

    [Benchmark]
    public long IEnumerableForEachLoopWithCastToListAndSpan()
    {
        return DoForEachLoopOnIEnumerable(_stringList, true);
    }

    [Benchmark]
    public long IEnumerableForEachLoopWithCastToArrayAndSpan()
    {
        return DoForEachLoopOnIEnumerable(_stringArray, true);
    }

    [Benchmark]
    public long IEnumerableForEachLoopNoCastUnderlyingCollectionIsHashSet()
    {
        return DoForEachLoopOnIEnumerable(_stringSet, false);
    }

    [Benchmark]
    public long IEnumerableForEachLoopDictionaryKeys()
    {
        return DoForEachLoopOnIEnumerable(_dict.Keys, false);
    }

    [Benchmark]
    public long IEnumerableForEachLoopDictionaryKeyValuePairs()
    {
        var result = 0L;

        foreach (var str in _dict)
        {
            result += str.Key.Length;
        }

        return result;
    }

    private long DoLoopOnIEnumerable(IEnumerable<string> items, bool castToArray)
    {
        var result = 0L;

        if (castToArray && items is string[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                result += arr[i].Length;
            }
        }
        else
        {
            foreach (var item in items)
            {
                result += item.Length;
            }
        }

        return result;
    }

    private long DoForEachLoopOnIEnumerable(IEnumerable<string> items, bool span)
    {
        if (items is string[] arr)
        {
            if (span)
            {
                return CalcSpan(arr);
            }
            else
            {
                return CalcArray(arr);
            }
        }

        if (items is List<string> list)
        {
            if (span)
            {
                return CalcSpan(CollectionsMarshal.AsSpan(list));
            }
            else
            {
                return CalcList(list);
            }
        }

        return CalcNormal(items);

        static long CalcSpan(Span<string> items)
        {
            var result = 0L;

            foreach (var str in items)
            {
                result += str.Length;
            }

            return result;
        }

        static long CalcArray(string[] items)
        {
            var result = 0L;

            foreach (var str in items)
            {
                result += str.Length;
            }

            return result;
        }

        static long CalcList(List<string> items)
        {
            var result = 0L;

            foreach (var str in items)
            {
                result += str.Length;
            }

            return result;
        }

        static long CalcNormal(IEnumerable<string> items)
        {
            var result = 0L;

            foreach (var str in items)
            {
                result += str.Length;
            }

            return result;
        }
    }
}
