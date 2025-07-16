namespace Test;
using BenchmarkDotNet.Attributes;
using System;
using System.Text;
using System.Text.RegularExpressions;

[MemoryDiagnoser]
public class Benchmark
{
    private string _stringToParse = "[on] [AdvancementsAddon] [player] advancement (award|get|complete)";
    private Regex _regex = new Regex(@"^\[(.+?)\].+\]\s(.+?)\s\(.+\|.+\|(.+)\)");
    private Regex _compregex = new Regex(@"^\[(.+?)\].+\]\s(.+?)\s\(.+\|.+\|(.+)\)", RegexOptions.Compiled);
    private char[] _chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

    [GlobalSetup]
    public void GlobalSetup()
    {
    }

    [Benchmark(Baseline = true)]
    public string ParseUsingRegex()
    {
        var m = _regex.Match(_stringToParse);

        if (!m.Success)
        {
            throw new InvalidOperationException("Regex unexpectedly did not match.");
        }

        return m.Result("$1 $2 $3");
    }

    [Benchmark]
    public string ParseUsingCompiledRegex()
    {
        var m = _compregex.Match(_stringToParse);

        if (!m.Success)
        {
            throw new InvalidOperationException("Regex unexpectedly did not match.");
        }

        return m.Result("$1 $2 $3");
    }

    [Benchmark]
    public string ParseUsingTokensViaSplit()
    {
        var tokens = _stringToParse.Split(' ');

        var a = tokens[0].Replace("[", "").Replace("]", "");
        var b = tokens[3];
        var tmp = tokens[4];
        int loc = tmp.LastIndexOf("|");
        var c = tmp.Substring(loc + 1).Replace(")", "");

        return $"{a} {b} {c}";
    }

    [Benchmark]
    public string ParseUsingStateMachine()
    {
        var sb = new StringBuilder(_stringToParse.Length);
        var s = _stringToParse;

        bool needFirst = true;
        bool bracket = false;
        bool paren = false;
        int pipes = 0;

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == ' ')
            {
                continue;
            }

            if (s[i] == '[')
            {
                bracket = true;
                continue;
            }

            if (s[i] == ']')
            {
                bracket = false;

                if (needFirst)
                {
                    sb.Append(' ');
                    needFirst = false;
                }

                continue;
            }

            if (s[i] == '(')
            {
                sb.Append(' ');
                paren = true;
                continue;
            }

            if (s[i] == ')')
            {
                paren = false;
                continue;
            }

            if (bracket && needFirst)
            {
                sb.Append(s[i]);
                continue;
            }

            if (paren)
            {
                if (s[i] == '|')
                {
                    pipes++;
                    continue;
                }

                if (pipes != 2)
                {
                    continue;
                }

                sb.Append(s[i]);
            }

            if (!bracket && !paren)
            {
                sb.Append(s[i]);
            }
        }

        return sb.ToString();
    }

    [Benchmark]
    public string ParseUsingSpan()
    {
        ReadOnlySpan<char> inputSpan = _stringToParse;
        int posEndOfFirst = _stringToParse.IndexOfAny(_chars, inputSpan.LastIndexOf(']'));
        int posEndOfLast = inputSpan.LastIndexOf('|') + 1;
        var a = inputSpan.Slice(inputSpan.IndexOf('[') + 1, inputSpan.IndexOf(']') - 1).ToString();
        var b = inputSpan.Slice(posEndOfFirst, inputSpan.IndexOf('(') - posEndOfFirst - 1).ToString();
        var c = inputSpan.Slice(posEndOfLast, inputSpan.LastIndexOf(')') - posEndOfLast);
        return $"{a} {b} {c}";
    }
}
