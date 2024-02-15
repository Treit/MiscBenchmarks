namespace Test
{
    using BenchmarkDotNet.Attributes;
    using System.Collections.Generic;
    using System.Linq;

    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(100, 10_000)]
        public int Count { get; set; }

        private List<int> _list;
        private List<int> _listToAdd;

        [IterationSetup]
        public void IterationSetup()
        {
            _list = new List<int>(Count);
            _listToAdd = new List<int>(Count);

            for (int i = 0; i < Count; i++)
            {
                _list.Add(i);
                _listToAdd.Add(i * 2);
            }
        }

        [Benchmark]
        public long AddThenEnumerateWithSpread()
        {
            List<int> newlist = [.. _list, .. _listToAdd];
            var result = 0L;

            foreach (var num in newlist)
            {
                result += num;
            }

            return result;
        }

        [Benchmark]
        public long AddThenEnumerateWithConcat()
        {
            var newlist = _list.Concat(_listToAdd);
            var result = 0L;

            foreach (var num in newlist)
            {
                result += num;
            }

            return result;
        }
    }
}
