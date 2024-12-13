namespace Test
{
    using BenchmarkDotNet.Attributes;
    using System.Collections.Generic;

    [MemoryDiagnoser]
    public class Benchmark
    {
        private static char[] s_trimChars = new char[] { ' ', '\t', '\r', '\n', '/' };
        private List<string> _strings;

        [Params(100, 100_000)]
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            _strings = new List<string>(Count);
            for (int i = 0; i < Count; i++)
            {
                _strings.Add($"  ////   {i}                //     \r\n   ");
            }
        }

        [Benchmark]
        public string DoTrimWithOneCallUsingParamsArray()
        {
            var result = "";

            for (int i = 0; i < _strings.Count; i++)
            {
                var newStr = _strings[i].Trim(' ', '\t', '\r', '\n', '/');
                result = newStr;
            }

            return result;
        }

        [Benchmark]
        public string DoTrimWithOneCallUsingNewCharArray()
        {
            var result = "";

            for (int i = 0; i < _strings.Count; i++)
            {
                var newStr = _strings[i].Trim(new char[] { ' ', '\t', '\r', '\n', '/' });
                result = newStr;
            }

            return result;
        }

        [Benchmark(Baseline = true)]
        public string DoTrimWithOneCallUsingStaticCharArray()
        {
            var result = "";

            for (int i = 0; i < _strings.Count; i++)
            {
                var newStr = _strings[i].Trim(s_trimChars);
                result = newStr;
            }

            return result;
        }

        [Benchmark]
        public string DoTrimWithThreeTrimCallsAndNewCharArray()
        {
            var result = "";

            for (int i = 0; i < _strings.Count; i++)
            {
                var newStr = _strings[i].Trim().Trim(new char[] { '/' }).Trim();
                result = newStr;
            }

            return result;
        }
    }
}
