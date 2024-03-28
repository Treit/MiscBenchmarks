namespace Test
{
    using BenchmarkDotNet.Attributes;
    using System;

    public interface IContainer
    {
        object Data { get; set; }
    }
    public interface IContainer<T> : IContainer
    {
        object IContainer.Data { get => Data; set => Data = (T)value; }
        new T Data { get; set; }
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
        Container<Payload> _container;
        dynamic _containerDynamic;
        Type _containerType;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _container = new Container<Payload>();
            _containerDynamic = new Container<Payload>();
            _containerType = _container.GetType();
        }

        [Benchmark(Baseline = true)]
        public Container<Payload> SetPropertyNormally()
        {
            _container.Data = new Payload { Message = "TEST" };
            return _container;
        }

        [Benchmark]
        public Container<Payload> SetPropertyUsingDynamic()
        {
            _containerDynamic.Data = new Payload { Message = "TEST" };
            return _containerDynamic;
        }

        [Benchmark]
        public Container<Payload> SetPropertyUsingReflection()
        {
            _containerType.GetProperty("Data").SetValue(_container, new Payload { Message = "TEST" });
            return _container;
        }

        [Benchmark]
        public Container<Payload> SetPropertyUsingNonGenericInterface()
        {
            IContainer inst = _container;
            inst.Data = new Payload { Message = "TEST" };
            return inst as Container<Payload>;
        }
    }
}
