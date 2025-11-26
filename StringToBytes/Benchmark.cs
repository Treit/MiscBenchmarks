using System.Text;

namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using BenchmarkDotNet.Jobs;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    private List<string> _strings;

    [Params(1000)]
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

    [Benchmark(Baseline = true)]
    public long StringToBytesUsingUnicodeEncoding()
    {
        var result = 0L;

        foreach (var str in _strings)
        {
            var bytes = Encoding.Unicode.GetBytes(str);
            result += bytes.Length;
        }

        return result;
    }

    [Benchmark]
    public long StringToBytesUsingHandRolledExtensionMethod()
    {
        var result = 0L;

        foreach (var str in _strings)
        {
            var bytes = str.GetBytes();
            result += bytes.Length;
        }

        return result;
    }

    [Benchmark]
    public long StringToBytesUsingMemoryMarshal()
    {
        var result = 0L;

        foreach (var str in _strings)
        {
            var bytes = StringToBytesMemoryMarshal(str);
            result += bytes.Length;
        }

        return result;
    }

    static byte[] StringToBytesMemoryMarshal(string str)
    {
        return MemoryMarshal.AsBytes(str.AsSpan()).ToArray();
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
