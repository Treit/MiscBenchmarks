namespace Test
{
    using BenchmarkDotNet.Attributes;
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Threading;

    public class Benchmark
    {
        [Params(100_000)]
        public int Count { get; set; }

        private Dictionary<int, string> _dict;
        private ConcurrentDictionary<int, string> _concurrentdict;
        private ReaderWriterLockSlim _rwlock = new ReaderWriterLockSlim();

        [GlobalSetup]
        public void GlobalSetup()
        {
            _dict = new Dictionary<int, string>(Count);
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
        public string KeyLookupUsingDictionaryReaderWriterLockSlim()
        {
                _rwlock.EnterReadLock();

                try
                {
                    return _dict[Count / 2];
                }
                finally
                {
                    _rwlock.ExitReadLock();
                }
        }

        [Benchmark]
        public string KeyLookupUsingConcurrentDictionary()
        {
            return _concurrentdict[Count / 2];
        }
    }
}
