namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Item
    {
        public int Id { get; set; }
        public string Payload { get; set; }

        public bool Matches(Item item)
        {
            return this.Id == item.Id;
        }
    }

    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(10, 100, 10000)]
        public int Count { get; set; }

        List<Item> _allItems = new List<Item>();
        List<Item> _acceptedList = new List<Item>();
        Dictionary<int, Item> _acceptedDict = new Dictionary<int, Item>();

        [GlobalSetup]
        public void GlobalSetup()
        {
            for (int i = 0; i < Count; i++)
            {
                var item = new Item { Id = i, Payload = $"SomeData-{i}" };
                _allItems.Add(item);

                if (i % 3 == 0)
                {
                    _acceptedDict.Add(item.Id, item);
                    _acceptedList.Add(item);
                }
            }
        }

        [Benchmark(Baseline = true)]
        public IList<Item> FindMatchesUsingDictionary()
        {
            var result = new List<Item>();

            foreach (var item in _allItems)
            {
                if (_acceptedDict.TryGetValue(item.Id, out var match))
                {
                    result.Add(match);
                }
            }

            return result;
        }

        [Benchmark]
        public IList<Item> FindMatchesUsingFirstOrDeault()
        {
            var result = new List<Item>();

            foreach (var item in _allItems)
            {
                var match = _acceptedList.FirstOrDefault(x => x.Id == item.Id);

                if (match != null)
                {
                    result.Add(match);
                }
            }

            return result;
        }

        [Benchmark]
        public IList<Item> FindMatchesUsingFirstOrDeaultNoLambda()
        {
            var result = new List<Item>();

            foreach (var item in _allItems)
            {
                var match = _acceptedList.FirstOrDefault(item.Matches);

                if (match != null)
                {
                    result.Add(match);
                }
            }

            return result;
        }
    }
}


