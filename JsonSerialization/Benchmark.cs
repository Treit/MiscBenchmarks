using BenchmarkDotNet.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Test
{
    record MyType(string Name, int Age);

    [JsonSourceGenerationOptions(WriteIndented = false)]
    [JsonSerializable(typeof(MyType))]
    internal partial class SourceGenerationContext : JsonSerializerContext
    {
    }

    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(10, 1000)]
        public int Count { get; set; }

        private List<MyType> _data = new();

        private JsonSerializerOptions _options;

        [GlobalSetup]
        public void GlobalSetup()
        {
            for (int i = 0; i < Count; i++)
            {
                _data.Add(new MyType($"SomeName{i}", i));
                _options = new JsonSerializerOptions { WriteIndented = false };
            }
        }

        [Benchmark(Baseline = true)]
        public long SerializeAndDeserializeSTJ()
        {
            long total = 0;

            foreach (var item in _data)
            {
                total += SystemTextJson(item);
            }

            return total;
        }

        [Benchmark]
        public long SerializeAndDeserializeSTJCachedOptions()
        {
            long total = 0;

            foreach (var item in _data)
            {
                total += SystemTextJson(item, _options);
            }

            return total;
        }

        [Benchmark]
        public long SerializeAndDeserializeSTJSourceGen()
        {
            long total = 0;

            foreach (var item in _data)
            {
                total += SystemTextJsonSourceGen(item);
            }

            return total;
        }

        [Benchmark]
        public long SerializeAndDeserializeSTJCaseInsensitive()
        {
            long total = 0;
            var opts = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            foreach (var item in _data)
            {
                total += SystemTextJson(item, opts);
            }

            return total;
        }

        [Benchmark]
        public long SerializeAndDeserializeSTJCaseInsensitiveSourceGen()
        {
            long total = 0;
            var opts = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            foreach (var item in _data)
            {
                total += SystemTextJsonSourceGen(item, opts);
            }

            return total;
        }

        [Benchmark]
        public long SerializeAndDeserializeNewtonsoft()
        {
            long total = 0;

            foreach (var item in _data)
            {
                total += NewtonsoftJson(item);
            }

            return total;
        }

        static int SystemTextJsonSourceGen(MyType m, JsonSerializerOptions opts = null)
        {
            var s = JsonSerializer.Serialize(m, typeof(MyType), SourceGenerationContext.Default);
            var r = JsonSerializer.Deserialize<MyType>(s, SourceGenerationContext.Default.MyType)!;
            return r.Age;
        }

        static int SystemTextJson(MyType m, JsonSerializerOptions opts = null)
        {
            var s = JsonSerializer.Serialize(m, opts);
            var r = JsonSerializer.Deserialize<MyType>(s, opts)!;
            return r.Age;
        }

        static int NewtonsoftJson(MyType m)
        {
            var s = JsonConvert.SerializeObject(m);
            var r = JsonConvert.DeserializeObject<MyType>(s)!;
            return r.Age;
        }
    }
}
