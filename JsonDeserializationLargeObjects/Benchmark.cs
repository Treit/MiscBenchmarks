using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Test;
public class Address
{
    public string Street { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public Dictionary<string, string> MetaData { get; set; }
}

public class OrderItem
{
    public string ProductId { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public List<string> Tags { get; set; }
}

public class MyType
{
    public string CustomerId { get; set; }
    public string Name { get; set; }
    public DateTime LastActive { get; set; }
    public bool IsPremium { get; set; }
    public Address PrimaryAddress { get; set; }
    public List<Address> ShippingAddresses { get; set; }
    public Dictionary<string, OrderItem> RecentOrders { get; set; }
    public Dictionary<string, List<decimal>> PriceHistory { get; set; }
    public Dictionary<string, Dictionary<string, object>> DynamicProperties { get; set; }
}

[JsonSourceGenerationOptions(WriteIndented = false)]
[JsonSerializable(typeof(List<MyType>))]
[JsonSerializable(typeof(MyType))]
[JsonSerializable(typeof(Address))]
[JsonSerializable(typeof(OrderItem))]
[JsonSerializable(typeof(Dictionary<string, OrderItem>))]
[JsonSerializable(typeof(Dictionary<string, List<decimal>>))]
[JsonSerializable(typeof(Dictionary<string, Dictionary<string, object>>))]
[JsonSerializable(typeof(List<Address>))]
[JsonSerializable(typeof(Dictionary<string, string>))]
[JsonSerializable(typeof(List<string>))]
internal partial class SourceGenerationContext : JsonSerializerContext
{
}

[MemoryDiagnoser]
public class Benchmark
{
    private List<MyType> _data = new List<MyType>();

    [Params(100)]
    public int Count { get; set; }

    private JsonSerializerOptions _options;
    private string _json;

    [GlobalSetup]
    public void GlobalSetup()
    {
        var random = new Random(42);
        for (int i = 0; i < Count; i++)
        {
            var customer = new MyType
            {
                CustomerId = $"CUST{i:D5}",
                Name = $"Customer {i}",
                LastActive = DateTime.Now.AddDays(-random.Next(365)),
                IsPremium = random.Next(2) == 1,
                PrimaryAddress = GenerateAddress(random, i),
                ShippingAddresses = Enumerable.Range(0, random.Next(1, 4))
                    .Select(j => GenerateAddress(random, i + j))
                    .ToList(),
                RecentOrders = GenerateOrders(random, 3),
                PriceHistory = GeneratePriceHistory(random),
                DynamicProperties = new Dictionary<string, Dictionary<string, object>>
                {
                    ["preferences"] = new()
                    {
                        ["theme"] = random.Next(2) == 0 ? "light" : "dark",
                        ["notifications"] = true,
                        ["refreshInterval"] = random.Next(15, 60)
                    },
                    ["metrics"] = new()
                    {
                        ["totalSpent"] = random.Next(1000, 10000),
                        ["orderCount"] = random.Next(50),
                        ["rating"] = random.NextDouble() * 5
                    }
                }
            };
            _data.Add(customer);
        }

        static Address GenerateAddress(Random random, int seed)
        {
            return new Address
            {
                Street = $"{random.Next(1000)} Main St {seed}",
                City = $"City{random.Next(100)}",
                Country = $"Country{random.Next(10)}",
                MetaData = new Dictionary<string, string>
                {
                    ["type"] = random.Next(2) == 0 ? "home" : "work",
                    ["verified"] = random.Next(2) == 1 ? "true" : "false",
                    ["notes"] = $"Address note {seed}"
                }
            };
        }

        static Dictionary<string, OrderItem> GenerateOrders(Random random, int count)
        {
            return Enumerable.Range(0, count).ToDictionary(
                i => $"ORD{random.Next(10000):D5}",
                i => new OrderItem
                {
                    ProductId = $"PROD{random.Next(1000):D4}",
                    Price = (decimal)(random.NextDouble() * 1000),
                    Quantity = random.Next(1, 10),
                    Tags = Enumerable.Range(0, random.Next(1, 5))
                        .Select(j => $"tag{random.Next(20)}")
                        .ToList()
                });
        }

        static Dictionary<string, List<decimal>> GeneratePriceHistory(Random random)
        {
            return new Dictionary<string, List<decimal>>
            {
                ["daily"] = Enumerable.Range(0, 7)
                    .Select(_ => (decimal)(random.NextDouble() * 100))
                    .ToList(),
                ["weekly"] = Enumerable.Range(0, 4)
                    .Select(_ => (decimal)(random.NextDouble() * 500))
                    .ToList(),
                ["monthly"] = Enumerable.Range(0, 12)
                    .Select(_ => (decimal)(random.NextDouble() * 1000))
                    .ToList()
            };
        }
        _options = new JsonSerializerOptions { WriteIndented = false };
        _json = JsonSerializer.Serialize(_data, _options);
    }

    private string GetJson() => _json;

