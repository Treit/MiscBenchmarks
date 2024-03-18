namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    record Response(string ResponseData);

    [MemoryDiagnoser]
    public class Benchmark
    {
        private List<Response> _data;

        [Params(100, 100_000)]
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            _data = new List<Response>(Count);
            for (int i = 0; i < Count; i++)
            {
                _data.Add(new Response(i.ToString()));
            }
        }

        [Benchmark(Baseline = true)]
        public string WithPatternMatching()
        {
            var searchResponse = _data;
            var result = string.Empty;

            if (searchResponse.FirstOrDefault() is { ResponseData: not null } response)
            {
                result = ParseSearchResponse(response);
            }

            return result;
        }

        [Benchmark]
        public string WithMultipleToLists()
        {
            var searchResponse = _data;
            var result = string.Empty;

            if (searchResponse.ToList().Count() > 0 && searchResponse.ToList().FirstOrDefault().ResponseData != null)
            {
                result = ParseSearchResponse(searchResponse.ToList().FirstOrDefault());
            }

            return result;
        }

        string ParseSearchResponse(Response response)
        {
            return response.ResponseData + "!";
        }   
    }
}
