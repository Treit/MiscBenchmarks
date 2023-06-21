namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using System;
    using System.Collections.Generic;

    public class SomeClass
    {
        public int DoSomething()
        {
            return (int)DateTime.UtcNow.Ticks;
        }
    }

    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(10, 10_000, 100_000)]
        public int Iterations { get; set; }

        private SortedList<int, SomeClass> sortedListLookup;
        private Dictionary<int, SomeClass> dictionaryLookup;

        [GlobalSetup]
        public void GlobalSetup()
        {
            int len = 50;

            sortedListLookup = new SortedList<int, SomeClass>(len);
            dictionaryLookup = new Dictionary<int, SomeClass>(len);

            for (int i = 0; i < len; i++)
            {
                sortedListLookup.Add(i, new SomeClass());
                dictionaryLookup.Add(i, new SomeClass());
            }
        }

        [Benchmark(Baseline = true)]
        public long LookupUsingDictionary()
        {
            long result = 0;

            for (int i = 0; i < this.Iterations; i++)
            {
                for (int j = 0; j < sortedListLookup.Count; j++)
                {
                    SomeClass c = dictionaryLookup[j];
                    result += c.DoSomething();
                }
            }

            return result;
        }

        [Benchmark]
        public long LookupUsingSortedList()
        {
            long result = 0;

            for (int i = 0; i < this.Iterations; i++)
            {
                for (int j = 0; j < sortedListLookup.Count; j++)
                {
                    SomeClass c = sortedListLookup[j];
                    result += c.DoSomething();
                }
            }

            return result;
        }
    }
}
