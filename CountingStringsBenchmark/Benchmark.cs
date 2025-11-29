namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Jobs;

[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]

public class Benchmark
{
    [Params(10, 100, 1000, 100_000, 1_000_000)]
    public int Count { get; set; }

    public List<string> strings;

    [GlobalSetup]
    public void GlobalSetup()
    {
        this.strings = new List<string>(Count);
        for (int i = 0; i < this.Count; i++)
        {
            if (i % 10 == 0)
            {
                strings.Add("");
            }
            else
            {
                strings.Add(i.ToString());
            }
        }
    }

    [Benchmark]
    public int ForLoopCountUsingLengthEqualsZero()
    {
        int count = 0;
        for (int i = 0; i < strings.Count; i++)
        {
            if (strings[i].Length == 0)
            {
                count++;
            }
        }
        return count;
    }

    [Benchmark]
    public int ForLoopCountUsingLengthEqualsZeroWithNullCheck()
    {
        int count = 0;
        for (int i = 0; i < strings.Count; i++)
        {
            if (strings[i]?.Length == 0)
            {
                count++;
            }
        }
        return count;
    }

    [Benchmark]
    public int ForLoopCountUsingLengthEqualsZeroWithTryCatch()
    {
        int count = 0;
        for (int i = 0; i < strings.Count; i++)
        {
            try
            {
                if (strings[i].Length == 0)
                {
                    count++;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        return count;
    }

    [Benchmark(Baseline = true)]
    public int ForLoopCountUsingEmptyStringLiteral()
    {
        int count = 0;
        for (int i = 0; i < strings.Count; i++)
        {
            if (strings[i] == "")
            {
                count++;
            }
        }

        return count;
    }

    [Benchmark]
    public int ForLoopCountUsingStringDotEmpty()
    {
        int count = 0;
        for (int i = 0; i < strings.Count; i++)
        {
            if (strings[i] == string.Empty)
            {
                count++;
            }
        }

        return count;
    }

    [Benchmark]
    public int ForEachLoopCountUsingLengthEqualsZero()
    {
        int count = 0;
        foreach (string s in strings)
        {
            if (s.Length == 0)
            {
                count++;
            }
        }
        return count;
    }

    [Benchmark]
    public int ForEachLoopCountUsingEmptyStringLiteral()
    {
        int count = 0;
        foreach (string s in strings)
        {
            if (s == "")
            {
                count++;
            }
        }

        return count;
    }

    [Benchmark]
    public int ForEachLoopCountUsingStringDotEmpty()
    {
        int count = 0;
        foreach (string s in strings)
        {
            if (s == string.Empty)
            {
                count++;
            }
        }

        return count;
    }

    [Benchmark]
    public int ForLoopCountUsingIsNullOrEmpty()
    {
        int count = 0;
        for (int i = 0; i < strings.Count; i++)
        {
            if (string.IsNullOrEmpty(strings[i]))
            {
                count++;
            }
        }
        return count;
    }

    [Benchmark]
    public int CountUsingLinqWhereEmptyStringLiteral()
    {
        int count = 0;
        count = strings.Where(x => x == "").Count();

        return count;
    }

    [Benchmark]
    public int CountUsingLinqWhereLengthEqualsZero()
    {
        int count = 0;
        count = strings.Where(x => x.Length == 0).Count();

        return count;
    }
}
