namespace DictionaryCombineBenchmark
{
    using BenchmarkDotNet.Attributes;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [MemoryDiagnoser]
    public class Benchmark
    {
        public int FeatureCount { get; set; } = 100;

        public int ScoreFeatureCount { get; set; } = 100;

        private string[] _features = [];
        private string[] _scoreFeatures = [];

        [GlobalSetup]
        public void GlobalSetup()
        {
            var random = new Random(42);
            
            _features = new string[FeatureCount];
            for (int i = 0; i < FeatureCount; i++)
            {
                _features[i] = $"feature_{i}_{random.Next(1000)}";
            }

            _scoreFeatures = new string[ScoreFeatureCount];
            for (int i = 0; i < ScoreFeatureCount; i++)
            {
                _scoreFeatures[i] = $"scoreFeature_{i}_{random.Next(1000)}";
            }
        }

        [Benchmark]
        public Dictionary<string, uint> OriginalLinqApproach()
        {
            var result = _features.ToDictionary(x => x, x => (uint)0);
            result = result.Concat(_scoreFeatures.ToDictionary(x => x, x => (uint)0))
                          .ToDictionary(x => x.Key, x => x.Value);
            return result;
        }

        [Benchmark]
        public Dictionary<string, uint> LoopWithoutPresize()
        {
            var result = new Dictionary<string, uint>();
            
            foreach (var feature in _features)
            {
                result[feature] = 0;
            }
            
            foreach (var scoreFeature in _scoreFeatures)
            {
                result[scoreFeature] = 0;
            }
            
            return result;
        }

        [Benchmark(Baseline = true)]
        public Dictionary<string, uint> LoopsWithPresize()
        {
            var totalCount = _features.Length + _scoreFeatures.Length;
            var result = new Dictionary<string, uint>(totalCount);
            
            foreach (var feature in _features)
            {
                result[feature] = 0;
            }
            
            foreach (var scoreFeature in _scoreFeatures)
            {
                result[scoreFeature] = 0;
            }
            
            return result;
        }
    }
}
