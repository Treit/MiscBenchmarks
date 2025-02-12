namespace Test
{
    using BenchmarkDotNet.Attributes;
    using System.Collections.Generic;

    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(100)]
        public int Count { get; set; }

        private IDictionary<string, int> _itemsToAppend;

        [GlobalSetup]
        public void GlobalSetup()
        {
            var temp = new Dictionary<string, int>();

            for (int i = 0; i < Count; i++)
            {
                temp.Add(i.ToString(), i);
            }

            _itemsToAppend = temp;
        }

        [Benchmark]
        public long AddToDictWithForEachLoop()
        {
            var dict = new Dictionary<string, int>();

            foreach (var i in _itemsToAppend)
            {
                dict.Add(i.Key, i.Value);
            }

            return dict.Count;
        }

        [Benchmark]
        public long AddToDictPresetCapacity()
        {
            var dict = new Dictionary<string, int>(Count);

            foreach (var i in _itemsToAppend)
            {
                dict.Add(i.Key, i.Value);
            }

            return dict.Count;
        }

        [Benchmark(Baseline = true)]
        public long AddToDictWithConstructor()
        {
            var dict = new Dictionary<string, int>(_itemsToAppend);
            return dict.Count;
        }
    }
}
