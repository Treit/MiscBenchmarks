namespace Test
{
    using BenchmarkDotNet.Attributes;
    using System;

    public class TestClass
    {
        public byte Data { get; }

        public TestClass(byte data)
        {
            Data = data;
        }
    }

    [DisassemblyDiagnoser(printSource: true)]
    public class Benchmark
    {
        [Params(1, 100_000)]
        public int Count;

        TestClass _instance;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _instance = new TestClass(0xDE);
        }

        [Benchmark]
        public long PropertyAccess()
        {
            long result = 0;

            for (int i = 0; i < Count; i++)
            {
                result += _instance.Data;
            }

            return result;
        }

        [Benchmark(Baseline = true)]
        public long LocalVariableAccess()
        {
            long result = 0;
            var data = _instance.Data;

            for (int i = 0; i < Count; i++)
            {
                result += data;
            }

            return result;
        }
    }
}

