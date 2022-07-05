namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(1000, 100_000, 1_000_000)]
        public int Iterations { get; set; }

        public List<string> strings;

        private static HashSet<int> errorCodesHashSet = new HashSet<int> { -109100, -109101, -109102, -109107 };

        private static List<int> errorCodesList = new List<int> { -109100, -109101, -109102, -109107 };

        [GlobalSetup]
        public void GlobalSetup()
        {
        }

        [Benchmark]
        public int LookupUsingHashSet()
        {
            int count = 0;

            for (int i = 0; i < this.Iterations; i++)
            {
                if (errorCodesHashSet.Contains(i))
                {
                    count++;
                }
            }

            return count;
        }

        [Benchmark]
        public int LookupUsingList()
        {
            int count = 0;

            for (int i = 0; i < this.Iterations; i++)
            {
                if (errorCodesList.Contains(i))
                {
                    count++;
                }
            }

            return count;
        }

        [Benchmark]
        public int LookupUsingConditional()
        {
            int count = 0;

            for (int i = 0; i < this.Iterations; i++)
            {
                if (i == -109100 || i == -109101 || i == -109102 || i == -109107)
                {
                    count++;
                }
            }

            return count;
        }

        [Benchmark]
        public int LookupUsingSwitch()
        {
            int count = 0;

            for (int i = 0; i < this.Iterations; i++)
            {
                switch (i)
                {
                    case -109100:
                    case -109101:
                    case -109102:
                    case -109107:
                        count++;
                        break;
                }
            }

            return count;
        }

        [Benchmark]
        public int LookupUsingRange()
        {
            int count = 0;

            for (int i = 0; i < this.Iterations; i++)
            {
                if (i == -109107 || i >= -109100 && i <= -109102)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
