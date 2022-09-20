namespace Test
{
    using BenchmarkDotNet.Attributes;
    using System.Collections;
    using System.Collections.Generic;

    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(100_000)]
        public int Count { get; set; }

        private ArrayList _arrayList;

        private List<int> _list;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _arrayList = CreateArrayList();
            _list = CreateList();
        }

        [Benchmark]
        public ArrayList CreateArrayList()
        {
            var list = new ArrayList();

            for (int i = 0; i < Count; i++)
            {
                list.Add(i);
            }

            return list;
        }

        [Benchmark]
        public List<int> CreateList()
        {
            var list = new List<int>();

            for (int i = 0; i < Count; i++)
            {
                list.Add(i);
            }

            return list;
        }

        [Benchmark]
        public long IterateArrayList()
        {
            int sum = 0;

            foreach (var val in _arrayList)
            {
                sum += (int)val;
            }

            return sum;
        }

        [Benchmark(Baseline = true)]
        public long IterateList()
        {
            int sum = 0;

            foreach (var val in _list)
            {
                sum += val;
            }

            return sum;
        }
    }
}
