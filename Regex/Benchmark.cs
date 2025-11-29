namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Jobs;

[MemoryDiagnoser]
public partial class Benchmark
{
    [Params(10, 100_000)]
    public int Count { get; set; }

    private List<string> _values;

    private static Regex s_re;
    private static Regex s_rec;

    [GeneratedRegex("^.+,.+,.+,.+,.+,(.+?),", RegexOptions.None)]
    private static partial Regex s_resg();

    [GlobalSetup]
    public void GlobalSetup()
    {
        _values = new List<string>(Count);
        s_re = new Regex("^.+,.+,.+,.+,.+,(.+?),");
        s_rec = new Regex("^.+,.+,.+,.+,.+,(.+?),", RegexOptions.Compiled);

        for (int i = 0; i < this.Count; i++)
        {
            _values.Add($"{i},{i + 1},{i + 2},{i + 3},{i + 4},{i + 5},{i + 6},{i + 7},{i + 8},{i + 9},{i + 10}");
        }
    }

    [Benchmark]
    public int FindTokenUsingRegex()
    {
        string needle = "104";
        int result = -1;

        for (int i = 0; i < _values.Count; i++)
        {
            Match m = s_re.Match(_values[i]);
            if (m.Success && m.Result("$1") == needle)
            {
                result = i;
            }
        }

        return result;
    }

    [Benchmark]
    public int FindTokenUsingCompiledRegex()
    {
        string needle = "104";
        int result = -1;

        for (int i = 0; i < _values.Count; i++)
        {
            Match m = s_rec.Match(_values[i]);
            if (m.Success && m.Result("$1") == needle)
            {
                result = i;
            }
        }

        return result;
    }

    [Benchmark]
    public int FindTokenUsingSourceGenRegex()
    {
        string needle = "104";
        int result = -1;

        for (int i = 0; i < _values.Count; i++)
        {
            Match m = s_resg().Match(_values[i]);
            if (m.Success && m.Result("$1") == needle)
            {
                result = i;
            }
        }

        return result;
    }
}
