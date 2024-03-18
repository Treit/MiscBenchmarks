namespace Test
{
    using BenchmarkDotNet.Attributes;

    [MemoryRandomization]
    public class Benchmark
    {
        private List<string>? _strings;
        private readonly string needleA = "find_me";
        private readonly string needleB = "hiding_from_you";

        [Params(100_000)]
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            _strings = new List<string>(Count);
            for (int i = 0; i < Count / 2; i++)
            {
                _strings.Add("aaa");
                _strings.Add("bbb");
            }
        }

        [Benchmark(Baseline = true)]
        public (int, int) ElseIf()
        {
            var foundA = 0;
            var foundB = 0;
            var strings = _strings!;

            foreach (var str in strings)
            {
                if (str == "aaa")
                {
                    foundA++;
                }
                else if (str == "bbb")
                {
                    foundB++;
                }
            }

            return (foundA, foundB);
        }

        [Benchmark]
        public (int, int) TwoIfs()
        {
            var foundA = 0;
            var foundB = 0;
            var strings = _strings!;

            foreach (var str in strings)
            {
                if (str == "aaa")
                {
                    foundA++;
                }
                
                if (str == "bbb")
                {
                    foundB++;
                }
            }

            return (foundA, foundB);
        }

        [Benchmark]
        public (int, int) Continue()
        {
            var foundA = 0;
            var foundB = 0;
            var strings = _strings!;

            foreach (var str in strings)
            {
                if (str == "aaa")
                {
                    foundA++;
                    continue;
                }
                
                if (str == "bbb")
                {
                    foundB++;
                    continue;
                }
            }

            return (foundA, foundB);
        }

        [Benchmark]
        public (int, int) Switch()
        {
            var foundA = 0;
            var foundB = 0;
            var strings = _strings!;

            foreach (var str in strings)
            {
                switch (str)
                {
                    case "aaa":
                        foundA++;
                        break;
                    case "bbb":
                        foundB++;
                        break;
                    default:
                        break;
                }
            }

            return (foundA, foundB);
        }
    }
}
