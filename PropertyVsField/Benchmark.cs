namespace Test
{
    using BenchmarkDotNet.Attributes;
    using System;

    [DisassemblyDiagnoser]
    public class Benchmark
    {
        public int Count;

        TestClass _instance;
        TestStruct _sinstance;

        [GlobalSetup]
        public void GlobalSetup()
        {
            Count = 1000;

            _instance = new TestClass
            {
                _string = Guid.NewGuid().ToString(),
                _time = DateTime.UtcNow
            };

            _sinstance = new TestStruct
            {
                _string = Guid.NewGuid().ToString(),
                _time = DateTime.UtcNow
            };
        }

        [Benchmark]
        public (DateTime, string) GetProperty()
        {
            (DateTime, string) result = default;

            for (int i = 0; i < Count; i++)
            {
                result = DoGetProperty();
            }

            return result;
        }

        [Benchmark]
        public (DateTime, string) GetField()
        {
            (DateTime, string) result = default;

            for (int i = 0; i < Count; i++)
            {
                result = DoGetField();
            }

            return result;
        }

        public (DateTime, string) DoGetProperty()
        {
            return (_instance.Time, _instance.String);
        }

        public (DateTime, string) DoGetField()
        {
            return (_instance._time, _instance._string);
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

    class TestStruct
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


