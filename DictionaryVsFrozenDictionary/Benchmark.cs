namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Linq;

[MemoryDiagnoser]
public class Benchmark
{
    [Params(1000)]
    public int Count { get; set; }

    private Dictionary<int, string> _dictionaryInt;
    private FrozenDictionary<int, string> _frozenDictionaryInt;
    private int _keyInt;

    private Dictionary<string, string> _dictionaryString;
    private FrozenDictionary<string, string> _frozenDictionaryString;
    private string _keyString;

    [GlobalSetup]
    public void GlobalSetup()
    {
        int len = Count;

        // Setup for integer keys
        _dictionaryInt = new Dictionary<int, string>(len);

        for (int i = 0; i < len; i++)
        {
            _dictionaryInt.Add(i, i.ToString());
        }

        _keyInt = _dictionaryInt.Keys.Skip(len / 2).Take(1).First();
        _frozenDictionaryInt = FrozenDictionary.ToFrozenDictionary(_dictionaryInt);

        // Setup for string keys
        _dictionaryString = new Dictionary<string, string>(len);

        for (int i = 0; i < len; i++)
        {
            _dictionaryString.Add(i.ToString(), i.ToString());
        }

        _keyString = _dictionaryString.Keys.Skip(len / 2).Take(1).First();
        _frozenDictionaryString = FrozenDictionary.ToFrozenDictionary(_dictionaryString);
    }

    [Benchmark(Baseline = true)]
    public string LookupUsingDictionaryInt()
    {
        return _dictionaryInt[_keyInt];
    }

    [Benchmark]
    public string LookupUsingFrozenDictionaryInt()
    {
        return _frozenDictionaryInt[_keyInt];
    }

    [Benchmark]
    public string LookupUsingDictionaryString()
    {
        return _dictionaryString[_keyString];
    }

    [Benchmark]
    public string LookupUsingFrozenDictionaryString()
    {
        return _frozenDictionaryString[_keyString];
    }
}
