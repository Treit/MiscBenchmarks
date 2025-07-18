using System.Text;

namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

[MemoryDiagnoser]
public class Benchmark
{
    private List<string> _strings;

    [Params(5, 100, 1_000_000)]
    public int Count { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        _strings = new List<string>(Count);

        var random = new Random(Count);

        for (int i = 0; i < Count; i++)
        {
            _strings.Add(RandomStringCreate(random, "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789", 100));
        }
    }

    [Benchmark]
    public string MoveUsingLinqOrderByRandomWithUnecessaryToList()
    {
        Random random = new Random(Count);
        var temp = _strings.OrderBy(a => random.Next()).ToList().First();
        _strings.Remove(temp);
        _strings.Insert(0, temp);
        return temp;
    }

    [Benchmark]
    public string MoveUsingRandomIndex()
    {
        var random = new Random(Count);
        var index = random.Next(_strings.Count);
        var temp = _strings[index];
        _strings.RemoveAt(index);
        _strings.Insert(0, temp);
        return temp;
    }

    [Benchmark]
    public string MoveUsingCollectionsMarshal()
    {
        var random = new Random(Count);
        var index = random.Next(_strings.Count);
        var span = CollectionsMarshal.AsSpan(_strings);
        var item = span[index];
        var length = span.Length - index - 1;
        span[..length].CopyTo(span[1..]);
        span[0] = item;
        return item;
    }

    [Benchmark(Baseline = true)]
    public string MoveUsingCollectionsMarshalAndSharedRandom()
    {
        var index = Random.Shared.Next(_strings.Count);
        var span = CollectionsMarshal.AsSpan(_strings);
        var item = span[index];
        var length = span.Length - index - 1;
        span[..length].CopyTo(span[1..]);
        span[0] = item;
        return item;
    }

    static string RandomStringCreate(Random random, string alphabet, int fixedLength)
    {
        var len = fixedLength;
        return string.Create(len, random, (buff, str) =>
        {
            for (int i = 0; i < buff.Length; i++)
            {
                buff[i] = alphabet[random.Next(alphabet.Length)];
            }
        });
    }
}
