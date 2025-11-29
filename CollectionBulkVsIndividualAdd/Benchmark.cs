using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Jobs;

namespace CollectionBulkVsIndividualAdd
{
    [MemoryDiagnoser]
    [SimpleJob(RuntimeMoniker.Net90)]
    [SimpleJob(RuntimeMoniker.Net10_0)]
    public class Benchmark
    {
        [Params(10, 10_000)]
        public int Count { get; set; }

        private int[] _sourceData = null!;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _sourceData = Enumerable.Range(1, Count).ToArray();
        }

        [Benchmark(Baseline = true)]
        public List<int> ListIndividualAdd()
        {
            var list = new List<int>(Count);

            for (int i = 0; i < _sourceData.Length; i++)
            {
                list.Add(_sourceData[i]);
            }

            return list;
        }

        [Benchmark]
        public List<int> ListAddRange()
        {
            var list = new List<int>(Count);
            list.AddRange(_sourceData);
            return list;
        }

        [Benchmark]
        public List<int> ListConstructorWithCollection()
        {
            return new List<int>(_sourceData);
        }

        [Benchmark]
        public HashSet<int> HashSetIndividualAdd()
        {
            var hashSet = new HashSet<int>(Count);

            for (int i = 0; i < _sourceData.Length; i++)
            {
                hashSet.Add(_sourceData[i]);
            }

            return hashSet;
        }

        [Benchmark]
        public HashSet<int> HashSetUnionWith()
        {
            var hashSet = new HashSet<int>(Count);
            hashSet.UnionWith(_sourceData);
            return hashSet;
        }

        [Benchmark]
        public HashSet<int> HashSetConstructorWithCollection()
        {
            return new HashSet<int>(_sourceData);
        }
    }
}