    [Benchmark]
    public List<MyType> DeserializeWithJsonDocument()
    {
        var json = GetJson();
        using var doc = JsonDocument.Parse(json);
        var result = new List<MyType>(Count);
        foreach (var element in doc.RootElement.EnumerateArray())
        {
            result.Add(new MyType
            {
                CustomerId = element.GetProperty("CustomerId").GetString(),
                Name = element.GetProperty("Name").GetString(),
                LastActive = element.GetProperty("LastActive").GetDateTime(),
                IsPremium = element.GetProperty("IsPremium").GetBoolean(),
                PrimaryAddress = DeserializeAddress(element.GetProperty("PrimaryAddress")),
                ShippingAddresses = element.GetProperty("ShippingAddresses")
                    .EnumerateArray()
                    .Select(addr => DeserializeAddress(addr))
                    .ToList(),
                RecentOrders = element.GetProperty("RecentOrders")
                    .EnumerateObject()
                    .ToDictionary(
                        p => p.Name,
                        p => DeserializeOrderItem(p.Value)),
                PriceHistory = element.GetProperty("PriceHistory")
                    .EnumerateObject()
                    .ToDictionary(
                        p => p.Name,
                        p => p.Value.EnumerateArray()
                            .Select(v => v.GetDecimal())
                            .ToList()),
                DynamicProperties = element.GetProperty("DynamicProperties")
                    .EnumerateObject()
                    .ToDictionary(
                        p => p.Name,
                        p => p.Value.EnumerateObject()
                            .ToDictionary(
                                inner => inner.Name,
                                inner => DeserializeObject(inner.Value)))
            });

            static Address DeserializeAddress(JsonElement element)
            {
                return new Address
                {
                    Street = element.GetProperty("Street").GetString(),
                    City = element.GetProperty("City").GetString(),
                    Country = element.GetProperty("Country").GetString(),
                    MetaData = element.GetProperty("MetaData")
                        .EnumerateObject()
                        .ToDictionary(
                            p => p.Name,
                            p => p.Value.GetString())
                };
            }

            static OrderItem DeserializeOrderItem(JsonElement element)
            {
                return new OrderItem
                {
                    ProductId = element.GetProperty("ProductId").GetString(),
                    Price = element.GetProperty("Price").GetDecimal(),
                    Quantity = element.GetProperty("Quantity").GetInt32(),
                    Tags = element.GetProperty("Tags")
                        .EnumerateArray()
                        .Select(t => t.GetString())
                        .ToList()
                };
            }

            static object DeserializeObject(JsonElement element)
            {
                return element.ValueKind switch
                {
                    JsonValueKind.String => element.GetString(),
                    JsonValueKind.Number => element.TryGetInt64(out var l) ? l : element.GetDouble(),
                    JsonValueKind.True => true,
                    JsonValueKind.False => false,
                    _ => null
                };
            }
        }
        return result;
    }

    [Benchmark]
    public List<MyType> DeserializeWithJsonNode()
    {
        var json = GetJson();
        var node = JsonNode.Parse(json);
        var result = new List<MyType>(Count);
        foreach (var item in node.AsArray())
        {
            result.Add(new MyType
            {
                CustomerId = item["CustomerId"].GetValue<string>(),
                Name = item["Name"].GetValue<string>(),
                LastActive = item["LastActive"].GetValue<DateTime>(),
                IsPremium = item["IsPremium"].GetValue<bool>(),
                PrimaryAddress = DeserializeAddressNode(item["PrimaryAddress"]),
                ShippingAddresses = item["ShippingAddresses"].AsArray()
                    .Select(addr => DeserializeAddressNode(addr))
                    .ToList(),
                RecentOrders = item["RecentOrders"].AsObject()
                    .ToDictionary(
                        p => p.Key,
                        p => DeserializeOrderItemNode(p.Value)),
                PriceHistory = item["PriceHistory"].AsObject()
                    .ToDictionary(
                        p => p.Key,
                        p => p.Value.AsArray()
                            .Select(v => v.GetValue<decimal>())
                            .ToList()),
                DynamicProperties = item["DynamicProperties"].AsObject()
                    .ToDictionary(
                        p => p.Key,
                        p => p.Value.AsObject()
                            .ToDictionary(
                                inner => inner.Key,
                                inner => DeserializeObjectNode(inner.Value)))
            });

            static Address DeserializeAddressNode(JsonNode node)
            {
                return new Address
                {
                    Street = node["Street"].GetValue<string>(),
                    City = node["City"].GetValue<string>(),
                    Country = node["Country"].GetValue<string>(),
                    MetaData = node["MetaData"].AsObject()
                        .ToDictionary(
                            p => p.Key,
                            p => p.Value.GetValue<string>())
                };
            }

            static OrderItem DeserializeOrderItemNode(JsonNode node)
            {
                return new OrderItem
                {
                    ProductId = node["ProductId"].GetValue<string>(),
                    Price = node["Price"].GetValue<decimal>(),
                    Quantity = node["Quantity"].GetValue<int>(),
                    Tags = node["Tags"].AsArray()
                        .Select(t => t.GetValue<string>())
                        .ToList()
                };
            }

            static object DeserializeObjectNode(JsonNode node)
            {
                var value = node.AsValue();
                if (value == null) return null;

                return value.TryGetValue<string>(out var s) ? s :
                       value.TryGetValue<long>(out var l) ? l :
                       value.TryGetValue<double>(out var d) ? d :
                       value.GetValue<bool>();
            }
        }
        return result;
    }

    [Benchmark]
    public List<MyType> DeserializeWithJsonSerializer()
    {
        var json = GetJson();
        return JsonSerializer.Deserialize<List<MyType>>(json, _options);
    }

    [Benchmark]
    public List<MyType> DeserializeWithSourceGen()
    {
        var json = GetJson();
        return JsonSerializer.Deserialize(json, SourceGenerationContext.Default.ListMyType);
    }
}
