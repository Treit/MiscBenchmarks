namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using System.Collections.Generic;
    using System.Linq;

    public class Response
    {
    }

    internal class IdRequest
    {
        public IList<int> Ids
        {
            get
            {
                return Query.Ids;
            }
        }

        public Query Query { get; set; } = new Query();
    }

    internal class Query
    {
        public List<int> Ids { get; set; } = new List<int>();
    }

    [MemoryDiagnoser]
    public class Benchmark
    {
        static readonly IdRequest s_request = new IdRequest();

        [Params(10, 10_000)]
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            for (int i = 0; i < this.Count; i++)
            {
                s_request.Query.Ids.Add(i);
            }
        }

        [Benchmark(Baseline = true)]
        public Dictionary<int, Response?> BuildDictionaryUsingForLoop()
        {
            var dict = new Dictionary<int, Response?>(s_request.Ids.Count);
            for (int i = 0; i < this.Count; i++)
            {
                dict.Add(i, null);
            }

            return dict;
        }

        [Benchmark]
        public Dictionary<int, Response> BuildDictionaryUsingZipAndToDictionary()
        {
            var values = new Response[s_request.Ids.Count];
            var originalIdsAndResponses = s_request.Query.Ids.Zip(values, (k, v) => new { k, v })
                .ToDictionary(kv => kv.k, kv => kv.v);

            return originalIdsAndResponses;
        }

        [Benchmark]
        public Dictionary<int, Response?> BuildDictionaryUsingToDictionary()
        {
            return s_request.Query.Ids.ToDictionary(id => id, _ => (Response?)null);
        }
    }
}
