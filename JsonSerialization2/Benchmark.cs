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
        private List<string> _serializedData = new();

        private JsonSerializerOptions _options;

        [GlobalSetup]
        public void GlobalSetup()
        {
            for (int i = 0; i < Count; i++)
            {
                var t = new MyType($"SomeName{i}", i);
                _data.Add(t);
                var s = JsonSerializer.Serialize(t, _options);
                _serializedData.Add(s);
                _options = new JsonSerializerOptions { WriteIndented = false };
            }
        }

        [Benchmark(Baseline = true)]
        public long SerializeSTJ()
        {
            long total = 0;

            foreach (var item in _data)
            {
                total += SerializeSystemTextJson(item);
            }

            return total;
        }

        [Benchmark]
        public long SerializeNewtonsoft()
        {
            long total = 0;

            foreach (var item in _data)
            {
                total += SerializeNewtonsoftJson(item);
            }

            return total;
        }

        [Benchmark]
        public long DeserializeSTJ()
        {
            long total = 0;

            foreach (var item in _serializedData)
            {
                total += DeserializeSystemTextJson(item);
            }

            return total;
        }

        [Benchmark]
        public long DeserializeNewtonsoft()
        {
            long total = 0;

            foreach (var item in _serializedData)
            {
                total += DeserializeNewtonsoftJson(item);
            }

            return total;
        }

        static int SerializeSystemTextJson(MyType m, JsonSerializerOptions opts = null)
        {
            var s = JsonSerializer.Serialize(m, opts);
            return s.Length;
        }

        static int DeserializeSystemTextJson(string s, JsonSerializerOptions opts = null)
        {
            var m = JsonSerializer.Deserialize<MyType>(s, opts);
            return m.Age;
        }

        static int SerializeNewtonsoftJson(MyType m)
        {
            var s = JsonConvert.SerializeObject(m);
            return s.Length;
        }

        static int DeserializeNewtonsoftJson(string s)
        {
            var m = JsonConvert.DeserializeObject<MyType>(s)!;
            return m.Age;
        }
    }
}
