namespace Test
{
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;

[Serializable]
public record SomeClass(string Name, int Value, List<string> SomeData, List<int> SomeMoreData, Guid SomeGuid);

    [MemoryDiagnoser]
    public class Benchmark
    {
        private List<SomeClass> _data;

        [Params(10, 10_000)]
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            var r = new Random(Count);
            _data = new();

            for (int i = 0; i < Count; i++)
            {
                var randomData = new List<string>();
                var randomMoreData = new List<int>();
                for (int j = 0; j < 10; j++)
                {
                    randomData.Add(Guid.NewGuid().ToString());
                    randomMoreData.Add(r.Next());
                }

                var item = new SomeClass(
                    Guid.NewGuid().ToString(),
                    r.Next(),
                    randomData,
                    randomMoreData,
                    Guid.NewGuid()
                );

                _data.Add(item);
            }
        }

        [Benchmark]
        public List<SomeClass> CloneWithBinaryFormatter()
        {
            using var ms = new MemoryStream();
            var formatter = new BinaryFormatter();
            formatter.Serialize(ms, _data);
            ms.Position = 0;
            return (List<SomeClass>)formatter.Deserialize(ms);
        }

        [Benchmark(Baseline = true)]
        public List<SomeClass> CloneWithJson()
        {
            var json = JsonSerializer.Serialize(_data);
            return JsonSerializer.Deserialize<List<SomeClass>>(json);
        }
    }
}
