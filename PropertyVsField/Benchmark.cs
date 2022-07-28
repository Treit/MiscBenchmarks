namespace Test
{
    using BenchmarkDotNet.Attributes;
    using System;

    [DisassemblyDiagnoser]
    public class Benchmark
    {
        TestClass _instance;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _instance = new TestClass
            {
                _string = Guid.NewGuid().ToString(),
                _time = DateTime.UtcNow
            };
        }

        [Benchmark(Baseline = true)]
        public (DateTime, string) GetProperty()
        {
            return (_instance.Time, _instance.String);
        }

        [Benchmark]
        public (DateTime, string) GetField()
        {
            return (_instance._time, _instance._string);
        }

        [Benchmark]
        public void SetProperty()
        {
            _instance.Time = DateTime.UtcNow;
            _instance.String = "SomeString";
        }

        [Benchmark]
        public void SetField()
        {
            _instance._time = DateTime.UtcNow;
            _instance._string = "SomeString";
        }
    }

    class TestClass
    {
        public DateTime _time;

        public string _string;

        public DateTime Time
        {
            get { return _time; }
            set { _time = value; }
        }

        public string String
        {
            get { return _string; }
            set { _string = value; }
        }
    }
}


