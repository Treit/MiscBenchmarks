namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using System.Linq;

    [MemoryDiagnoser]
    [ShortRunJob]
    public class Benchmark
    {
        [Params(10, 100, 1000, 100_000, 1_000_000)]
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
        }

        [Benchmark(Baseline = true)]
        public int PopulateWithExplicitArray()
        {
            int[] range = new int[Count];

            for (int i = 0; i < range.Length; i++)
            {
                range[i] = i + 1;
            }

            return range.Length;
        }

        [Benchmark]
        public int PopulateWithEnumerableRange()
        {
            return Enumerable.Range(1, Count).ToArray().Length;
        }

        [Benchmark]
        public double PopulateAndTakeAverageWithExplicitArray()
        {
            int[] range = new int[Count];

            for (int i = 0; i < range.Length; i++)
            {
                range[i] = i + 1;
            }

            return range.Average();
        }

        [Benchmark]
        public double PopulateAndTakeAverageWithEnumerableRange()
        {
            return Enumerable.Range(1, Count).Average();
        }

        [Benchmark]
        public long PopulateAndTakeSumWithExplicitArray()
        {
            long[] range = new long[Count];

            for (int i = 0; i < range.Length; i++)
            {
                range[i] = i + 1;
            }

            return range.Sum();
        }

        [Benchmark]
        public long PopulateAndTakeSumWithEnumerableRange()
        {
            return Enumerable.Range(1, Count).Select(x => (long)x).Sum();
        }
    }
}
