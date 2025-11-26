namespace Test;
using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using BenchmarkDotNet.Jobs;

[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]

public class Benchmark
{
    object _lock = new();
    string _targetStr = "";
    string _stringToWrite = "";

    [GlobalSetup]
    public void GlobalSetup()
    {
        _stringToWrite = DateTime.Now.ToString();
        _targetStr = DateTime.Now.ToString();
    }

    [Benchmark]
    public char ReadWithLock()
    {
        lock ( _lock )
        {
            return _targetStr[0];
        }
    }

    [Benchmark]
    public char Read()
    {
        return _targetStr[0];
    }

    [Benchmark]
    public void WriteWithLock()
    {
        lock (_lock)
        {
            _targetStr = _stringToWrite;
        }
    }

    [Benchmark]
    public void Write()
    {
        _targetStr = _stringToWrite;
    }
}
