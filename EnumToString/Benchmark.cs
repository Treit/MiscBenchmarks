namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;

    public enum SomeEnum
    {
        SomeValueA,
        SomeValueB,
        SomeValueC,
        SomeValueD,
        SomeNewValue
    }

    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(10_000)]
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
        }

        [Benchmark(Baseline = true)]
        public int EnumToString()
        {
            int result = 0;

            for (var i = 0; i < Count; i++)
            {
                var a = SomeEnum.SomeValueA.ToString();
                var b = SomeEnum.SomeValueB.ToString();
                var c = SomeEnum.SomeValueC.ToString();
                var d = SomeEnum.SomeValueD.ToString();
                var e = SomeEnum.SomeNewValue.ToString();

                result += a.Length + b.Length + c.Length + d.Length + e.Length;
            }

            return result;
        }

        [Benchmark]
        public int CustomGetStringUsingSwitch()
        {
            int result = 0;

            for (var i = 0; i < Count; i++)
            {
                var a = GetEnumString(SomeEnum.SomeValueA);
                var b = GetEnumString(SomeEnum.SomeValueB);
                var c = GetEnumString(SomeEnum.SomeValueC);
                var d = GetEnumString(SomeEnum.SomeValueD);
                var e = GetEnumString(SomeEnum.SomeNewValue);

                result += a.Length + b.Length + c.Length + d.Length + e.Length;
            }

            return result;
        }

        static string GetEnumString(SomeEnum e)
        {
            return e switch
            {
                SomeEnum.SomeValueA => "SomeValueA",
                SomeEnum.SomeValueB => "SomeValueB",
                SomeEnum.SomeValueC => "SomeValueC",
                SomeEnum.SomeValueD => "SomeValueD",
                _ => e.ToString()
            };
        }

    }
}
