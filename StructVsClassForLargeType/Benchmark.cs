﻿﻿﻿﻿namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using System;
using System.Collections.Generic;

[MemoryDiagnoser]
public class Benchmark
{
    private LargeTypeStruct[] _structs;
    private LargeTypeClass[] _classes;

    [Params(100_000)]
    public int Count { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        var rand = new Random(42);
        _structs = new LargeTypeStruct[Count];
        _classes = new LargeTypeClass[Count];

        for (int i = 0; i < Count; i++)
        {
            var value = new LargeTypeStruct
            {
                Field1 = (decimal)rand.NextDouble() * 1000,
                Field2 = (decimal)rand.NextDouble() * 1000,
                Field3 = (decimal)rand.NextDouble() * 1000,
                Field4 = (decimal)rand.NextDouble() * 1000,
                Field5 = rand.Next(),
                Field6 = rand.Next(),
                Field7 = rand.Next()
            };

            _structs[i] = value;
            _classes[i] = new LargeTypeClass
            {
                Field1 = value.Field1,
                Field2 = value.Field2,
                Field3 = value.Field3,
                Field4 = value.Field4,
                Field5 = value.Field5,
                Field6 = value.Field6,
                Field7 = value.Field7
            };
        }
    }

    private decimal AddFieldsStruct(LargeTypeStruct value, decimal currentSum)
    {
        return currentSum + value.Field1 + value.Field2 + value.Field3 + value.Field4;
    }

    private decimal AddFieldsClass(LargeTypeClass value, decimal currentSum)
    {
        return currentSum + value.Field1 + value.Field2 + value.Field3 + value.Field4;
    }

    [Benchmark]
    public decimal SumStructFields()
    {
        decimal sum = 0;
        for (int i = 0; i < _structs.Length; i++)
        {
            sum = AddFieldsStruct(_structs[i], sum); // Struct will be copied
        }
        return sum;
    }

    [Benchmark]
    public decimal SumClassFields()
    {
        decimal sum = 0;
        for (int i = 0; i < _classes.Length; i++)
        {
            sum = AddFieldsClass(_classes[i], sum); // Only reference is passed
        }
        return sum;
    }

    [Benchmark]
    public List<object> BoxStructs()
    {
        var list = new List<object>(Count);
        for (int i = 0; i < _structs.Length; i++)
        {
            list.Add(_structs[i]); // Forces boxing of struct
        }
        return list;
    }

    [Benchmark]
    public List<object> StoreClasses()
    {
        var list = new List<object>(Count);
        for (int i = 0; i < _classes.Length; i++)
        {
            list.Add(_classes[i]); // No boxing needed
        }
        return list;
    }
}

// ~80 bytes: 4 decimal fields (64 bytes) + 3 int fields (12 bytes) + padding = 80 bytes
public struct LargeTypeStruct
{
    public decimal Field1;
    public decimal Field2;
    public decimal Field3;
    public decimal Field4;
    public int Field5;
    public int Field6;
    public int Field7;
}

public class LargeTypeClass
{
    public decimal Field1;
    public decimal Field2;
    public decimal Field3;
    public decimal Field4;
    public int Field5;
    public int Field6;
    public int Field7;
}
