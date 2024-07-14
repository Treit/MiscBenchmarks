namespace Test
{
    using BenchmarkDotNet.Attributes;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(100, 1_000_000)]
        public int Count { get; set; }

        private List<int> _listNormal;
        private ConcurrentBag<int> _concurrentBag;

        private readonly object _syncobj = new();

        [IterationSetup]
        public void IterationSetup()
        {
            _listNormal = new();
            _concurrentBag = new();
        }

        [Benchmark(Baseline = true)]
        public long ConcurrentAddToNormalListWithLock()
        {
            var list = _listNormal;

            Parallel.For(0, Count, i =>
            {
                lock (_syncobj)
                {
                    list.Add(i);
                }
            });

            return list.Max();
        }

        [Benchmark]
        public long ConcurrentAddToConcurrentBag()
        {
            Parallel.For(0, Count, i =>
            {
                _concurrentBag.Add(i);
            });

            return _concurrentBag.Max();
        }
    }
}
