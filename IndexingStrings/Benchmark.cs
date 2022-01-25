namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using System;
    using System.Collections.Generic;

    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(10, 1000, 10_000)]
        public int Count { get; set; }

        private List<string> _strings;
        private List<char[]> _stringAsChars;
        private List<int[]> _stringsAsInts;
        private readonly int[] _searchPositions = new int[4] { 0, 4, 10, 16 };

        [GlobalSetup]
        public void GlobalSetup()
        {
            _strings = new List<string>(Count);
            _stringAsChars = new List<char[]>(Count);
            _stringsAsInts = new List<int[]>(Count);

            for (int i = 0; i < Count; i++)
            {
                string s = Guid.NewGuid().ToString();
                _strings.Add(s);
                _stringAsChars.Add(s.ToCharArray());

                int[] intVals = new int[s.Length];

                for (int j = 0; j < s.Length; j++)
                {
                    intVals[j] = s[j];
                }

                _stringsAsInts.Add(intVals);
            }
        }

        [Benchmark(Baseline = true)]
        public long FindIndexesInString()
        {
            long total = 0;

            foreach (var s in _strings)
            {
                foreach (int i in _searchPositions)
                {
                    if (s[i] == 'f')
                    {
                        total++;
                    }
                }
            }

            return total;
        }

        [Benchmark]
        public long FindIndexesInIntArray()
        {
            long total = 0;

            foreach (var s in _stringsAsInts)
            {
                foreach (int i in _searchPositions)
                {
                    if (s[i] == 'f')
                    {
                        total++;
                    }
                }
            }

            return total;
        }

        [Benchmark]
        public long FindIndexesInCharArray()
        {
            long total = 0;

            foreach (var s in _stringAsChars)
            {
                foreach (int i in _searchPositions)
                {
                    if (s[i] == 'f')
                    {
                        total++;
                    }
                }
            }

            return total;
        }
    }
}


