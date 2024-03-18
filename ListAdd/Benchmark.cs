namespace Test
{
    using BenchmarkDotNet.Attributes;
    using System.Collections.Generic;
    using System.Linq;

    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(100, 1_000_000)]
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
        public long AddToListNormal()
        {
            var list = _listNormal;

            for (int i = 0; i < Count; i++)
            {
                list.Add(i);
            }

            return list.Max();
        }

        [Benchmark(Baseline = true)]
        public long AddToListPresetCapacity()
        {
            var list = _listWithCapacity;

            for (int i = 0; i < Count; i++)
            {
                list.Add(i);
            }

            return list.Max();
        }

        [Benchmark]
        public long AddToListWithAppend()
        {
            IEnumerable<int> list = _listNormal;

            for (int i = 0; i < Count; i++)
            {
                list = list.Append(i);
            }

            return list.Max();
        }        
    }
}
