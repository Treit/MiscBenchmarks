namespace Test
{
    using BenchmarkDotNet.Attributes;
    using System.Collections.Generic;
    using System.Linq;

    public class Benchmark
    {
        [Params(1000, 100_000, 1_000_000)]
        public int Count { get; set; }

        private List<int> _data;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _data = new List<int>(Count);

            for (int i = 0; i < Count; i++)
            {
                _data.Add(i);
            }
        }

        [Benchmark(Baseline = true)]
        public long CopyWithListConstructor()
        {
            var newList = new List<int>(_data);
            return newList[0] + newList[newList.Count - 1];
        }

        [Benchmark]
        public long CopyWithToList()
        {
            var newList = _data.ToList();
            return newList[0] + newList[newList.Count - 1];
        }

        [Benchmark]
        public long CopyExplicitly()
        {
            var newList = new List<int>(_data.Count); ;
            foreach (var val in _data)
            {
                newList.Add(val);
            }

            return newList[0] + newList[newList.Count - 1];
        }
    }
}
