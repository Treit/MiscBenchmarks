namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using System.Collections.Concurrent;

[MemoryDiagnoser]
public class Benchmark
{
    [Params(10, 100, 10000)]
    public int Count { get; set; }

    ConcurrentDictionary<string, string> dict = new();
    ConcurrentDictionary<string, string> dictMixed = new();

    [GlobalSetup]
    public void GlobalSetup()
    {
        for (int i = 0; i < Count; i++)
        {
            dict.TryAdd(i.ToString(), i.ToString());
            if (i % 2 == 0)
            {
                dictMixed.TryAdd(i.ToString(), i.ToString());
            }
            else
            {
                dictMixed.TryAdd((i * -1).ToString(), (i * -1).ToString());
            }
        }
    }

    [Benchmark(Baseline = true)]
    public int FindMatchesUsingGetOrAddCacheHit()
    {
        var result = 0;

        for (int i = 0; i < Count; i++)
        {
            var key = i.ToString();
            var item = dict.GetOrAdd(key, key);
            result += item.Length;
        }

        return result;
    }

    [Benchmark]
    public int FindMatchesUsingGetOrAddCacheMiss()
    {
        var result = 0;

        for (int i = 0; i < Count; i++)
        {
            var key = (i * -1).ToString();

            var item = dict.GetOrAdd(key, key);
            result += item.Length;
        }

        return result;
    }

    [Benchmark]
    public int FindMatchesUsingGetOrAddCacheMixOfHitsAndMisses()
    {
        var result = 0;

        for (int i = 0; i < Count; i++)
        {
            var key = i.ToString();

            var item = dictMixed.GetOrAdd(key, key);
            result += item.Length;
        }

        return result;
    }

    [Benchmark]
    public int FindMatchesUsingTryGetValueThenGetOrAddCacheHit()
    {
        var result = 0;

        for (int i = 0; i < Count; i++)
        {
            var key = i.ToString();

            if (dict.TryGetValue(key, out var item))
            {
                result += item.Length;
            }
            else
            {
                item = dict.GetOrAdd(key, key);
                result += item.Length;
            }
        }

        return result;
    }

    [Benchmark]
    public int FindMatchesUsingTryGetValueThenGetOrAddCacheMiss()
    {
        var result = 0;

        for (int i = 0; i < Count; i++)
        {
            var key = (i * -1).ToString();

            if (dict.TryGetValue(key, out var item))
            {
                result += item.Length;
            }
            else
            {
                item = dict.GetOrAdd(key, key);
                result += item.Length;
            }
        }

        return result;
    }

    [Benchmark]
    public int FindMatchesUsingTryGetValueThenGetOrAddMixOfHitsAndMisses()
    {
        var result = 0;

        for (int i = 0; i < Count; i++)
        {
            var key = i.ToString();

            if (dictMixed.TryGetValue(key, out var item))
            {
                result += item.Length;
            }
            else
            {
                item = dictMixed.GetOrAdd(key, key);
                result += item.Length;
            }
        }

        return result;
    }

    [Benchmark]
    public int FindMatchesUsingTryGetValueThenTryAddCacheHit()
    {
        var result = 0;

        for (int i = 0; i < Count; i++)
        {
            var key = i.ToString();

            if (dict.TryGetValue(key, out var item))
            {
                result += item.Length;
            }
            else
            {
                item = key;
                dict.TryAdd(key, item);

                result += item.Length;
            }
        }

        return result;
    }

    [Benchmark]
    public int FindMatchesUsingTryGetValueThenTryAddCacheMiss()
    {
        var result = 0;

        for (int i = 0; i < Count; i++)
        {
            var key = (i * -1).ToString();

            if (dict.TryGetValue(key, out var item))
            {
                result += item.Length;
            }
            else
            {
                item = key;
                dict.TryAdd(key, item);
                result += item.Length;
            }
        }

        return result;
    }

    [Benchmark]
    public int FindMatchesUsingTryGetValueThenTryAddMixOfHitsAndMisses()
    {
        var result = 0;

        for (int i = 0; i < Count; i++)
        {
            var key = i.ToString();

            if (dictMixed.TryGetValue(key, out var item))
            {
                result += item.Length;
            }
            else
            {
                item = key;
                dictMixed.TryAdd(key, item);
                result += item.Length;
            }
        }

        return result;
    }
}
