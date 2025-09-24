using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using BenchmarkDotNet.Attributes;

namespace Base64DeserializationRoundTrip
{
    [MemoryDiagnoser]
    public class Benchmarks
    {
        [Params(10, 100_000)]
        public int ListSize { get; set; }

        private string _base64StringSmallData = null!;
        private string _base64StringLargeData = null!;

        [GlobalSetup]
        public void GlobalSetup()
        {
            var random = new Random(42);

            // Create test objects with lists of the specified size
            var testObjectWithSmallList = new TestDataWithList
            {
                Id = 1,
                Name = "Test Object with Small List",
                Value = random.NextDouble(),
                IsActive = true,
                Timestamp = DateTime.UtcNow,
                Items = CreateItemList(10, random) // Small list
            };

            var testObjectWithLargeList = new TestDataWithList
            {
                Id = 2,
                Name = "Test Object with Large List",
                Value = random.NextDouble(),
                IsActive = false,
                Timestamp = DateTime.UtcNow,
                Items = CreateItemList(ListSize, random) // Variable size list
            };

            // Serialize and encode as base64
            var jsonSmall = JsonSerializer.Serialize(testObjectWithSmallList);
            var bytesSmall = Encoding.UTF8.GetBytes(jsonSmall);
            _base64StringSmallData = Convert.ToBase64String(bytesSmall);

            var jsonLarge = JsonSerializer.Serialize(testObjectWithLargeList);
            var bytesLarge = Encoding.UTF8.GetBytes(jsonLarge);
            _base64StringLargeData = Convert.ToBase64String(bytesLarge);
        }

        private List<DataItem> CreateItemList(int count, Random random)
        {
            var items = new List<DataItem>(count);
            for (int i = 0; i < count; i++)
            {
                items.Add(new DataItem
                {
                    ItemId = i,
                    Description = $"Item {i} - {Guid.NewGuid()}",
                    Score = random.NextDouble() * 100,
                    Tags = new[] { $"tag{i % 5}", $"category{i % 3}", $"type{i % 7}" },
                    CreatedAt = DateTime.UtcNow.AddMinutes(-random.Next(10000))
                });
            }
            return items;
        }

        [Benchmark]
        public TestDataWithList RoundTripThroughString_SmallData()
        {
            // Round-trip approach: base64 → bytes → string → deserialize (small data)
            var bytesUps = Convert.FromBase64String(_base64StringSmallData);
            var jsonStringUps = Encoding.UTF8.GetString(bytesUps);

            if (!string.IsNullOrEmpty(jsonStringUps))
            {
                return JsonSerializer.Deserialize<TestDataWithList>(jsonStringUps)!;
            }

            return new TestDataWithList();
        }

        [Benchmark]
        public TestDataWithList DirectFromBytes_SmallData()
        {
            // Direct approach: base64 → bytes → deserialize directly (small data)
            var bytesUps = Convert.FromBase64String(_base64StringSmallData);

            if (bytesUps.Length > 0)
            {
                return JsonSerializer.Deserialize<TestDataWithList>(bytesUps)!;
            }

            return new TestDataWithList();
        }

        [Benchmark]
        public TestDataWithList RoundTripThroughString_LargeData()
        {
            // Round-trip approach: base64 → bytes → string → deserialize (large data)
            var bytesUps = Convert.FromBase64String(_base64StringLargeData);
            var jsonStringUps = Encoding.UTF8.GetString(bytesUps);

            if (!string.IsNullOrEmpty(jsonStringUps))
            {
                return JsonSerializer.Deserialize<TestDataWithList>(jsonStringUps)!;
            }

            return new TestDataWithList();
        }

        [Benchmark(Baseline = true)]
        public TestDataWithList DirectFromBytes_LargeData()
        {
            // Direct approach: base64 → bytes → deserialize directly (large data)
            var bytesUps = Convert.FromBase64String(_base64StringLargeData);

            if (bytesUps.Length > 0)
            {
                return JsonSerializer.Deserialize<TestDataWithList>(bytesUps)!;
            }

            return new TestDataWithList();
        }
    }

    public class TestDataWithList
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Value { get; set; }
        public bool IsActive { get; set; }
        public DateTime Timestamp { get; set; }
        public List<DataItem> Items { get; set; } = new();
    }

    public class DataItem
    {
        public int ItemId { get; set; }
        public string Description { get; set; } = string.Empty;
        public double Score { get; set; }
        public string[] Tags { get; set; } = Array.Empty<string>();
        public DateTime CreatedAt { get; set; }
    }
}
