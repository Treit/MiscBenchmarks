using System;
using System.Linq;
using BenchmarkDotNet.Attributes;

namespace SortWithEnumParsing
{
    [MemoryDiagnoser]
    public class Benchmark
    {
        private static readonly string[] HolidayNames = Enum.GetNames<Holiday>();
        private ExpressionHolidayItem[] _expressionItems = [];
        private CachedHolidayItem[] _cachedItems = [];

        [Params(5, 100)]
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            var random = new Random(Count);
            _expressionItems = new ExpressionHolidayItem[Count];
            _cachedItems = new CachedHolidayItem[Count];

            for (int i = 0; i < Count; i++)
            {
                string value = HolidayNames[random.Next(HolidayNames.Length)];
                _expressionItems[i] = new ExpressionHolidayItem(value);
                _cachedItems[i] = new CachedHolidayItem(value);
            }
        }

        [Benchmark]
        public ExpressionHolidayItem[] ExpressionPropertySort()
        {
            return _expressionItems
                .OrderBy(static item => item.Holiday)
                .ToArray();
        }

        [Benchmark(Baseline = true)]
        public CachedHolidayItem[] CachedPropertySort()
        {
            return _cachedItems
                .OrderBy(static item => item.Holiday)
                .ToArray();
        }
    }

    public sealed record ExpressionHolidayItem(string Value)
    {
        public Holiday Holiday => Enum.Parse<Holiday>(Value);
    }

    public sealed record CachedHolidayItem(string Value)
    {
        public Holiday Holiday { get; } = Enum.Parse<Holiday>(Value);
    }

    public enum Holiday
    {
        NewYearsDay,
        ValentinesDay,
        StPatricksDay,
        Easter,
        MemorialDay,
        IndependenceDay,
        LaborDay,
        Halloween,
        Thanksgiving,
        Christmas,
    }
}
