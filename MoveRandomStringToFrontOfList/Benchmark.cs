using System.Text;

namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.InteropServices;

    [MemoryDiagnoser]
    public class Benchmark
    {
        private List<string> _strings;

        [Params(1000)]
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            _strings = new List<string>(Count);

            var random = new Random(Count);

            for (int i = 0; i < Count; i++)
            {
                _strings.Add(RandomStringCreate(random, "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789", 100));
            }
        }

        [Benchmark(Baseline = true)]
        public string MoveUsingRandomIndex()
        {
            var random = new Random(Count);
            var index = random.Next(_strings.Count);
            var temp = _strings[index];
            _strings.RemoveAt(index);
            _strings.Insert(0, temp);
            return temp;
        }

        [Benchmark]
        public string MoveUsingLinqOrderByRandomWithUnecessaryToList()
        {
            Random rdm = new Random(Count);
            var temp = _strings.OrderBy(a => rdm.Next()).ToList().First();
            _strings.Remove(temp);
            _strings.Insert(0, temp);
            return temp;
        }

        static string RandomStringCreate(Random random, string alphabet, int fixedLength)
        {
            var len = fixedLength;
            return string.Create(len, random, (buff, str) =>
            {
                for (int i = 0; i < buff.Length; i++)
                {
                    buff[i] = alphabet[random.Next(alphabet.Length)];
                }
            });
        }
    }
}

