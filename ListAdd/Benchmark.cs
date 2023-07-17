namespace Test
{
    using BenchmarkDotNet.Attributes;
    using System.Collections;
    using System.Collections.Generic;

    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(100, 10_000, 1_000_000)]
        public int Count { get; set; }

        private List<int> _listNormal;
        private List<int> _listWithCapacity;

        [IterationSetup]
        public void IterationSetup()
        {
            _listNormal = new List<int>();
            _listWithCapacity = new List<int>(Count);
        }

        [Benchmark]
        public List<int> AddToListNormal()
        {
            var list = _listNormal;

            for (int i = 0; i < Count; i++)
            {
                list.Add(i);
            }

            return list;
        }

        [Benchmark]
        public List<int> AddToListPresetCapacity()
        {
            var list = _listWithCapacity;

            for (int i = 0; i < Count; i++)
            {
                list.Add(i);
            }

            return list;
        }
    }
}
