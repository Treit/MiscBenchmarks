namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using System;

    public class Benchmark
    {
        private bool[] _bools;

        [Params(1_000_000)]
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            _bools = new bool[Count];
            var r = new Random(Count);

            for (int i = 0; i < Count; i++)
            {
                _bools[i] = r.Next(0, 2) == 0;
            }
        }

        [Benchmark(Baseline = true)]
        public int ToggleUsingNegation()
        {
            var bools = _bools;
            for (int i = 0; i < bools.Length; i++)
            {
                bools[i] = !bools[i];
            }

            return bools.Length;
        }

        [Benchmark]
        public int ToggleUsingXor()
        {
            var bools = _bools;
            for (int i = 0; i < bools.Length; i++)
            {
                bools[i] ^= true;
            }

            return bools.Length;
        }

        [Benchmark]
        public int ToggleUsingTernary()
        {
            var bools = _bools;
            for (int i = 0; i < bools.Length; i++)
            {
                bools[i] = bools[i] ? false : true;
            }

            return bools.Length;
        }

        [Benchmark]
        public int ToggleUsingSwitchExpression()
        {
            var bools = _bools;
            for (int i = 0; i < bools.Length; i++)
            {
                bools[i] = bools[i] switch
                {
                    true => false,
                    false => true
                };
            }

            return bools.Length;
        }

    }
}
