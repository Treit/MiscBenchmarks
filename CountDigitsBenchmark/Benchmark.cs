namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using System;
    using System.Collections.Generic;

    [MemoryDiagnoser]
    [ShortRunJob]
    public class Benchmark
    {
        [Params(10, 100, 1000, 100_000, 1_000_000)]
        public int Count { get; set; }

        private List<int> _values;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _values = new List<int>(Count);

            for (int i = 0; i < this.Count; i++)
            {
                _values.Add(i);
            }
        }


        [Benchmark]
        public int CountDigitsUsingMath()
        {
            int total = 0;

            for (int i = 0; i < _values.Count; i++)
            {
                total += NumDigitsUsingMath(_values[i]);
            }

            return total;

        }

        [Benchmark]
        public int CountDigitsUsingString()
        {
            int total = 0;

            for (int i = 0; i < _values.Count; i++)
            {
                total += NumDigtsUsingStr(_values[i]);
            }

            return total;
        }

        static int NumDigitsUsingMath(int number)
        {
            return (int)Math.Floor(Math.Log10(Math.Abs(number))) + 1;
        }

        static int NumDigtsUsingStr(int number)
        {
            return number.ToString().Length;
        }

    }
}
