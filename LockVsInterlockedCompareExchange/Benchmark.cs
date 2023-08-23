namespace Test
{
    using BenchmarkDotNet.Attributes;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Serialization;

    public class Benchmark
    {
        object _lock = new();
        long _target;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _target = 1234;
        }

        [Benchmark]
        public long ReadAndWriteWithLock()
        {
            lock (_lock)
            {
                if (_target == 1234)
                {
                    _target = 4567;
                }
            }

            return _target;
        }

        [Benchmark]
        public long ReadAndWriteWithInterlockedCompareExchange()
        {
            Interlocked.CompareExchange(ref _target, 1234, 4567);
            return _target;
        }
    }
}
