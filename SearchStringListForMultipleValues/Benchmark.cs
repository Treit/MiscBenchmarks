namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using System;
    using System.Collections.Generic;

    [ShortRunJob]
    [MemoryDiagnoser]
    public class Benchmark
    {
        private string _firstPriority = "ABC";
        private string _secondPriority = "DEF";
        private string _thirdPriority = "GHI";
        private List<string>? _strings;

        [Params(5, 50, 50_000)]
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            Random r = new Random();

            _strings = new List<string>(Count);

            for (int i = 0; i < Count; i++)
            {
                _strings.Add(i.ToString());
            }

            _strings.Add(_secondPriority);
            _strings.Add(_thirdPriority);
        }

        [Benchmark(Baseline = true)]
        public string CheckWithForEachSinglePass()
        {
            var firstFound = false;
            var secondFound = false;
            var thirdFound = false;

            // Single pass instead of using Contains which requires multiple passes.
            var strings = _strings!;

            foreach (var str in strings)
            {
                if (str == _firstPriority)
                {
                    firstFound = true;
                    break;
                }

                if (str == _secondPriority)
                {
                    secondFound = true;
                }
                else if (str == _thirdPriority)
                {
                    thirdFound = true;
                }
            }

            var selected = (firstFound, secondFound, thirdFound) switch
            {
                (true, _, _) => _firstPriority,
                (_, true, _) => _secondPriority,
                (_, _, true) => _thirdPriority,
                _ => string.Empty
            };

            return selected;
        }

        [Benchmark]
        public string CheckWithMultipleContainsCalls()
        {
            var strings = _strings!;
            var target = _firstPriority;

            if (!strings.Contains(_firstPriority))
            {
                target = strings.Contains(_thirdPriority) ? _thirdPriority : string.Empty;
            }

            var selected = strings.Contains(_secondPriority) ? _secondPriority : target;

            return selected;
        }
    }
}
