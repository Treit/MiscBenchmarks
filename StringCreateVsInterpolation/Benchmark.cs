using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;

namespace Test;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    private readonly string _apiVersion = "7.1-preview.1";
    private readonly string _selector = "_apis/wit/workitems?ids=1,2,3";

    [Params(25, 1_000)]
    public int PageSize { get; set; }

    [Benchmark(Baseline = true)]
    public string PlainInterpolation()
    {
        return $"{_selector}&top={Math.Min(PageSize, 100)}&api-version={Uri.EscapeDataString(_apiVersion)}";
    }

    [Benchmark]
    public string StringCreateInvariantCulture()
    {
        return string.Create(
            CultureInfo.InvariantCulture,
            $"{_selector}&top={Math.Min(PageSize, 100)}&api-version={Uri.EscapeDataString(_apiVersion)}");
    }

    [Benchmark]
    public async Task<string> FormUrlEncodedContentDictionary()
    {
        var parameters = new Dictionary<string, string>
        {
            ["top"] = Math.Min(PageSize, 100).ToString(CultureInfo.InvariantCulture),
            ["api-version"] = _apiVersion
        };

        using var content = new FormUrlEncodedContent(parameters);
        return $"{_selector}&{await content.ReadAsStringAsync()}";
    }
}
