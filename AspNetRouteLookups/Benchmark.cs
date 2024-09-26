namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using Microsoft.AspNetCore.Routing;
    using Microsoft.AspNetCore.Routing.Patterns;
    using Microsoft.AspNetCore.Routing.Template;
    using Microsoft.Diagnostics.Tracing.Parsers.FrameworkEventSource;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    [MemoryDiagnoser]
    public class Benchmark
    {
        private static List<(TemplateMatcher, int)> _matchers;
        private static List<(Regex, int)> _regexes;
        private static List<string> _urls;

        [Params(100)]
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            var routes = GetEndpoints().OrderBy(x => x.Order).ToArray();
            var emptyValueDictionary = new RouteValueDictionary();

            _matchers = new();
            foreach (var route in routes)
            {
                var patternText = route.RoutePattern.RawText!;
                var template = TemplateParser.Parse(patternText);
                var matcher = new TemplateMatcher(template, emptyValueDictionary);
                _matchers.Add((matcher, 1234));
            }

            _regexes =
            [
                (new Regex(@"/xyz/foo/.+?/something", RegexOptions.Compiled | RegexOptions.IgnoreCase), 1234),
                (new Regex(@"/test/bar/.+?/getdata/.+?", RegexOptions.Compiled | RegexOptions.IgnoreCase), 1234),
                (new Regex(@"/foo/bar/something", RegexOptions.Compiled | RegexOptions.IgnoreCase), 1234),
                (new Regex(@"/foo/baz/somethingelse", RegexOptions.Compiled | RegexOptions.IgnoreCase), 1234),
            ];

            _urls = new();
            var random = new Random(Count);

            for (int i = 0; i < Count; i++)
            {
                _urls.Add(GetRandomUrl(random));
            }
        }

        [Benchmark]
        public long MatchUrlsUsingTemplateMatcher()
        {
            var emptyDict = new RouteValueDictionary();
            var matches = 0;

            foreach (var url in _urls)
            {
                foreach (var (matcher, value) in _matchers)
                {
                    if (matcher.TryMatch(url, emptyDict))
                    {
                        matches++;
                    }
                }
            }

            return matches;
        }

        [Benchmark(Baseline = true)]
        public long MatchUrlsUsingRegex()
        {
            var emptyDict = new RouteValueDictionary();
            var matches = 0;

            foreach (var url in _urls)
            {
                foreach (var (regex, value) in _regexes)
                {
                    if (regex.IsMatch(url))
                    {
                        matches++;
                    }
                }
            }

            return matches;
        }

        private static IEnumerable<RouteEndpoint> GetEndpoints()
        {
            var endpoints = new List<RouteEndpoint>
            {
                new(x => Task.CompletedTask, RoutePatternFactory.Parse("/xyz/foo/{id}/something"), 1, null, null),
                new(x => Task.CompletedTask, RoutePatternFactory.Parse("/test/bar/{id}/getdata/{other}"), 2, null, null),
                new(x => Task.CompletedTask, RoutePatternFactory.Parse("/foo/bar/something"), 3, null, null),
                new(x => Task.CompletedTask, RoutePatternFactory.Parse("/foo/baz/somethingelse"), 4, null, null)
            };

            return endpoints;
        }

        private static string GetRandomUrl(Random random)
        {
            var next = random.Next(10);

            return next switch
            {
                < 2 => $"/xyz/foo/{random.Next(1000)}/something",
                < 4 => $"/test/bar/{random.Next(1000)}/getdata/{random.Next(1000)}",
                < 6 => "/foo/bar/something",
                < 8 => "/foo/baz/somethingelse",
                _ => "/something/random/not/a/known/route"
            };
        }

    }
}
