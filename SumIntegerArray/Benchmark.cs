using System.Text;

namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using System;
    using System.Linq;

    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(10, 10_000)]
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
        }

        [Benchmark(Baseline = true)]
        public long SumUsingForLoop()
        {
            var _ints = new int[Count];

            for (int i = 0; i < Count; i++)
            {
                _ints[i] = i;
            }
            
            long result = 0;

            for (int i = 0; i < _ints.Length; i++)
            {
                result += _ints[i];
            }

            return result;
        }

        [Benchmark]
        public long SumUsingForLoopSpan()
        {
            var _ints = new int[Count].AsSpan();

            for (int i = 0; i < Count; i++)
            {
                _ints[i] = i;
            }
            
            long result = 0;

            for (int i = 0; i < _ints.Length; i++)
            {
                result += _ints[i];
            }

            return result;
        }

        [Benchmark]
        public long SumUsingLinqSum()
        {
            var _ints = new int[Count];

            for (int i = 0; i < Count; i++)
            {
                _ints[i] = i;
            }

            return _ints.Sum();
        }

        [Benchmark]
        public long SumUsingRangeAndRecursionElalev()
        {
            var _ints = new int[Count];

            for (int i = 0; i < Count; i++)
            {
                _ints[i] = i;
            }

            return Sum(_ints);
        }

        [Benchmark]
        public long SumUsingRangeAndRecursionElalevWithSpan()
        {
            var _ints = new int[Count].AsSpan();

            for (int i = 0; i < Count; i++)
            {
                _ints[i] = i;
            }
            
            return SumSpan(_ints);
        }

        static long Sum(int[] nums) => nums switch
        {
              [] => 0,
              [var firstNum, ..var restNums] => firstNum + Sum(restNums)
        };

        static long SumSpan(Span<int> nums) => nums switch
        {
              [] => 0,
              [var firstNum, ..var restNums] => firstNum + SumSpan(restNums)
        };
    }
}


