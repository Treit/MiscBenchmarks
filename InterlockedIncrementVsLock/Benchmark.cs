namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using System.Threading;
    using System.Threading.Tasks;

    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(1_000_000)]
        public int Count { get; set; }

        int _counter = 0;
        object _lock = new object();

        [GlobalSetup]
        public void GlobalSetup()
        {
        }

        [IterationSetup]
        public void IterationSetup()
        {
            _counter = 0;
        }

        [Benchmark(Baseline = true)]
        public int IncrementUsingInterlocked()
        {
            Parallel.For(0, Count, _ =>
            {
                Interlocked.Increment(ref _counter);
            });

            return _counter;
        }

        [Benchmark]
        public int IncrementUsingLock()
        {
            Parallel.For(0, Count, _ =>
            {
                lock (_lock)
                {
                    _counter++;
                }
            });

            return _counter;

        }
    }
}
