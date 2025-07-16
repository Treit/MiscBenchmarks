namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Order;
using System;
using System.Collections.Generic;

public struct TestStruct
{
    public double A { get; set; }
    public double B { get; set; }
    public double C { get; set; }
    public double D { get; set; }
    public double E { get; set; }
    public double F { get; set; }
    public double G { get; set; }
    public double H { get; set; }
    public double I { get; set; }
    public double J { get; set; }
    public double K { get; set; }
    public double L { get; set; }
    public double M { get; set; }
    public double N { get; set; }
    public double O { get; set; }
    public double P { get; set; }
    public double Q { get; set; }
}

public class TestClass
{
    public double A { get; set; }
    public double B { get; set; }
    public double C { get; set; }
    public double D { get; set; }
    public double E { get; set; }
    public double F { get; set; }
    public double G { get; set; }
    public double H { get; set; }
    public double I { get; set; }
    public double J { get; set; }
    public double K { get; set; }
    public double L { get; set; }
    public double M { get; set; }
    public double N { get; set; }
    public double O { get; set; }
    public double P { get; set; }
    public double Q { get; set; }
}

public struct TinyStruct
{
    public double A { get; set; }
    public double B { get; set; }
}

public class TinyClass
{
    public double A { get; set; }
    public double B { get; set; }
}

public class MediumClass
{
    public double A { get; set; }
    public double B { get; set; }
    public double C { get; set; }
    public double D { get; set; }
}

public class MediumStruct
{
    public double A { get; set; }
    public double B { get; set; }
    public double C { get; set; }
    public double D { get; set; }
}

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class Benchmark
{
    List<TestClass> _classes;
    List<TestStruct> _structs;
    List<TinyStruct> _tinyStructs;
    List<TinyClass> _tinyClasses;
    List<MediumStruct> _mediumStructs;
    List<MediumClass> _mediumClasses;

    [Params(10_000)]
    public int Count { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        _classes = new List<TestClass>(Count);
        _structs = new List<TestStruct>(Count);
        _tinyStructs = new List<TinyStruct>(Count);
        _tinyClasses = new List<TinyClass>(Count);
        _mediumClasses = new List<MediumClass>(Count);
        _mediumStructs = new List<MediumStruct>(Count);

        for (int i = 0; i < Count; i++)
        {
            _classes.Add(new TestClass());
            _structs.Add(new TestStruct());
            _tinyStructs.Add(new TinyStruct());
            _tinyClasses.Add(new TinyClass());
            _mediumStructs.Add(new MediumStruct());
            _mediumClasses.Add(new MediumClass());
        }
    }

    [Benchmark(Baseline = true)]
    public double Pass128ByteClass()
    {
        double total = 0f;

        for (int i = 0; i < Count; i++)
        {
            total += ReceiveClass(_classes[i]);
        }

        return total;
    }

    [Benchmark]
    public double Pass128ByteStruct()
    {
        double total = 0f;

        for (int i = 0; i < Count; i++)
        {
            total += ReceiveStruct(_structs[i]);
        }

        return total;
    }

    [Benchmark]
    public double Pass128ByteStructByRef()
    {
        double total = 0f;

        for (int i = 0; i < Count; i++)
        {
            var s = _structs[i];
            total += ReceiveStructByRef(ref s);
        }

        return total;
    }

    [Benchmark]
    public double Pass16ByteStruct()
    {
        double total = 0f;

        for (int i = 0; i < Count; i++)
        {
            total += ReceiveTinyStruct(_tinyStructs[i]);
        }

        return total;
    }

    [Benchmark]
    public double Pass16ByteClass()
    {
        double total = 0f;

        for (int i = 0; i < Count; i++)
        {
            total += ReceiveTinyClass(_tinyClasses[i]);
        }

        return total;
    }

    [Benchmark]
    public double Pass16ByteStructByRef()
    {
        double total = 0f;

        for (int i = 0; i < Count; i++)
        {
            var s = _tinyStructs[i];
            total += ReceiveTinyStructByRef(ref s);
        }

        return total;
    }

    [Benchmark]
    public double Pass32ByteStruct()
    {
        double total = 0f;

        for (int i = 0; i < Count; i++)
        {
            total += ReceiveMediumStruct(_mediumStructs[i]);
        }

        return total;
    }

    [Benchmark]
    public double Pass32ByteClass()
    {
        double total = 0f;

        for (int i = 0; i < Count; i++)
        {
            total += ReceiveMediumClass(_mediumClasses[i]);
        }

        return total;
    }

    [Benchmark]
    public double Pass32ByteStructByRef()
    {
        double total = 0f;

        for (int i = 0; i < Count; i++)
        {
            var s = _mediumStructs[i];
            total += ReceiveMediumStructByRef(ref s);
        }

        return total;
    }

    public double ReceiveStruct(TestStruct s)
    {
        return s.F + s.P;
    }

    public double ReceiveTinyStruct(TinyStruct s)
    {
        return s.A + s.B;
    }

    public double ReceiveClass(TestClass c)
    {
        return c.F + c.P;
    }

    public double ReceiveTinyClass(TinyClass c)
    {
        return c.A + c.B;
    }

    public double ReceiveStructByRef(ref TestStruct s)
    {
        return s.F + s.P;
    }

    public double ReceiveTinyStructByRef(ref TinyStruct s)
    {
        return s.A + s.B;
    }

    public double ReceiveMediumStruct(MediumStruct c)
    {
        return c.A + c.B;
    }

    public double ReceiveMediumStructByRef(ref MediumStruct s)
    {
        return s.A + s.B;
    }

    public double ReceiveMediumClass(MediumClass c)
    {
        return c.A + c.B;
    }
}
