using System;
using System.Text;
using System.Text.Json;
using BenchmarkDotNet.Attributes;

namespace Base64DeserializationRoundTrip
{
    [MemoryDiagnoser]
    public class Benchmarks
    {
        [Params(10, 100_000)]
        public int Count { get; set; }

        private string[] _base64Strings = null!;

        [GlobalSetup]
        public void GlobalSetup()
        {
            // Create test data: JSON objects encoded as base64
            _base64Strings = new string[Count];
            var random = new Random(42);

            for (int i = 0; i < Count; i++)
            {
                var testObject = new TestData
                {
                    Id = i,
                    Name = $"Test Item {i}",
                    Value = random.NextDouble(),
                    IsActive = i % 2 == 0,
                    Timestamp = DateTime.UtcNow.AddDays(-random.Next(365))
                };

                var json = JsonSerializer.Serialize(testObject);
                var bytes = Encoding.UTF8.GetBytes(json);
                _base64Strings[i] = Convert.ToBase64String(bytes);
            }
        }

        [Benchmark]
        public TestData[] RoundTripThroughString()
        {
            var results = new TestData[Count];

            for (int i = 0; i < Count; i++)
            {
                // Round-trip approach: base64 → bytes → string → deserialize
                var bytesUps = Convert.FromBase64String(_base64Strings[i]);
                var jsonStringUps = Encoding.UTF8.GetString(bytesUps);

                if (!string.IsNullOrEmpty(jsonStringUps))
                {
                    results[i] = JsonSerializer.Deserialize<TestData>(jsonStringUps)!;
                }
            }

            return results;
        }

        [Benchmark(Baseline = true)]
        public TestData[] DirectFromBytes()
        {
            var results = new TestData[Count];

            for (int i = 0; i < Count; i++)
            {
                // Direct approach: base64 → bytes → deserialize directly
                var bytesUps = Convert.FromBase64String(_base64Strings[i]);

                if (bytesUps.Length > 0)
                {
                    results[i] = JsonSerializer.Deserialize<TestData>(bytesUps)!;
                }
            }

            return results;
        }
    }

    public class TestData
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Value { get; set; }
        public bool IsActive { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
