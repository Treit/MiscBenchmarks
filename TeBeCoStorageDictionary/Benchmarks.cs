using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;
using BenchmarkDotNet.Attributes;

namespace StorageDictionary;

[MemoryDiagnoser]
public class Benchmark
{
    private Person[] _entities = Array.Empty<Person>();

    [Params(1, 512)]
    public int EntityCount { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        var random = new Random(42);
        _entities = new Person[EntityCount];
        for (int i = 0; i < EntityCount; i++)
        {
            _entities[i] = new Person
            {
                Id = Guid.NewGuid(),
                Name = $"Name-{i}",
                SocialSecurityNumber = $"{random.NextInt64():D11}",
                PreferredLetter = (Letter)(i % 3),
            };
        }
    }

    [Benchmark(Baseline = true)]
    public int NewImplementationTypeOf() => RunBenchmark(NewStorageExtensions.ToStorageDictionaryTypeOf);

    [Benchmark]
    public int OldImplementationTypeOf() => RunBenchmark(OldStorageExtension.ToStorageDictionaryTypeOf);

    [Benchmark]
    public int NewImplementationGetType() => RunBenchmark(NewStorageExtensions.ToStorageDictionaryGetType);

    [Benchmark]
    public int OldImplementationGetType() => RunBenchmark(OldStorageExtension.ToStorageDictionaryGetType);

    private int RunBenchmark(Func<Person, Dictionary<string, string>> projection)
    {
        int total = 0;
        foreach (var entity in _entities)
        {
            total += projection(entity).Count;
        }

        return total;
    }
}

public static class NewStorageExtensions
{
    public static Dictionary<string, string> ToStorageDictionaryTypeOf<T>(T entity)
        where T : notnull
    {
        return BuildDictionary(entity, typeof(T));
    }

    public static Dictionary<string, string> ToStorageDictionaryGetType<T>(T entity)
        where T : notnull
    {
        return BuildDictionary(entity, entity.GetType());
    }

    private static Dictionary<string, string> BuildDictionary<T>(T entity, Type entityType)
        where T : notnull
    {
        var dictionary = new Dictionary<string, string>(StringComparer.Ordinal);

        PropertyInfo? partitionKeyProperty = ReflectionUtilities.GetSingleProperty(entityType, typeof(PrimaryKeyAttribute));
        PropertyInfo? rowKeyProperty = ReflectionUtilities.GetSingleProperty(entityType, typeof(SecondaryKeyAttribute));

        if (partitionKeyProperty is null)
        {
            throw new ArgumentNullException(nameof(partitionKeyProperty), $"Entity of type {entityType.FullName} is missing {nameof(PrimaryKeyAttribute)}.");
        }

        if (rowKeyProperty is null)
        {
            throw new ArgumentNullException(nameof(rowKeyProperty), $"Entity of type {entityType.FullName} is missing {nameof(SecondaryKeyAttribute)}.");
        }

        var storageProperties = new List<PropertyInfo> { partitionKeyProperty, rowKeyProperty };
        storageProperties.AddRange(ReflectionUtilities.GetProperties(entityType, typeof(StorageAttribute)));
        storageProperties.AddRange(ReflectionUtilities.GetProperties(entityType, typeof(SecretStorageAttribute)));

        foreach (var property in storageProperties)
        {
            var propertyValue = property.GetValue(entity);
            if (propertyValue is not null)
            {
                dictionary.Add(property.Name, propertyValue.ToString()!);
            }
        }

        return dictionary;
    }
}

public static class OldStorageExtension
{
    private static readonly ConcurrentDictionary<Type, PropertyInfo[]> s_properties = new();

    public static Dictionary<string, string> ToStorageDictionaryTypeOf<T>(T entity)
        where T : notnull
    {
        return BuildDictionary(entity, typeof(T));
    }

    public static Dictionary<string, string> ToStorageDictionaryGetType<T>(T entity)
        where T : notnull
    {
        return BuildDictionary(entity, entity.GetType());
    }

    private static Dictionary<string, string> BuildDictionary<T>(T entity, Type entityType)
        where T : notnull
    {
        var dictionary = new Dictionary<string, string>(StringComparer.Ordinal);
        var storageProperties = s_properties.GetOrAdd(entityType, static type => BuildPropertyList(type));

        foreach (var property in storageProperties)
        {
            var propertyValue = property.GetValue(entity);
            if (propertyValue is not null)
            {
                dictionary.Add(property.Name, propertyValue.ToString()!);
            }
        }

        return dictionary;
    }

    private static PropertyInfo[] BuildPropertyList(Type entityType)
    {
        var properties = new List<PropertyInfo>
        {
            ReflectionUtilities.GetSingleProperty(entityType, typeof(PrimaryKeyAttribute))
                ?? throw new ArgumentNullException(nameof(PrimaryKeyAttribute), $"Entity of type {entityType.FullName} is missing {nameof(PrimaryKeyAttribute)}."),
            ReflectionUtilities.GetSingleProperty(entityType, typeof(SecondaryKeyAttribute))
                ?? throw new ArgumentNullException(nameof(SecondaryKeyAttribute), $"Entity of type {entityType.FullName} is missing {nameof(SecondaryKeyAttribute)}."),
        };

        properties.AddRange(ReflectionUtilities.GetProperties(entityType, typeof(StorageAttribute)));
        properties.AddRange(ReflectionUtilities.GetProperties(entityType, typeof(SecretStorageAttribute)));

        return properties.ToArray();
    }
}

public static class ReflectionUtilities
{
    private static readonly BindingFlags InstanceBindings = BindingFlags.Instance | BindingFlags.Public;

    public static PropertyInfo? GetSingleProperty(Type entityType, Type attributeType)
    {
        foreach (var property in entityType.GetProperties(InstanceBindings))
        {
            if (Attribute.IsDefined(property, attributeType))
            {
                return property;
            }
        }

        return null;
    }

    public static IEnumerable<PropertyInfo> GetProperties(Type entityType, Type attributeType)
    {
        foreach (var property in entityType.GetProperties(InstanceBindings))
        {
            if (Attribute.IsDefined(property, attributeType))
            {
                yield return property;
            }
        }
    }
}

[AttributeUsage(AttributeTargets.Property)]
public sealed class PrimaryKeyAttribute : Attribute
{
}

[AttributeUsage(AttributeTargets.Property)]
public sealed class SecondaryKeyAttribute : Attribute
{
}

[AttributeUsage(AttributeTargets.Property)]
public sealed class StorageAttribute : Attribute
{
}

[AttributeUsage(AttributeTargets.Property)]
public sealed class SecretStorageAttribute : Attribute
{
}

public sealed class Person
{
    [SecondaryKey]
    public Guid Id { get; set; }

    [Storage]
    public string Name { get; set; } = string.Empty;

    [SecretStorage]
    public string? SocialSecurityNumber { get; set; }

    [PrimaryKey]
    public Letter PreferredLetter { get; set; }
}

public enum Letter
{
    A,
    B,
    C,
}
