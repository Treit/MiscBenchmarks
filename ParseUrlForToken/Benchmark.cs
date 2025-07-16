namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using System;
using System.Linq;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;
using System.Xml.Linq;

record TestRecord(string Name, Uri? Url);

[MemoryDiagnoser]
public class Benchmark
{
    private static TestRecord[]? _data;

    [Params(1000)]
    public int Count { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        _data = new TestRecord[Count];
        for (int i = 0; i < Count; i++)
        {
            var name = $"SomeRecord{i}";
            var uri = (i % 10) switch
            {
                0 => null,
                _ => new Uri($"https://SomeDomain.com/content/service/something/someapi/extractthis{i}-somesuffix")
            };

            _data[i] = new TestRecord(name, uri);
        }
    }

    [Benchmark]
    public int GetTokenFromUrlToStringSplitWithLinqAndUnnecessaryNullChecks()
    {
        var count = 0;

        for (var i = 0; i < Count; i++)
        {
            var item = _data![i];
            var needle = item.Url?.ToString()?.Split('/')?.Last()?.Split('-')?.First() ?? string.Empty;

            if (needle != string.Empty)
            {
                count++;
            }
        }

        return count;
    }

    [Benchmark]
    public int GetTokenFromUrlToStringSplitWithLinq()
    {
        var count = 0;

        for (var i = 0; i < Count; i++)
        {
            var item = _data![i];
            var needle = item.Url?.ToString().Split('/').Last().Split('-').First() ?? string.Empty;

            if (needle != string.Empty)
            {
                count++;
            }
        }

        return count;
    }

    [Benchmark(Baseline = true)]
    public int GetTokenFromUrlToStringWithIndexOfAndSubstring()
    {
        var count = 0;

        for (var i = 0; i < Count; i++)
        {
            var item = _data![i];

            if (item.Url is null)
            {
                continue;
            }

            var str = item.Url.ToString();
            var start = str.LastIndexOf('/');
            if (start == -1)
            {
                continue;
            }

            var loc = str.IndexOf('-', start + 1);

            if (loc == -1)
            {
                continue;
            }

            var needle = str.Substring(start + 1, loc - start - 1);

            if (needle != string.Empty)
            {
                count++;
            }
        }

        return count;
    }

    [Benchmark]
    public int GetTokenFromUrlAbsolutePathWithIndexOfAndSubstring()
    {
        var count = 0;

        for (var i = 0; i < Count; i++)
        {
            var item = _data![i];

            if (item.Url is null)
            {
                continue;
            }

            var str = item.Url.AbsolutePath;
            var start = str.LastIndexOf('/');
            if (start == -1)
            {
                continue;
            }

            var loc = str.IndexOf('-', start + 1);

            if (loc == -1)
            {
                continue;
            }

            var needle = str.Substring(start + 1, loc - start - 1);

            if (needle != string.Empty)
            {
                count++;
            }
        }

        return count;
    }
}
