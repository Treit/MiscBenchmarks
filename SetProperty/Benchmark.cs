namespace Test
{
    using BenchmarkDotNet.Attributes;
    using System;

    public interface IContainer<T>
    {
        T Data { get; set; }
    }

    public class Container<T> : IContainer<T>
    {
        public T Data { get; set; }
    }

    public class Payload
    {
        public string Message { get; set; }
    }

    [MemoryDiagnoser]
    public class Benchmark
    {
        [GlobalSetup]
        public void GlobalSetup()
        {
        }

        [Benchmark]
        public IContainer<Payload> SetPropertyNormally()
        {
            var type = typeof(Container<Payload>);
            var inst = Activator.CreateInstance(type) as IContainer<Payload>;
            inst.Data = new Payload { Message = "TEST" };
            return inst;
        }

        [Benchmark]
        public IContainer<Payload> SetPropertyUsingDynamic()
        {
            var type = typeof(Container<Payload>);
            dynamic inst = Activator.CreateInstance(type);
            inst.Data = new Payload { Message = "TEST" };
            return inst;
        }

        [Benchmark]
        public IContainer<Payload> SetPropertyUsingReflection()
        {
            var type = typeof(Container<Payload>);
            var inst = Activator.CreateInstance(type);
            type.GetProperty("Data").SetValue(inst, new Payload { Message = "TEST" });
            return inst as IContainer<Payload>;
        }
    }
}
