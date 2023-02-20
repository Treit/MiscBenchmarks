namespace Test
{
    using BenchmarkDotNet.Attributes;
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(10, 1000)]
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
        public long ConcurrentReadsUsingParallelFor()
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
        public async Task<long> ConcurrentReadsUsingExplicitTasks()
        {
            long total = 0;
            var tasks = new Task[Count];

            for (int i = 0; i < Count; i++)
            {
                int tmp = i;
                tasks[tmp] = Task.Run(() =>
                {
                    var str = KeyLookupUsingLock(tmp);
                    Interlocked.Add(ref total, str.Length);
                });
            }

            await Task.WhenAll(tasks);

            return total;
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
