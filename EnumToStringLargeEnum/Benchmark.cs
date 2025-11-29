namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using System;
using System.Net;
using BenchmarkDotNet.Jobs;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    private HttpStatusCode[] _httpStatusCodes;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _httpStatusCodes = (HttpStatusCode[])Enum.GetValues(
            typeof(HttpStatusCode));
    }

    [Benchmark]
    public string HttpStatusCodeToStringRegularToString()
    {
        string result = string.Empty;

        for (int j = 0; j < _httpStatusCodes.Length; j++)
        {
            result = _httpStatusCodes[j].ToString();
        }

        return result;
    }

    [Benchmark]
    public string HttpStatusCodeToStringSwitchExpression()
    {
        string result = string.Empty;

        for (int j = 0; j < _httpStatusCodes.Length; j++)
        {
            result = _httpStatusCodes[j].ToFastString();
        }

        return result;
    }

    [Benchmark]
    public string HttpStatusCodeToStringFrozenDictionaryLookup()
    {
        string result = string.Empty;

        for (int j = 0; j < _httpStatusCodes.Length; j++)
        {
            result = _httpStatusCodes[j].ToStringCached();
        }

        return result;
    }

    [Benchmark(Baseline = true)]
    public string HttpStatusCodeToStringSparseArrayLookup()
    {
        string result = string.Empty;

        for (int j = 0; j < _httpStatusCodes.Length; j++)
        {
            result = _httpStatusCodes[j].ToArrayString();
        }

        return result;
    }

    [Benchmark]
    public string HttpStatusCodeToStringSparseArrayDoubleLookup()
    {
        string result = string.Empty;

        for (int j = 0; j < _httpStatusCodes.Length; j++)
        {
            result = _httpStatusCodes[j].ToArrayStringDominic();
        }

        return result;
    }

    [Benchmark]
    public string HttpStatusCodeToStringSparseArraySingleLookup()
    {
        string result = string.Empty;

        for (int j = 0; j < _httpStatusCodes.Length; j++)
        {
            result = _httpStatusCodes[j].ToArrayStringDominic();
        }

        return result;
    }
}
