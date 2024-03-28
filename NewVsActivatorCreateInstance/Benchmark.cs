namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using System;
    using System.Collections.Generic;

    public class SomeClass
    {
        public SomeClass()
        {
        }

        public SomeClass(string name, int count)
        {
            Name = name;
            Count = count;
        }

        public string Name { get; set; }
        public int Count { get; set; }
    }

    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(1000)]
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
        }

        [Benchmark]
        public List<SomeClass> CreateUsingNew()
        {
            var result = new List<SomeClass>();

            for (int i = 0; i < Count; i++)
            {
                var instance = GetInstance<SomeClass>();
                instance.Count = i;
                instance.Name = $"Something {i}";
                result.Add(instance);
            }

            return result;
        }

        [Benchmark]
        public List<SomeClass> CreateUsingActivatorCreateInstance()
        {
            var result = new List<SomeClass>();

            for (int i = 0; i < Count; i++)
            {
                var instance = GetInstanceViaActivator<SomeClass>();
                instance.Count = i;
                instance.Name = $"Something {i}";
                result.Add(instance);
            }

            return result;
        }

        private T GetInstance<T>() where T : new()
        {
            return new T();
        }

        private T GetInstanceViaActivator<T>() where T : new()
        {
            return Activator.CreateInstance<T>();
        }
    }
}
