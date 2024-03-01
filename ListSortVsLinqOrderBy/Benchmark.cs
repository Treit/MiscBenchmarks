namespace Test
{
    using BenchmarkDotNet.Attributes;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public record SomeData(string Name, int Score);

    [MemoryDiagnoser]
    [MemoryRandomization]
    public class Benchmark
    {
        [Params(100, 100_000)]
        public int Count { get; set; }

        private List<SomeData> _values;
        private List<SomeData> _listToSortA;
        private List<SomeData> _listToSortB;
        private List<SomeData> _listToSortC;
        private List<SomeData> _listToSortD;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _values = new List<SomeData>(Count);

            // Use Count as the seed.
            var r = new Random(Count);

            for (int i = 0; i < Count; i++)
            {
                _values.Add(new SomeData($"Name {i}", r.Next(1000)));
            }
        }

        [IterationSetup]
        public void IterationSetup()
        {
            _listToSortA = new List<SomeData>(_values);
            _listToSortB = new List<SomeData>(_values);
            _listToSortC = new List<SomeData>(_values);
            _listToSortD = new List<SomeData>(_values);
        }

        [Benchmark(Baseline = true)]
        public List<SomeData> ListSort()
        {
            var tosort = _listToSortA;
            tosort.Sort((x, y) => x.Score.CompareTo(y.Score));
            return tosort;
        }

        [Benchmark]
        public List<SomeData> LinqSort()
        {
            var tosort = _listToSortB;
            var sorted = tosort.OrderBy(x => x.Score).ToList();
            return sorted;
        }

        [Benchmark]
        public List<SomeData> ListSortDescending()
        {
            var tosort = _listToSortC;
            tosort.Sort((x, y) => y.Score.CompareTo(x.Score));
            return tosort;
        }

        [Benchmark]
        public List<SomeData> LinqSortDescending()
        {
            var tosort = _listToSortD;
            var sorted = tosort.OrderByDescending(x => x.Score).ToList();
            return sorted;
        }
    }
}

