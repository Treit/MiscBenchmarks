using System.Text;

namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
        using System.Linq;

    [MemoryDiagnoser]
    public class Benchmark
    {
        private int[] _ints;

        [Params(10, 10_000)]
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            _ints = new int[Count];

            for (int i = 0; i < Count; i++)
            {
                _ints[i] = i;
            }
        }

        [Benchmark]
        public long SumUsingForLoop()
        {
            long result = 0;
            var ints = _ints;

            for (int i = 0; i < ints.Length; i++)
            {
                result += ints[i];
            }

            return result;
        }

        [Benchmark(Baseline = true)]
        public long SumUsingLinqSum()
        {
            return _ints.Sum();
        }
    }
}


