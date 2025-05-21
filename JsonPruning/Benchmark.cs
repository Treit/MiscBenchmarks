namespace Test
{
    using BenchmarkDotNet.Attributes;
    using System;
    using System.Collections.Generic;
    using System.Text.Json;

    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(1000, 100_000)]
        public int Count { get; set; }

        private List<ComplexObject> _complexObjects;
        private HashSet<string> _nodesToPrune;

        [GlobalSetup]
        public void GlobalSetup()
        {
            DoSetup();
        }

        [Benchmark(Baseline = true)]
        public string PruneRecursiveWithWriter()
        {
            return JsonUtils.SerializeAndPrune(_complexObjects, _nodesToPrune);
        }

        [Benchmark]
        public string PruneWithJsonNodeRemove()
        {
            return JsonUtils.RemoveAllByName(_complexObjects, _nodesToPrune);
        }

        private void DoSetup()
        {
            _complexObjects = new List<ComplexObject>(Count);
            _nodesToPrune = new HashSet<string> { "sensitiveData", "internalMetadata", "debugInfo" };

            for (int i = 0; i < Count; i++)
            {
                _complexObjects.Add(new ComplexObject
                {
                    Id = i,
                    Name = $"Object {i}",
                    Description = $"This is a complex object with ID {i} created for benchmarking",
                    CreationDate = DateTime.Now.AddDays(-i % 30),
                    IsActive = i % 2 == 0,
                    Tags = new List<string> { "benchmark", "json", "pruning", $"tag-{i}" },
                    Properties = new Dictionary<string, string>
                    {
                        ["Key1"] = $"Value1-{i}",
                        ["Key2"] = $"Value2-{i}",
                        ["Key3"] = $"Value3-{i}"
                    },
                    Metadata = new Metadata
                    {
                        Version = $"1.0.{i % 10}",
                        Author = $"User{i % 5}",
                        LastModified = DateTime.Now.AddHours(-i % 24),
                        InternalMetadata = new InternalMetadata
                        {
                            ProcessId = i * 100,
                            ThreadId = i * 10,
                            DebugInfo = new DebugInfo
                            {
                                StackTrace = "Stack trace data that should be pruned",
                                MemoryUsage = i * 1024,
                                ProcessorTime = i * 10.5
                            }
                        }
                    },
                    SensitiveData = new SensitiveData
                    {
                        ApiKey = $"api-key-{i}",
                        Password = $"password{i}",
                        Token = $"token-{Guid.NewGuid()}"
                    },
                    Children = i % 5 == 0 ?
                        new List<ChildObject>
                        {
                            new ChildObject { Id = i * 10, Name = $"Child 1 of {i}" },
                            new ChildObject { Id = i * 10 + 1, Name = $"Child 2 of {i}" }
                        } :
                        new List<ChildObject>()
                });
            }
        }

    }
}
