using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace ListSpreadVsReadOnly
{
    // Simulating the CreatePullRequestOptions class with expression-bodied property
    public class CreatePullRequestOptionsExpressionBody
    {
        public static List<string> Arguments => ["base-arg1", "base-arg2", "base-arg3", "base-arg4", "base-arg5"];
    }

    // Simulating the CreatePullRequestOptions class with readonly list field
    public class CreatePullRequestOptionsReadOnlyList
    {
        private static readonly List<string> _arguments = ["base-arg1", "base-arg2", "base-arg3", "base-arg4", "base-arg5"];
        public static List<string> Arguments => _arguments;
    }

    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(10, 100)]
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
        }

        [Benchmark(Baseline = true)]
        public int UsingExpressionBodyEmptyList()
        {
            int total = 0;
            for (int i = 0; i < Count; i++)
            {
                List<string> arguments =
                [
                    "arg1",
                    "arg2",
                    "arg3",
                    ..CreatePullRequestOptionsExpressionBody.Arguments,
                ];
                total += arguments.Count;
            }
            return total;
        }

        [Benchmark]
        public int UsingReadOnlyListField()
        {
            int total = 0;
            for (int i = 0; i < Count; i++)
            {
                List<string> arguments =
                [
                    "arg1",
                    "arg2",
                    "arg3",
                    ..CreatePullRequestOptionsReadOnlyList.Arguments,
                ];
                total += arguments.Count;
            }
            return total;
        }
    }
}
