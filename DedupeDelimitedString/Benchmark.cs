namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    [MemoryDiagnoser]
    public class Benchmark
    {
        private string _delimitedString;

        [Params(10, 1000)]
        public int Count;

        [GlobalSetup]
        public void GlobalSetup()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < Count; i++)
            {
                sb.Append(i);

                if (i < Count - 1)
                {
                    sb.Append(',');
                }
            }

            _delimitedString = sb.ToString();
        }

        [Benchmark]
        public int DedupeWithRemoveDuplicateFunction()
        {
            var result = 0;
            var deduped = RemoveDuplicates(_delimitedString).Split(',');

            foreach (var item in deduped)
            {
                result += item.Length;
            }

            return result;

            static string RemoveDuplicates(string nameList)
            {
                var hashSet = new HashSet<string>();
                var result = nameList;

                if (!string.IsNullOrWhiteSpace(nameList))
                {
                    foreach (var name in nameList.Split(','))
                    {
                        hashSet.Add(name.Trim());
                    }
                    result = string.Join(",", hashSet);
                }

                return result;
            }
        }

        [Benchmark(Baseline = true)]
        public int DedupeWithLinqDistinct()
        {
            var result = 0;
            var deduped = _delimitedString.Split(',').Select(x => x.Trim()).Distinct();

            foreach (var item in deduped)
            {
                result += item.Length;
            }

            return result;
        }

        [Benchmark]
        public int DedupeWithLinqDistinctStringSplitOptions()
        {
            var result = 0;
            var opts = StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries;
            var deduped = _delimitedString.Split(',', opts).Distinct();

            foreach (var item in deduped)
            {
                result += item.Length;
            }

            return result;
        }        
    }
}
