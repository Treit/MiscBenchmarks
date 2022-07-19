namespace Test
{
    using BenchmarkDotNet.Attributes;
    using System.Collections.Generic;
    using System.Linq;

    [DisassemblyDiagnoser]
    public class Benchmark
    {
        private string[] _strings;
        private string[] _longstrings;
        const string needle = "find_me";

        [Params(1000)]
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            _strings = new string[Count];
            _longstrings = new string[Count];

            for (int i = 0; i < Count; i++)
            {
                _strings[i] = i.ToString();
                _longstrings[i] = i.ToString() + "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            }

            _strings[_strings.Length - 1] = $"1234-abc-xyz{needle}zzz";
            _longstrings[_longstrings.Length - 1] = $"1234-abc-xyz{needle}zzz";
        }

        [Benchmark(Baseline = true)]
        public int Ordinal()
        {
            var strings = _strings;

            for (int i = 0; i < strings.Length; i++)
            {
                if (strings[i].Contains(needle, System.StringComparison.Ordinal))
                {
                    return i;
                }
            }

            return -1;
        }

        [Benchmark]
        public int OrdinalIgnoreCase()
        {
            var strings = _strings;

            for (int i = 0; i < strings.Length; i++)
            {
                if (strings[i].Contains(needle, System.StringComparison.OrdinalIgnoreCase))
                {
                    return i;
                }
            }

            return -1;
        }

        [Benchmark]
        public int OrdinalLongStrings()
        {
            var strings = _longstrings;

            for (int i = 0; i < strings.Length; i++)
            {
                if (strings[i].Contains(needle, System.StringComparison.Ordinal))
                {
                    return i;
                }
            }

            return -1;
        }

        [Benchmark]
        public int OrdinalIgnoreCaseLongStrings()
        {
            var strings = _longstrings;

            for (int i = 0; i < strings.Length; i++)
            {
                if (strings[i].Contains(needle, System.StringComparison.OrdinalIgnoreCase))
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
