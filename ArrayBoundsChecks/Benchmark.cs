namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;

[DisassemblyDiagnoser(exportDiff: true, exportHtml: true)]
public class Benchmark
{
    private string[] _strings;

    [Params(10_000)]
    public int Count { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        _strings = new string[Count];

        for (int i = 0; i < Count; i++)
        {
            if (i % 10 == 0)
            {
                _strings[i] = ("");
            }
            else
            {
                _strings[i] = i.ToString();
            }
        }
    }

    [Benchmark]
    public int ForLoopCountField()
    {
        var count = 0;

        for (int i = 0; i < _strings.Length; i++)
        {
            if (_strings[i].Length == 0)
            {
                count++;
            }
        }

        return count;
    }

    [Benchmark]
    public int ForLoopCountLocalVariable()
    {
        var count = 0;
        var strings = _strings;

        for (int i = 0; i < strings.Length; i++)
        {
            if (strings[i].Length == 0)
            {
                count++;
            }
        }

        return count;
    }

    [Benchmark]
    public int ForEachLoopCountField()
    {
        var count = 0;
        foreach (string s in _strings)
        {
            if (s.Length == 0)
            {
                count++;
            }
        }

        return count;
    }

    [Benchmark]
    public int ForEachLoopCountLocalVariable()
    {
        var count = 0;
        var strings = _strings;

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
    public int Lulz1()
    {
        var count = _strings.Length;
        foreach (string s in _strings)
        {
            count += (-s.Length) >> 31;
        }
        return count;
    }

    [Benchmark]
    public int Lulz2()
    {
        ulong count = (uint)_strings.Length; count <<= 31;
        foreach (string s in _strings)
        {
            count -= (ulong)((uint)(-s.Length) & 0x80000000u);
        }
        return (int)(count >> 31);
    }

    [Benchmark]
    public int Lulz3()
    {
        var count = 0;
        foreach (string s in _strings)
        {
            count += (s.Length - 1) >>> 31;
        }
        return count;
    }
}
