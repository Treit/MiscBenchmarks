using BenchmarkDotNet.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Test
{
    record MyType(string Name, int Age);

    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(10, 1000)]
        public int Count { get; set; }

        private List<MyType> _data = new();

        [GlobalSetup]
        public void GlobalSetup()
        {
            for (int i = 0; i < Count; i++)
            {
                _data.Add(new MyType($"SomeName{i}", i));
            }
        }

        [Benchmark]
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
        public long SerializeAndDeserializeNewtonsoft()
        {
            long total = 0;

            foreach (var item in _data)
            {
                total += NewtonsoftJson(item);
            }

            return total;
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
