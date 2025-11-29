using System.Text;

namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using System;
using System.Linq;
using BenchmarkDotNet.Jobs;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    [Params(3, 50, 100)]
    public int Count { get; set; }

    private string seedString = "abc";

    [GlobalSetup]
    public void GlobalSetup()
    {
    }

    [Benchmark(Baseline = true)]
    public string DupeUsingStringBuilderLoop()
    {
        StringBuilder sb = new StringBuilder(seedString.Length * Count);

        for (int i = 0; i < Count; i++)
        {
            sb.Append(seedString);
        }

        return sb.ToString();
    }

    [Benchmark]
    public string DupeUsingStringCreate()
    {
        return string.Create(seedString.Length * Count, (seedString, Count), (data, buffer) =>
        {
            for (int i = 0; i < Count; i++)
            {
                var window = data.Slice(i * seedString.Length);
                seedString.CopyTo(window);
            }
        });
    }

    [Benchmark]
    public string DupeUsingStackOverflowAnswer()
    {
        string result = seedString.Repeat(Count);
        return result;
    }

    [Benchmark]
    public string DupeUsingEnumerableRepeat()
    {
        string result = string.Concat(Enumerable.Repeat<string>(seedString, Count));
        return result;
    }
}

public static class RepeatExtensions
{
    public static string Repeat(this string str, int times)
    {
        var a = new StringBuilder();

        // Append is faster than Insert
        Action action = () => { a.AppendLine(str); };
        action.RepeatAction(times);

        return a.ToString();
    }

    public static void RepeatAction(this Action action, int count)
    {
        for (int i = 0; i < count; i++)
        {
            action();
        }
    }
}
