namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using System.Collections.Concurrent;
    using System.Collections.Frozen;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(1000)]
        public int Count { get; set; }

        private Dictionary<int, string> _dictionaryInt;
        private FrozenDictionary<int, string> _frozenDictionaryInt;
        private ConcurrentDictionary<int, string> _concurrentDictionaryInt;
        private Dictionary<int, string> _lockedDictionaryInt;
        private Dictionary<int, string> _rwLockDictionaryInt;
        private Dictionary<int, string> _rwLockSlimDictionaryInt;
        private readonly object _lockObjectInt = new object();
        private readonly ReaderWriterLock _rwLockInt = new ReaderWriterLock();
        private readonly ReaderWriterLockSlim _rwLockSlimInt = new ReaderWriterLockSlim();
        private int _keyInt;

        private Dictionary<string, string> _dictionaryString;
        private FrozenDictionary<string, string> _frozenDictionaryString;
        private ConcurrentDictionary<string, string> _concurrentDictionaryString;
        private Dictionary<string, string> _lockedDictionaryString;
        private Dictionary<string, string> _rwLockDictionaryString;
        private Dictionary<string, string> _rwLockSlimDictionaryString;
        private readonly object _lockObjectString = new object();
        private readonly ReaderWriterLock _rwLockString = new ReaderWriterLock();
        private readonly ReaderWriterLockSlim _rwLockSlimString = new ReaderWriterLockSlim();
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

            // Initialize the new dictionary implementations for integer keys
            _concurrentDictionaryInt = new ConcurrentDictionary<int, string>(_dictionaryInt);
            _lockedDictionaryInt = new Dictionary<int, string>(_dictionaryInt);
            _rwLockDictionaryInt = new Dictionary<int, string>(_dictionaryInt);
            _rwLockSlimDictionaryInt = new Dictionary<int, string>(_dictionaryInt);

            // Setup for string keys
            _dictionaryString = new Dictionary<string, string>(len);

            for (int i = 0; i < len; i++)
            {
                _dictionaryString.Add(i.ToString(), i.ToString());
            }

            _keyString = _dictionaryString.Keys.Skip(len / 2).Take(1).First();
            _frozenDictionaryString = FrozenDictionary.ToFrozenDictionary(_dictionaryString);

            // Initialize the new dictionary implementations for string keys
            _concurrentDictionaryString = new ConcurrentDictionary<string, string>(_dictionaryString);
            _lockedDictionaryString = new Dictionary<string, string>(_dictionaryString);
            _rwLockDictionaryString = new Dictionary<string, string>(_dictionaryString);
            _rwLockSlimDictionaryString = new Dictionary<string, string>(_dictionaryString);
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
        public string LookupUsingConcurrentDictionaryInt()
        {
            return _concurrentDictionaryInt[_keyInt];
        }

        [Benchmark]
        public string LookupUsingLockedDictionaryInt()
        {
            string result;
            lock (_lockObjectInt)
            {
                result = _lockedDictionaryInt[_keyInt];
            }
            return result;
        }

        [Benchmark]
        public string LookupUsingReaderWriterLockInt()
        {
            string result;
            _rwLockInt.AcquireReaderLock(Timeout.Infinite);
            try
            {
                result = _rwLockDictionaryInt[_keyInt];
            }
            finally
            {
                _rwLockInt.ReleaseReaderLock();
            }
            return result;
        }

        [Benchmark]
        public string LookupUsingReaderWriterLockSlimInt()
        {
            string result;
            _rwLockSlimInt.EnterReadLock();
            try
            {
                result = _rwLockSlimDictionaryInt[_keyInt];
            }
            finally
            {
                _rwLockSlimInt.ExitReadLock();
            }
            return result;
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

        [Benchmark]
        public string LookupUsingConcurrentDictionaryString()
        {
            return _concurrentDictionaryString[_keyString];
        }

        [Benchmark]
        public string LookupUsingLockedDictionaryString()
        {
            string result;
            lock (_lockObjectString)
            {
                result = _lockedDictionaryString[_keyString];
            }
            return result;
        }

        [Benchmark]
        public string LookupUsingReaderWriterLockString()
        {
            string result;
            _rwLockString.AcquireReaderLock(Timeout.Infinite);
            try
            {
                result = _rwLockDictionaryString[_keyString];
            }
            finally
            {
                _rwLockString.ReleaseReaderLock();
            }
            return result;
        }

        [Benchmark]
        public string LookupUsingReaderWriterLockSlimString()
        {
            string result;
            _rwLockSlimString.EnterReadLock();
            try
            {
                result = _rwLockSlimDictionaryString[_keyString];
            }
            finally
            {
                _rwLockSlimString.ExitReadLock();
            }
            return result;
        }
    }
}
