using BenchmarkDotNet.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Test
{
    record MyType(string Name, int Age);

    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(100, 10_000, 100_000)]
        public int Count { get; set; }

        private List<MyType> _data = new();

        private JsonSerializerOptions _options;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _options = new JsonSerializerOptions { WriteIndented = false };

            for (int i = 0; i < Count; i++)
            {
                _data.Add(new MyType($"SomeName{i}", i));
            }

            using var fs = new FileStream(@"data.json", FileMode.Create);
            JsonSerializer.Serialize(fs, _data);
        }

        [Benchmark]
        public async Task<long> DeserializeAsyncEnumerable()
        {
            using var fs = new FileStream(@"data.json", FileMode.Open);
            var data = JsonSerializer.DeserializeAsyncEnumerable<MyType>(fs, _options);
            var result = 0L;
            await foreach (var item in data)
            {
                result += item.Age;
            }

            return result;
        }

        [Benchmark]
        public long DeserializeNormal()
        {
            using var fs = new FileStream(@"data.json", FileMode.Open);
            var data = JsonSerializer.Deserialize<List<MyType>>(fs, _options);
            var result = 0L;
            foreach (var item in data)
            {
                result += item.Age;
            }

            return result;
        }
    }
}
