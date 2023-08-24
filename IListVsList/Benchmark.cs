namespace Test
{
    using BenchmarkDotNet.Attributes;
    using System;
    using System.Collections.Generic;

    public class Benchmark
    {
        [Params(100, 100_000)]
        public int Count { get; set; }

        private List<int> _list;

        public IList<int> GetIList()
        {
            return _list;
        }

        public List<int> GetList()
        {
            return _list;
        }

        [GlobalSetup]
        public void GlobalSetup()
        {
            _list = new List<int>(Count);
            var r = new Random(Count);

            for (int i = 0; i < Count; i++)
            {
                if (r.Next() % 2 == 0)
                {
                    _list.Add(i);
                }
                else
                {
                    _list.Add(-1);
                }
            }
        }

        [Benchmark]
        public int LookupElementWithList()
        {
            int count = 0;
            var list = GetList();

            for (int i = 0; i < Count; i++)
            {
                if (list[i] == i)
                {
                    count++;
                }
            }

            return count;
        }

        [Benchmark]
        public int LookupElementWithIList()
        {
            int count = 0;
            var list = GetIList();

            for (int i = 0; i < Count; i++)
            {
                if (list[i] == i)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
