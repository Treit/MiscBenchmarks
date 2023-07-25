namespace Test
{
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

    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    public class Benchmark
    {
        List<TestClass> _classes;
        List<TestStruct> _structs;

        [Params(10_000)]
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            _classes = new List<TestClass>(Count);
            _structs = new List<TestStruct>(Count);

            for (int i = 0; i < Count; i++)
            {
                _classes.Add(new TestClass());
                _structs.Add(new TestStruct());
            }
        }

        [Benchmark(Baseline = true)]
        public double PassClass()
        {
            double total = 0f;

            for (int i = 0; i < Count; i++)
            {
                total += ReceiveClass(_classes[i]);
            }

            return total;
        }

        [Benchmark]
        public double PassStruct()
        {
            double total = 0f;

            for (int i = 0; i < Count; i++)
            {
                total += ReceiveStruct(_structs[i]);
            }

            return total;
        }

        [Benchmark]
        public double PassStructByRef()
        {
            double total = 0f;

            for (int i = 0; i < Count; i++)
            {
                var s = _structs[i];
                total += ReceiveStructByRef(ref s);
            }

            return total;
        }

        public double ReceiveStruct(TestStruct s)
        {
            return s.F + s.P;
        }

        public double ReceiveClass(TestClass c)
        {
            return c.F + c.P;
        }

        public double ReceiveStructByRef(ref TestStruct s)
        {
            return s.F + s.P;
        }
    }
}
