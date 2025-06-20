namespace ObjectCopyingBenchmark
{
    using BenchmarkDotNet.Attributes;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    // Internal object - what we're copying from
    public class InternalObject
    {
        public required string Name { get; set; }
        public required int Id { get; set; }
        public required IReadOnlyList<string> Data { get; set; }
    }

    // External object - DTO we're copying to
    public class ExternalObject
    {
        public string Name { get; }
        public int Id { get; }
        public IReadOnlyList<string>? Data { get; }

        public ExternalObject(string name, int id, IReadOnlyList<string>? data)
        {
            Name = name;
            Id = id;
            Data = data;
        }
    }

    [MemoryDiagnoser]
    public class Benchmark
    {
        private InternalObject[] _internalObjects = [];

        [Params(10, 10_000)]
        public int Count { get; set; }

        [Params(5, 500)]
        public int DataSize { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            var random = new Random(42);
            _internalObjects = new InternalObject[Count];

            for (int i = 0; i < Count; i++)
            {
                var data = new List<string>();
                for (int j = 0; j < DataSize; j++)
                {
                    data.Add($"Item_{i}_{j}");
                }

                _internalObjects[i] = new InternalObject
                {
                    Name = $"Object_{i}",
                    Id = i,
                    Data = data
                };
            }
        }

        [Benchmark]
        public ExternalObject[] CopyWithSelectToArray()
        {
            var results = new ExternalObject[_internalObjects.Length];

            for (int i = 0; i < _internalObjects.Length; i++)
            {
                var internalObj = _internalObjects[i];
                results[i] = new ExternalObject(
                    internalObj.Name,
                    internalObj.Id,
                    internalObj.Data?.Select(x => x)?.ToArray()
                );
            }

            return results;
        }

        [Benchmark(Baseline = true)]
        public ExternalObject[] CopyWithDirectReference()
        {
            var results = new ExternalObject[_internalObjects.Length];

            for (int i = 0; i < _internalObjects.Length; i++)
            {
                var internalObj = _internalObjects[i];
                results[i] = new ExternalObject(
                    internalObj.Name,
                    internalObj.Id,
                    internalObj.Data
                );
            }

            return results;
        }

        [Benchmark]
        public ExternalObject[] CopyWithToArray()
        {
            var results = new ExternalObject[_internalObjects.Length];

            for (int i = 0; i < _internalObjects.Length; i++)
            {
                var internalObj = _internalObjects[i];
                results[i] = new ExternalObject(
                    internalObj.Name,
                    internalObj.Id,
                    internalObj.Data?.ToArray()
                );
            }

            return results;
        }

        [Benchmark]
        public ExternalObject[] CopyWithToList()
        {
            var results = new ExternalObject[_internalObjects.Length];

            for (int i = 0; i < _internalObjects.Length; i++)
            {
                var internalObj = _internalObjects[i];
                results[i] = new ExternalObject(
                    internalObj.Name,
                    internalObj.Id,
                    internalObj.Data?.ToList()
                );
            }

            return results;
        }
    }
}
