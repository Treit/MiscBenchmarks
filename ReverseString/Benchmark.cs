namespace Test
{
    using BenchmarkDotNet.Attributes;
    using System;
    using System.Collections.Generic;
using System.Drawing;
    using System.Linq;

    [MemoryDiagnoser]
    [ShortRunJob]
    public class Benchmark
    {
        [Params(10, 100, 10_000)]
        public int Count { get; set; }

        private List<string> _values;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _values = new List<string>(Count);

            for (int i = 0; i < this.Count; i++)
            {
                var str = Guid.NewGuid().ToString();
                _values.Add(str);
            }
        }

        [Benchmark(Baseline = true)]
        public long ReverseStringUsingLinqAndNew()
        {
            long total = 0;

            for (int i = 0; i < this.Count; i++)
            {
                var str = new string(_values[i].Reverse().ToArray());
                total += str.Length;
            }

            return total;
        }

        [Benchmark]
        public long ReverseStringUsingLinqAndJoin()
        {
            long total = 0;

            for (int i = 0; i < this.Count; i++)
            {
                var str = string.Join("", _values[i].Reverse());
                total += str.Length;
            }

            return total;
        }

        [Benchmark]
        public long ReverseStringUsingExplicitCopy()
        {
            long total = 0;

            for (int i = 0; i < this.Count; i++)
            {
                char[] buff = new char[_values[i].Length];

                for (int j = 0, k = buff.Length - 1; j < buff.Length; j++, k--)
                {
                    buff[k] = _values[i][j];
                }

                total += new string(buff).Length;
            }

            return total;
        }

        [Benchmark]
        public long ReverseStringUsingStringCreate()
        {
            long total = 0;

            for (int i = 0; i < this.Count; i++)
            {
                int len = string.Create(_values[i].Length, _values[i], (buff, str) =>
                {
                    for (int j = 0, k = buff.Length - 1; j < buff.Length; j++, k--)
                    {
                        buff[k] = str[j];
                    }

                }).Length;

                total += len;
            }

            return total;
        }

        [Benchmark]
        public long ReverseStringUsingArrayReverse()
        {
            long total = 0;

            for (int i = 0; i < this.Count; i++)
            {
                var buff = _values[i].ToCharArray();
                Array.Reverse(buff);
                total += new string(buff).Length;
            }

            return total;
        }
    }
}
