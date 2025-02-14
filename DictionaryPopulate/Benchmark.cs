namespace Test
{
    using BenchmarkDotNet.Attributes;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Scenario here is from production real-world code, where we are
    /// updating a dictionary with values from another dictionary. The majority
    /// of the keys are not present in the second dictionary, so we need to set
    /// those to zero in the target dictionary.
    /// </summary>
    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(5000)]
        public int Count { get; set; }

        private List<string> _keys;
        private Dictionary<string, int> _map;
        private string _keyModifier;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _keyModifier = "someModifier";
            _keys = new List<string>();
            _map = new Dictionary<string, int>();
            for (int i = 0; i < Count; i++)
            {
                _keys.Add($"key{i}");
                if (i < 1000)
                {
                    if (i % 2 == 0)
                    {
                        _map.Add($"{_keyModifier}key{i}", i);
                    }
                    else if (i < 1000)
                    {
                        _map.Add($"key{i}", i);
                    }
                }
            }
        }

        [Benchmark]
        public int PopulateOriginalWithThreeChecksAndTryAdd()
        {
            var updatedMap = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            foreach (var key in _keys)
            {
                if (_map.TryGetValue(key, out int value))
                {
                    updatedMap.TryAdd(key, value);
                }
                else if (_map.TryGetValue($"{_keyModifier}{key}", out int otherValue))
                {
                    updatedMap.TryAdd(key, otherValue);
                }
                else
                {
                    updatedMap.TryAdd(key, 0);
                }
            }

            return updatedMap.Count;
        }

        [Benchmark]
        public int PopulateWithThreeChecksAndAdd()
        {
            var updatedMap = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            foreach (var key in _keys)
            {
                if (_map.TryGetValue(key, out int value))
                {
                    updatedMap.Add(key, value);
                }
                else if (_map.TryGetValue($"{_keyModifier}{key}", out int otherValue))
                {
                    updatedMap.Add(key, otherValue);
                }
                else
                {
                    updatedMap.Add(key, 0);
                }
            }

            return updatedMap.Count;
        }

        [Benchmark]
        public int PopulateWithThreeChecksAndIndexerAssignment()
        {
            var updatedMap = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            foreach (var key in _keys)
            {
                if (_map.TryGetValue(key, out int value))
                {
                    updatedMap[key] = value;
                }
                else if (_map.TryGetValue($"{_keyModifier}{key}", out int otherValue))
                {
                    updatedMap[key] = otherValue;
                }
                else
                {
                    updatedMap[key] = 0;
                }
            }

            return updatedMap.Count;
        }

        [Benchmark(Baseline = true)]
        public int PopulateWithInitializeToZeroAndThenUpdate()
        {
            var updatedMap = _keys.ToDictionary(key => key, _ => 0, StringComparer.OrdinalIgnoreCase);

            foreach (var key in _keys)
            {
                if (_map.TryGetValue(key, out int value))
                {
                    updatedMap[key] = value;
                }
                else if (_map.TryGetValue($"{_keyModifier}{key}", out int otherValue))
                {
                    updatedMap[key] = otherValue;
                }
            }

            return updatedMap.Count;
        }
    }
}
