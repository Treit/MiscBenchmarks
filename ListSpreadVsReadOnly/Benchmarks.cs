using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace ListSpreadVsReadOnly
{
    // Expression-bodied property returning new list with items each time
    public class CreatePullRequestOptionsExpressionBody
    {
        public static List<string> Arguments => ["base-arg1", "base-arg2", "base-arg3", "base-arg4", "base-arg5"];
    }

    // Expression-bodied property returning empty list each time
    public class CreatePullRequestOptionsExpressionBodyEmpty
    {
        public static List<string> Arguments => [];
    }

    // IReadOnlyList with items
    public class CreatePullRequestOptionsIReadOnlyList
    {
        private static readonly IReadOnlyList<string> _arguments = new List<string> { "base-arg1", "base-arg2", "base-arg3", "base-arg4", "base-arg5" };
        public static IReadOnlyList<string> Arguments => _arguments;
    }

    // IReadOnlyList empty
    public class CreatePullRequestOptionsIReadOnlyListEmpty
    {
        private static readonly IReadOnlyList<string> _arguments = new List<string>();
        public static IReadOnlyList<string> Arguments => _arguments;
    }

    // FrozenSet with items
    public class CreatePullRequestOptionsFrozenSet
    {
        private static readonly FrozenSet<string> _arguments = new[] { "base-arg1", "base-arg2", "base-arg3", "base-arg4", "base-arg5" }.ToFrozenSet();
        public static FrozenSet<string> Arguments => _arguments;
    }

    // FrozenSet empty
    public class CreatePullRequestOptionsFrozenSetEmpty
    {
        private static readonly FrozenSet<string> _arguments = FrozenSet<string>.Empty;
        public static FrozenSet<string> Arguments => _arguments;
    }

    [MemoryDiagnoser]
    [SimpleJob(RuntimeMoniker.Net90)]
    [SimpleJob(RuntimeMoniker.Net10_0)]
    public class Benchmark
    {
        [Params(100)]
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
        }

        [Benchmark(Baseline = true)]
        public int ExpressionBodyWithItems()
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
        public int ExpressionBodyEmpty()
        {
            int total = 0;
            for (int i = 0; i < Count; i++)
            {
                List<string> arguments =
                [
                    "arg1",
                    "arg2",
                    "arg3",
                    ..CreatePullRequestOptionsExpressionBodyEmpty.Arguments,
                ];
                total += arguments.Count;
            }
            return total;
        }

        [Benchmark]
        public int IReadOnlyListWithItems()
        {
            int total = 0;
            for (int i = 0; i < Count; i++)
            {
                List<string> arguments =
                [
                    "arg1",
                    "arg2",
                    "arg3",
                    ..CreatePullRequestOptionsIReadOnlyList.Arguments,
                ];
                total += arguments.Count;
            }
            return total;
        }

        [Benchmark]
        public int IReadOnlyListEmpty()
        {
            int total = 0;
            for (int i = 0; i < Count; i++)
            {
                List<string> arguments =
                [
                    "arg1",
                    "arg2",
                    "arg3",
                    ..CreatePullRequestOptionsIReadOnlyListEmpty.Arguments,
                ];
                total += arguments.Count;
            }
            return total;
        }

        [Benchmark]
        public int FrozenSetWithItems()
        {
            int total = 0;
            for (int i = 0; i < Count; i++)
            {
                List<string> arguments =
                [
                    "arg1",
                    "arg2",
                    "arg3",
                    ..CreatePullRequestOptionsFrozenSet.Arguments,
                ];
                total += arguments.Count;
            }
            return total;
        }

        [Benchmark]
        public int FrozenSetEmpty()
        {
            int total = 0;
            for (int i = 0; i < Count; i++)
            {
                List<string> arguments =
                [
                    "arg1",
                    "arg2",
                    "arg3",
                    ..CreatePullRequestOptionsFrozenSetEmpty.Arguments,
                ];
                total += arguments.Count;
            }
            return total;
        }
    }
}
