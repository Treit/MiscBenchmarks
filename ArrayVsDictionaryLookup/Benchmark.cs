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
    [ShortRunJob]
    public class Benchmark
    {
        [Params(10, 100, 1000, 10_000, 100_000)]
        public int Iterations { get; set; }

        private SomeClass[] arrayLookup;

        private Dictionary<int, SomeClass> dictionaryLookup;

        [GlobalSetup]
        public void GlobalSetup()
        {
            int len = 50;

            arrayLookup = new SomeClass[len];
            dictionaryLookup = new Dictionary<int, SomeClass>(len);

            for (int i = 0; i < len; i++)
            {
                arrayLookup[i] = new SomeClass();
                dictionaryLookup.Add(i, new SomeClass());
            }
        }

        [Benchmark]
        public long LookupUsingArray()
        {
            long result = 0;

            for (int i = 0; i < this.Iterations; i++)
            {
                for (int j = 0; j < arrayLookup.Length; j++)
                {
                    SomeClass c = arrayLookup[j];
                    result += c.DoSomething();
                }
            }

            return result;
        }

        [Benchmark]
        public long LookupUsingDictionary()
        {
            long result = 0;

            for (int i = 0; i < this.Iterations; i++)
            {
                for (int j = 0; j < arrayLookup.Length; j++)
                {
                    SomeClass c = dictionaryLookup[j];
                    result += c.DoSomething();
                }
            }

            return result;
        }

    }
}
