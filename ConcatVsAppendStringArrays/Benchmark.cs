using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConcatVsAppendStringArrays
{
    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(100, 1000)]
        public int Count { get; set; }

        [Benchmark(Baseline = true)]
        public string[] UsingConcat()
        {
            return Enumerable.Range(1, Count)
                .Select(i => $"DnI{i}")
                .Concat("Average30DayViews,Average30DayClicks".Split(','))
                .ToArray();
        }

        [Benchmark]
        public string[] UsingAppend()
        {
            return Enumerable.Range(1, Count)
                .Select(i => $"DnI{i}")
                .Append("Average30DayViews")
                .Append("Average30DayClicks")
                .ToArray();
        }

        [Benchmark]
        public string[] UsingListAdd()
        {
            var list = new List<string>(Count + 2);

            for (int i = 1; i <= Count; i++)
            {
                list.Add($"DnI{i}");
            }

            list.Add("Average30DayViews");
            list.Add("Average30DayClicks");

            return list.ToArray();
        }

        [Benchmark]
        public string[] UsingListAddRange()
        {
            var list = new List<string>(Count + 2);

            // Use AddRange to add the generated items all at once
            list.AddRange(Enumerable.Range(1, Count).Select(i => $"DnI{i}"));

            // Add the fixed items individually
            list.Add("Average30DayViews");
            list.Add("Average30DayClicks");

            return list.ToArray();
        }

        [Benchmark]
        public string[] UsingArrayWithIndex()
        {
            var result = new string[Count + 2];

            for (int i = 0; i < Count; i++)
            {
                result[i] = $"DnI{i + 1}";
            }

            result[Count] = "Average30DayViews";
            result[Count + 1] = "Average30DayClicks";

            return result;
        }

        [Benchmark]
        public string[] UsingArrayCopyTo()
        {
            var dniTags = new string[Count];
            for (int i = 0; i < Count; i++)
            {
                dniTags[i] = $"DnI{i + 1}";
            }

            var result = new string[Count + 2];
            Array.Copy(dniTags, 0, result, 0, Count);
            result[Count] = "Average30DayViews";
            result[Count + 1] = "Average30DayClicks";

            return result;
        }

        [Benchmark]
        public string[] UsingSpanAndCopyTo()
        {
            var result = new string[Count + 2];
            var span = result.AsSpan();

            for (int i = 0; i < Count; i++)
            {
                span[i] = $"DnI{i + 1}";
            }

            span[Count] = "Average30DayViews";
            span[Count + 1] = "Average30DayClicks";

            return result;
        }
    }
}
