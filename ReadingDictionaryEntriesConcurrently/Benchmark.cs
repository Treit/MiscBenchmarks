namespace Test
{
    using BenchmarkDotNet.Attributes;
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Frozen;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class Benchmark
    {
        [Params(10, 1000, 100_000)]
        public int Count { get; set; }

        private Dictionary<int, string> _dict;
        private ConcurrentDictionary<int, string> _concurrentdict;
        private FrozenDictionary<int, string> _frozendict;
        private ReaderWriterLock _rwlock = new ReaderWriterLock();
        private ReaderWriterLockSlim _rwlockslim = new ReaderWriterLockSlim();
        private int _mdop = Environment.ProcessorCount * 2;
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

            _frozendict = _dict.ToFrozenDictionary();
        }

        [Benchmark]
        public async Task<long> ConcurrentReadsUsingReaderWriterLockSlim()
        {
            long total = 0;

            var tasks = new List<Task>(_mdop);
            var mre = new ManualResetEvent(false);

            for (int i = 0; i < _mdop; i++)
            {
                var task = Task.Run(() =>
                {
                    mre.WaitOne();

                    for (int j = 0; j < Count; j++)
                    {
                        var str = KeyLookupUsingDictionaryReaderWriterLockSlim(j);
                        Interlocked.Add(ref total, str.Length);
                    }
                });

                tasks.Add(task);
            }

            mre.Set();
            await Task.WhenAll(tasks);

            return total;
        }

        [Benchmark]
        public async Task<long> ConcurrentReadsUsingLock()
        {
            long total = 0;

            var tasks = new List<Task>(_mdop);
            var mre = new ManualResetEvent(false);

            for (int i = 0; i < _mdop; i++)
            {
                var task = Task.Run(() =>
                {
                    mre.WaitOne();

                    for (int j = 0; j < Count; j++)
                    {
                        var str = KeyLookupUsingLock(j);
                        Interlocked.Add(ref total, str.Length);
                    }
                });

                tasks.Add(task);
            }

            mre.Set();
            await Task.WhenAll(tasks);

            return total;
        }

        [Benchmark]
        public async Task<long> ConcurrentReadsUsingReaderWriterLock()
        {
            long total = 0;

            var tasks = new List<Task>(_mdop);
            var mre = new ManualResetEvent(false);

            for (int i = 0; i < _mdop; i++)
            {
                var task = Task.Run(() =>
                {
                    mre.WaitOne();

                    for (int j = 0; j < Count; j++)
                    {
                        var str = KeyLookupUsingDictionaryReaderWriterLock(j);
                        Interlocked.Add(ref total, str.Length);
                    }
                });

                tasks.Add(task);
            }

            mre.Set();
            await Task.WhenAll(tasks);

            return total;
        }

        [Benchmark]
        public async Task<long> ConcurrentReadsUsingConcurrentDictionary()
        {
            long total = 0;

            var tasks = new List<Task>(_mdop);
            var mre = new ManualResetEvent(false);

            for (int i = 0; i < _mdop; i++)
            {
                var task = Task.Run(() =>
                {
                    mre.WaitOne();

                    for (int j = 0; j < Count; j++)
                    {
                        var str = KeyLookupUsingConcurrentDictionary(j);
                        Interlocked.Add(ref total, str.Length);
                    }
                });

                tasks.Add(task);
            }

            mre.Set();
            await Task.WhenAll(tasks);

            return total;
        }

        [Benchmark]
        public async Task<long> ConcurrentReadsUsingFrozentDictionary()
        {
            long total = 0;

            var tasks = new List<Task>(_mdop);
            var mre = new ManualResetEvent(false);

            for (int i = 0; i < _mdop; i++)
            {
                var task = Task.Run(() =>
                {
                    mre.WaitOne();

                    for (int j = 0; j < Count; j++)
                    {
                        var str = KeyLookupUsingFrozenDictionary(j);
                        Interlocked.Add(ref total, str.Length);
                    }
                });

                tasks.Add(task);
            }

            mre.Set();
            await Task.WhenAll(tasks);

            return total;
        }

        [Benchmark(Baseline = true)]
        public async Task<long> ConcurrentReadsUsingDictionaryNoLockingNotThreadSafe()
        {
            long total = 0;

            var tasks = new List<Task>(_mdop);
            var mre = new ManualResetEvent(false);

            for (int i = 0; i < _mdop; i++)
            {
                var task = Task.Run(() =>
                {
                    mre.WaitOne();

                    for (int j = 0; j < Count; j++)
                    {
                        var str = KeyLookupNoLockingNotThreadSafe(j);
                        Interlocked.Add(ref total, str.Length);
                    }
                });

                tasks.Add(task);
            }

            mre.Set();
            await Task.WhenAll(tasks);

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

        private string KeyLookupUsingFrozenDictionary(int key)
        {
            return _frozendict[key];
        }

        private string KeyLookupNoLockingNotThreadSafe(int key)
        {
            return _dict[key];
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
