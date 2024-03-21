namespace Test
{
    using System;
    using System.Collections.Generic;
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;

    public class Constants
    {
        public const string ValueA = "ValueA";
        public const string ValueB = "ValueB";
    }

    [MemoryDiagnoser]
    public class Benchmark
    {
        private Random _random;

        [Params(1, 1000)]
        public int Iterations { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            _random = new Random(Iterations);
        }

        [Benchmark(Baseline = true)]
        public int CheckTwoBooleansUsingTuple()
        {
            var result = 0;

            for (int i = 0; i < Iterations; i++)
            {
                var toggleStatus = GetValuesViaTuple();
                if (toggleStatus.ValueA && toggleStatus.ValueB)
                {
                    result++;
                }
            }

            return result;
        }

        [Benchmark]
        public int CheckTwoBooleansUsingDictionary()
        {
            var result = 0;

            for (int i = 0; i < Iterations; i++)
            {
                var toggleStatus = GetValuesViaDictionary();
                if (toggleStatus[Constants.ValueA] && toggleStatus[Constants.ValueB])
                {
                    result++;
                }
            }

            return result;
        }

        private (bool ValueA, bool ValueB) GetValuesViaTuple()
        {
            var toggleStatus = (ValueA: true, ValueB: true);

            if (_random.Next() % 2 == 0)
            {
                toggleStatus.ValueA = false;
            }
            else if (_random.Next() % 2 == 0)
            {
                toggleStatus.ValueB = false;
            }

            return toggleStatus;
        }

        private Dictionary<string, bool> GetValuesViaDictionary()
        {
            var toggleStatus = new Dictionary<string, bool>()
            {
                { Constants.ValueA, true },
                { Constants.ValueB, true },
            };

            if (_random.Next() % 10 == 0)
            {
                toggleStatus[Constants.ValueA] = false;
            }
            else if (_random.Next() % 2 == 0)
            {
                toggleStatus[Constants.ValueB] = false;
            }

            return toggleStatus;
        }
    }
}
