namespace Test
{
    using BenchmarkDotNet.Attributes;
    using C5;
    using System.Collections.Generic;

    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(100_000)]
        public int Count { get; set; }

        private C5.ArrayList<int> _c5arrayList;
        private ArrayList<object> _c5arrayListObject;

        private List<int> _list;
        private List<object> _listObject;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _c5arrayList = CreateC5ArrayListOfInt();
            _list = CreateListOfInt();
            _c5arrayListObject = CreateC5ArrayListOfObject();
            _listObject = CreateListOfObject();
        }

        [Benchmark]
        public ArrayList<int> CreateC5ArrayListOfInt()
        {
            var list = new ArrayList<int>();

            for (int i = 0; i < Count; i++)
            {
                list.Add(i);
            }

            return list;
        }

        [Benchmark]
        public List<int> CreateListOfInt()
        {
            var list = new List<int>();

            for (int i = 0; i < Count; i++)
            {
                list.Add(i);
            }

            return list;
        }

        [Benchmark]
        public ArrayList<object> CreateC5ArrayListOfObject()
        {
            var list = new ArrayList<object>();

            for (int i = 0; i < Count; i++)
            {
                list.Add((object)i.ToString());
            }

            return list;
        }

        [Benchmark]
        public List<object> CreateListOfObject()
        {
            var list = new List<object>();

            for (int i = 0; i < Count; i++)
            {
                list.Add((object)i.ToString());
            }

            return list;
        }

        [Benchmark]
        public long IterateC5ArrayListOfInt()
        {
            int sum = 0;

            foreach (var val in _c5arrayList)
            {
                sum += (int)val;
            }

            return sum;
        }

        [Benchmark(Baseline = true)]
        public long IterateListOfInt()
        {
            int sum = 0;

            foreach (var val in _list)
            {
                sum += val;
            }

            return sum;
        }

        [Benchmark]
        public long IterateC5ArrayListOfObject()
        {
            int sum = 0;

            foreach (var val in _c5arrayListObject)
            {
                sum += ((string)val).Length;
            }

            return sum;
        }

        [Benchmark]
        public long IterateListOfObject()
        {
            int sum = 0;

            foreach (var val in _listObject)
            {
                sum += ((string)val).Length;
            }

            return sum;
        }
    }
}
