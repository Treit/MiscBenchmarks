namespace CustomStringJoinVsBuiltIns
{
    using BenchmarkDotNet.Attributes;
    using System;

    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(10, 1000)]
        public int Count { get; set; }

        private string[] _stringsA;
        private string[] _stringsB;
        private char _joinChar;

        [GlobalSetup]
        public void GlobalSetup()
        {
            var rng = new Random(42);
            _joinChar = '/';
            _stringsA = new string[Count];
            _stringsB = new string[Count];

            for (int i = 0; i < Count; i++)
            {
                _stringsA[i] = new string('a', rng.Next(5, 50));
                _stringsB[i] = new string('b', rng.Next(5, 50));
            }
        }

        [Benchmark(Baseline = true)]
        public string CustomSpanJoin()
        {
            string result = null;
            for (int i = 0; i < Count; i++)
            {
                result = CustomJoin(_stringsA[i], _stringsB[i], _joinChar);
            }
            return result;
        }

        [Benchmark]
        public string CustomSpanJoinConstant()
        {
            string result = null;
            for (int i = 0; i < Count; i++)
            {
                result = CustomJoinConstant(_stringsA[i], _stringsB[i], _joinChar);
            }
            return result;
        }

        [Benchmark]
        public string StringConcat()
        {
            string result = null;
            for (int i = 0; i < Count; i++)
            {
                result = string.Concat(_stringsA[i], _joinChar.ToString(), _stringsB[i]);
            }
            return result;
        }

        [Benchmark]
        public string StringJoin()
        {
            string result = null;
            for (int i = 0; i < Count; i++)
            {
                result = string.Join(_joinChar, _stringsA[i], _stringsB[i]);
            }
            return result;
        }

        [Benchmark]
        public string StringInterpolation()
        {
            string result = null;
            for (int i = 0; i < Count; i++)
            {
                var a = _stringsA[i];
                var b = _stringsB[i];
                var c = _joinChar;
                result = $"{a}{c}{b}";
            }
            return result;
        }

        [Benchmark]
        public string StringCreate()
        {
            string result = null;
            for (int i = 0; i < Count; i++)
            {
                var a = _stringsA[i];
                var b = _stringsB[i];
                var c = _joinChar;
                result = string.Create(a.Length + b.Length + 1, (a, b, c), static (span, state) =>
                {
                    state.a.CopyTo(span);
                    span[state.a.Length] = state.c;
                    state.b.CopyTo(span[(state.a.Length + 1)..]);
                });
            }
            return result;
        }

        public static string CustomJoin(string a, string b, char join)
        {
            int total = a.Length + b.Length + 1;
            return total < 512
                ? JoinImpl(stackalloc char[total], a, b, join)
                : JoinImpl(new char[total], a, b, join);

            static string JoinImpl(Span<char> sink, string a, string b, char join)
            {
                a.CopyTo(sink.Slice(0, a.Length));
                b.CopyTo(sink.Slice(a.Length + 1));
                sink[a.Length] = join;
                return sink.ToString();
            }
        }

        public static string CustomJoinConstant(string a, string b, char join)
        {
            int total = a.Length + b.Length + 1;
            return total < 512
                ? JoinImpl(stackalloc char[512], total, a, b, join)
                : JoinImpl(new char[total], total, a, b, join);

            static string JoinImpl(Span<char> sink, int total, string a, string b, char join)
            {
                sink = sink[..total];
                a.CopyTo(sink.Slice(0, a.Length));
                b.CopyTo(sink.Slice(a.Length + 1));
                sink[a.Length] = join;
                return sink.ToString();
            }
        }
    }
}
