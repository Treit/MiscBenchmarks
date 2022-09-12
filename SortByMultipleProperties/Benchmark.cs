namespace Test
{
    using BenchmarkDotNet.Attributes;
    using System;
    using System.Linq;

    public record Something(string Name, int X, int Y, double Z, Guid Id);

    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(10000)]
        public int Count { get; set; }

        private Something[] _values;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _values = new Something[Count];

            // Use Count as the seed.
            var r = new Random(Count);

            for (int i = 0; i < Count; i++)
            {
                _values[i] = new Something($"Something {i}", r.Next(), r.Next(), r.NextDouble(), Guid.NewGuid());
            }
        }

        [Benchmark(Baseline = true)]
        public Something[] SortUsingLinqOrderByThenBy()
        {
            return _values.OrderBy(x => x.Id).ThenBy(x => x.Z).ThenBy(x => x.Name).ToArray();
        }

        [Benchmark]
        public Something[] SortUsingLinqOrderByValueTupleKey()
        {
            return _values.OrderBy(x => (x.Id, x.Z, x.Name)).ToArray();
        }

        [Benchmark]
        public Something[] SortUsingParallelLinqOrderByThenBy()
        {
            return _values.AsParallel().OrderBy(x => x.Id).ThenBy(x => x.Z).ThenBy(x => x.Name).ToArray();
        }

        [Benchmark]
        public Something[] SortUsingParallelLinqOrderByValueTupleKey()
        {
            return _values.AsParallel().OrderBy(x => (x.Id, x.Z, x.Name)).ToArray();
        }
    }
}


