namespace Test;
using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;

public class Benchmark
{
    [Params(100_000)]
    public int Count { get; set; }

    private Dictionary<int, string> _dict;
    private ReadOnlyDictionary<int, string> _readOnlyDict;
    private ConcurrentDictionary<int, string> _concurrentdict;
    private ReaderWriterLock _rwlock = new ReaderWriterLock();
    private ReaderWriterLockSlim _rwlockslim = new ReaderWriterLockSlim();
    private object _syncobj = new object();

    [GlobalSetup]
    public void GlobalSetup()
    {
        _dict = new Dictionary<int, string>(Count);
        _readOnlyDict = new ReadOnlyDictionary<int, string>(_dict);
        _concurrentdict = new ConcurrentDictionary<int, string>(8, Count);

        var r = new Random(Count);

        for (int i = 0; i < Count; i++)
        {
            var val = r.Next().ToString();
            _dict[i] = val;
            _concurrentdict[i] = val;
        }
    }

    [Benchmark(Baseline = true)]
    public string KeyLookupUsingDictionary()
    {
        return _dict[Count / 2];
    }

    [Benchmark]
    public string KeyLookupUsingReadOnlyDictionary()
    {
        return _readOnlyDict[Count / 2];
    }

    [Benchmark]
    public string KeyLookupUsingDictionaryReaderWriterLockSlim()
    {
            _rwlockslim.EnterReadLock();

            try
            {
                return _dict[Count / 2];
            }
            finally
            {
                _rwlockslim.ExitReadLock();
            }
    }

    [Benchmark]
    public string KeyLookupUsingDictionaryReaderWriterLock()
    {
        _rwlock.AcquireReaderLock(int.MaxValue);

        try
        {
            return _dict[Count / 2];
        }
        finally
        {
            _rwlock.ReleaseLock();
        }
    }

    [Benchmark]
    public string KeyLookupUsingConcurrentDictionary()
    {
        return _concurrentdict[Count / 2];
    }

    [Benchmark]
    public string KeyLookupUsingLock()
    {
        lock (_syncobj)
        {
            return _dict[Count / 2];
        }
    }
}
