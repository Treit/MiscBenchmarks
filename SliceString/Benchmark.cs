namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Jobs;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    static readonly List<string> s_RandomStrings = [];

    [Params(10, 1000)]
    public int Count { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        Random r = new Random(Count);

        for (int i = 0; i < Count; i++)
        {
            s_RandomStrings.Add(GetRandomString(r, 100));
        }
    }

    [Benchmark(Baseline = true)]
    public List<string> SliceWithSpan()
    {
        var resultList = new List<string>(Count);
        foreach (var value in s_RandomStrings)
        {
            resultList.AddRange(SliceToMultiple(value, 10));
        }

        return resultList;
    }

    [Benchmark]
    public List<string> SliceWithEnumerable()
    {
        var resultList = new List<string>(Count);
        foreach (var value in s_RandomStrings)
        {
            resultList.AddRange(SliceUsingYield(value, 10));
        }

        return resultList;
    }

    static string GetRandomString(Random r, int maxLength)
    {
        var alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz-_@!#$%^&*()+{}[]";
        var len = r.Next(maxLength);
        var sb = new StringBuilder(len);

        for (int i = 0; i < len; i++)
        {
            sb.Append(alphabet[r.Next(alphabet.Length)]);
        }

        return sb.ToString();
    }

    public static List<string> SliceToMultiple(string value, int sliceLength)
    {
        var resultList = new List<string>(value.Length / sliceLength);
        var startIndexToSliceFrom = 0;
        var totalLengthSliced = 0;
        var valueSpan = value.AsSpan();

        while (totalLengthSliced < value.Length)
        {
            var lengthToSlice = Math.Min(sliceLength, value.Length - totalLengthSliced);

            resultList.Add(valueSpan.Slice(startIndexToSliceFrom, lengthToSlice).ToString());

            totalLengthSliced = totalLengthSliced + lengthToSlice;
            startIndexToSliceFrom = totalLengthSliced;
        }

        return resultList;
    }

    public static IEnumerable<string> SliceUsingYield(string value, int sliceLength)
    {
        int start = 0;
        int end = sliceLength;
        while (true)
        {
            yield return value.Substring(start, Math.Min(end, value.Length - start));
            start += sliceLength;
            end += sliceLength;

            if (start >= value.Length)
            {
                break;
            }
        }
    }
}
