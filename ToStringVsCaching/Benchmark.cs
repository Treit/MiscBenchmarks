namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using System;
    using System.Collections.Generic;

    [Flags]
    enum ReplicaType
    {
        Unknown = 0,
        Primary = 1,
        Secondary = (1 << 1),
        LocalSecondary = (1 << 2)
    }

    class TestData
    {
        public int? Id { get; set; }
        public ReplicaType ReplicaType { get; set; }
    }

    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(10_000, 1_000_000)]
        public int Count { get; set; }

        private List<TestData> _values;

        private Dictionary<int?, string> _idCache;
        private Dictionary<ReplicaType, string> _replicaTypeCache;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _values = new List<TestData>(Count);
            _idCache = new Dictionary<int?, string>();
            _replicaTypeCache = new Dictionary<ReplicaType, string>();

            var r = new Random();

            for (int i = 0; i < this.Count; i++)
            {
                var data = new TestData
                {
                    Id = i,
                    ReplicaType = r.Next(4) switch
                    {
                        0 => ReplicaType.Unknown,
                        1 => ReplicaType.Primary,
                        2 => ReplicaType.Secondary,
                        3 => ReplicaType.LocalSecondary,
                        _ => throw new InvalidOperationException("Unknown value")
                    }
                };

                _values.Add(data);
            }
        }

        [Benchmark(Baseline = true)]
        public long ProcessDataWithToString()
        {
            long result = 0;

            foreach (var data in _values)
            {
                result += DoSomething(data.Id.ToString(), data.ReplicaType.ToString());
            }

            return result;
        }

        [Benchmark]
        public long ProcessDataWithCachedString()
        {
            long result = 0;

            foreach (var data in _values)
            {
                if (!_idCache.TryGetValue(data.Id, out var idStr))
                {
                    idStr = data.Id.ToString();
                    _idCache.Add(data.Id, idStr);
                }

                if (!_replicaTypeCache.TryGetValue(data.ReplicaType, out var replicaTypeStr))
                {
                    replicaTypeStr = data.ReplicaType.ToString();
                    _replicaTypeCache.Add(data.ReplicaType, replicaTypeStr);
                }

                result += DoSomething(idStr, replicaTypeStr);
            }

            return result;
        }

        private static int DoSomething(string idString, string replicaTypeString)
        {
            return idString.Length + replicaTypeString.Length;
        }
    }
}
