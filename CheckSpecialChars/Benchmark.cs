#pragma warning disable SYSLIB0013 // Type or member is obsolete
namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using System.Linq;
using System.Net;
using System;
using System.Collections.Generic;
using Microsoft.Diagnostics.Tracing.Parsers;
using System.Text;

[MemoryDiagnoser]
public class Benchmark
{
    private static HashSet<char> s_specialChars = new HashSet<char>(new char[] { '-', '_', '~', '!', '*', '\'', '(', ')', ';', '@', '&', '=', '+', '$', ',', '?', '#', '[', ']' });
    private static Dictionary<long, string> s_lookupTable;
    private static string[] charLookup = new string[128];
    private string[] _urls;

    [Params(10_000)]
    public long Count { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        _urls = new string[Count];

        for (long i = 0; i < Count; i++)
        {
            _urls[i] = $"https://something.example.com/{i}/a-b_c{{i}}/foo/[{i}]";
        }

        s_lookupTable = new();
        foreach (var c in s_specialChars)
        {
            var tmp = WebUtility.UrlEncode(c.ToString());
            s_lookupTable.Add((long)c, tmp);
        }

        for (long i = 0; i < charLookup.Length; i++)
        {
            var c = (char)i;
            if (c == '/' || c == ':')
            {
                charLookup[i] = c.ToString();
                continue;
            }

            charLookup[i] = WebUtility.UrlEncode(((char)i).ToString());
        }
    }

    [Benchmark]
    public long CheckUsingCharArrayVariable()
    {
        var result = 0;

        foreach (var url in _urls)
        {
            if (IsWellFormedSpecialCharacterUriString(url))
            {
                result++;
            }
        }

        return result;
    }

    [Benchmark(Baseline = true)]
    public long CheckUsingEscapeAndReplace()
    {
        var result = 0;

        foreach (var url in _urls)
        {
            if (IsWellFormedEscapingEntireStringThenReplace(url))
            {
                result++;
            }
        }

        return result;
    }

    [Benchmark]
    public long CheckUsingCharLookupTable()
    {
        var result = 0;

        foreach (var url in _urls)
        {
            if (IsWellFormedLookupTable(url))
            {
                result++;
            }
        }

        return result;
    }

    private static bool IsWellFormedEscapingEntireStringThenReplace(string uriString)
    {
        var resultUrl = New(uriString);
        return Uri.IsWellFormedUriString(resultUrl, UriKind.Absolute);
    }

    private static bool IsWellFormedSpecialCharacterUriString(string uriString)
    {
        var resultUrl = EscapeAndEncodeSpecialChars(uriString);
        return Uri.IsWellFormedUriString(resultUrl, UriKind.Absolute);
    }

    private static bool IsWellFormedLookupTable(string uriString)
    {
        var resultUrl = CharLookup(uriString);
        return Uri.IsWellFormedUriString(resultUrl, UriKind.Absolute);
    }

    internal static string EscapeAndEncodeSpecialChars(string uriString)
    {
        var specialChars = new char[] { '-', '_', '~', '!', '*', '\'', '(', ')', ';', '@', '&', '=', '+', '$', ',', '?', '#', '[', ']' };

        var resultUrl = Uri.EscapeUriString(uriString);

        foreach (var c in uriString.ToCharArray())
        {
            if (specialChars.Contains(c))
            {
                var specialChar = c.ToString();
                resultUrl = resultUrl.Replace(specialChar, WebUtility.UrlEncode(specialChar));
            }
        }

        return resultUrl;
    }

    internal static string New(string uriString)
    {
        var resultUrl = Uri.EscapeDataString(uriString);
        resultUrl = resultUrl.Replace("%2F", "/");
        resultUrl = resultUrl.Replace("%3A", ":");
        return resultUrl;
    }

    internal static string CharLookup(string uriString)
    {
        var sb = new StringBuilder(uriString.Length);
        foreach (var c in uriString)
        {
            sb.Append(charLookup[c]);
        }

        return sb.ToString();
    }
}
