namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using System.Collections.Generic;
    using System.Linq;

    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(100, 10_000)]
        public int Count;
        private ICollection<int> _initialCollection;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _initialCollection = Enumerable.Range(0, Count).ToList();
        }

        [Benchmark]
        public List<int> Aggregate()
            => _initialCollection.Aggregate(
                    new List<int>(),
                    (list, next) =>
                    {
                        list.Add(next * 10);
                        return list;
                    });

        [Benchmark]
        public List<int> SelectToList()
            => _initialCollection.Select(i => i * 10).ToList();
        }
}
