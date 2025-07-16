namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

[MemoryDiagnoser]
public class Benchmark
{
    // The first character is a sentinel character, we need to decode everything AFTER the first character.
    private static readonly string _encoded = "?eyI1OSI6MS4wLCI3MCI6NS4wLCI3MSI6NS4wLCI3MiI6NC4wLCI3MyI6MS4wLCI3NCI6MS4wLCI4MiI6Mi4wLCI4NSI6MS4wLCIxMDciOjEuMCwiMTE4Ijo0OS4wLCIxMTkiOjQ5LjAsIjEyMCI6NDAuMCwiMTIxIjoxLjAsIjEyMiI6MS4wLCIxMzAiOjMuMCwiMTMzIjo5LjAsIjEzNyI6MS4wLCIxNDMiOjIuMCwiMTQ5IjoxLjAsIjE1MiI6MS4wLCIxNzQiOjMuMCwiNTkyIjoxLjAsIjU5MyI6MS4wLCI1OTQiOjUuMCwiNTk1IjoxLjAsIjk5OTk5OTkiOjI0MDMzMS4wfQ==";
    private List<string> _encodedJsonDocuments;
    private ArrayPool<byte> _arrayPool;

    [Params(100, 10_000)]
    public int Count;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _encodedJsonDocuments = new List<string>(Count);
        _arrayPool = ArrayPool<byte>.Create(1024 * 1024, 100);

        for (int i = 0; i < Count; i++)
        {
            _encodedJsonDocuments.Add(_encoded);
        }
    }

    [Benchmark]
    public List<Dictionary<string, float>> ConvertFromBase64WtihSubstring()
    {
        var results = new List<Dictionary<string, float>>();

        foreach (var doc in _encodedJsonDocuments)
        {
            var binaryData = Convert.FromBase64String(_encoded.Substring(1));
            var json = Encoding.Default.GetString(binaryData);
            var dict = JsonSerializer.Deserialize<Dictionary<string, float>>(json);
            results.Add(dict);
        }

        return results;
    }

    [Benchmark(Baseline = true)]
    public List<Dictionary<string, float>> ConvertTryFromBase64Chars()
    {
        var results = new List<Dictionary<string, float>>();
        Span<byte> buffer = stackalloc byte[_encoded.Length];

        foreach (var doc in _encodedJsonDocuments)
        {
            Convert.TryFromBase64Chars(doc.AsSpan(1), buffer, out var bytesWritten);
            var slice = buffer[..bytesWritten];
            var dict = JsonSerializer.Deserialize<Dictionary<string, float>>(slice);
            results.Add(dict);
        }

        return results;
    }

    [Benchmark]
    public List<Dictionary<string, float>> ConvertTryFromBase64CharsWithArrayPool()
    {
        var results = new List<Dictionary<string, float>>();
        var buffer = _arrayPool.Rent(_encoded.Length);

        try
        {
            foreach (var doc in _encodedJsonDocuments)
            {
                Convert.TryFromBase64Chars(doc.AsSpan(1), buffer, out var bytesWritten);
                var slice = buffer.AsSpan()[..bytesWritten];
                var dict = JsonSerializer.Deserialize<Dictionary<string, float>>(slice);
                results.Add(dict);
            }

            return results;
        }
        finally
        {
            _arrayPool.Return(buffer);
        }
    }
}
