namespace Test
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using Microsoft.VisualBasic;

    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(1000)]
        public int Count { get; set; } = 1000;

        [GlobalSetup]
        public void GlobalSetup()
        {
            Directory.CreateDirectory("temp");
            var bigfile = Path.Combine("temp", "bigfile");
            using var sw = new StreamWriter(bigfile);
            for (int i = 0; i < Count; i++)
            {
                File.WriteAllText(Path.Combine("temp", i.ToString()), i.ToString());
                sw.WriteLine(i);
            }
        }

        [GlobalCleanup]
        public void GlobalCleanup()
        {
            Directory.Delete("temp", true);
        }

        [Benchmark]
        public int ManySmallFiles()
        {
            int sum = 0;
            for (int i = 0; i < Count; i++)
            {
                sum += int.Parse(File.ReadAllText(Path.Combine("temp", i.ToString())));
            }
            return sum;
        }

        [Benchmark]
        public int OneBigFile()
        {
            int sum = 0;
            using (var sr = new StreamReader(Path.Combine("temp", "bigfile")))
            {
                while (!sr.EndOfStream)
                {
                    sum += int.Parse(sr.ReadLine());
                }
            }
            return sum;
        }
    }
}
