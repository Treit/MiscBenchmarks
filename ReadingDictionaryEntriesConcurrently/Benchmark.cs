namespace Test
{
    using BenchmarkDotNet.Attributes;
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class Benchmark
    {
        [Params(10, 1000, 100_000)]
        public int Count { get; set; }

        private Dictionary<int, string> _dict;
        private ConcurrentDictionary<int, string> _concurrentdict;
        private ReaderWriterLock _rwlock = new ReaderWriterLock();
        private ReaderWriterLockSlim _rwlockslim = new ReaderWriterLockSlim();
        private object _syncobj = new object();

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

        [Benchmark]
        public long ConcurrentReadsUsingReaderWriterLockSlim()
        {
            long total = 0;

            Parallel.For(0, Count, i =>
            {
                var str = KeyLookupUsingDictionaryReaderWriterLockSlim(i);
                Interlocked.Add(ref total, str.Length);
            });

            return total;
        }

        [Benchmark]
        public long ConcurrentReadsUsingLock()
        {
            long total = 0;

            Parallel.For(0, Count, i =>
            {
                var str = KeyLookupUsingLock(i);
                Interlocked.Add(ref total, str.Length);
            });

            return total;
        }

        [Benchmark]
        public long ConcurrentReadsUsingReaderWriterLock()
        {
            long total = 0;

            Parallel.For(0, Count, i =>
            {
                var str = KeyLookupUsingDictionaryReaderWriterLock(i);
                Interlocked.Add(ref total, str.Length);
            });

            return total;
        }

        [Benchmark]
        public long ConcurrentReadsUsingConcurrentDictionary()
        {
            long total = 0;

            Parallel.For(0, Count, i =>
            {
                var str = KeyLookupUsingConcurrentDictionary(i);
                Interlocked.Add(ref total, str.Length);
            });

            return total;
        }

        private string KeyLookupUsingDictionaryReaderWriterLockSlim(int key)
        {
                _rwlockslim.EnterReadLock();

                try
                {
                    return _dict[key];
                }
                finally
                {
                    _rwlockslim.ExitReadLock();
                }
        }

        private string KeyLookupUsingDictionaryReaderWriterLock(int key)
        {
            _rwlock.AcquireReaderLock(int.MaxValue);

            try
            {
                return _dict[key];
            }
            finally
            {
                _rwlock.ReleaseLock();
            }
        }

        private string KeyLookupUsingConcurrentDictionary(int key)
        {
            return _concurrentdict[key];
        }

        private string KeyLookupUsingLock(int key)
        {
            lock (_syncobj)
            {
                return _dict[key];
            }
        }
    }
}
