using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;

namespace ShortDayOfWeek
{
    static class DateTimeExtensions
    {
        static string[] ShortDateLookup = new string[]
        {
            "SUN", "MON", "TUE", "WED", "THU", "FRI", "SAT"
        };

        public static string ToShortDayOfWeekSubstring(this DateTime date)
        {
            return date.DayOfWeek.ToString().Substring(0, 3).ToUpperInvariant();
        }

        public static string ToShortDayOfWeekSwitchExpression(this DateTime date)
        {
            return date.DayOfWeek switch
            {
                DayOfWeek.Sunday => "SUN",
                DayOfWeek.Monday => "MON",
                DayOfWeek.Tuesday => "TUE",
                DayOfWeek.Wednesday => "WED",
                DayOfWeek.Thursday => "THU",
                DayOfWeek.Friday => "FRI",
                DayOfWeek.Saturday => "SAT",
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        public static string ToShortDayOfWeekSwitchExpressionNoThrow(this DateTime date)
        {
            return date.DayOfWeek switch
            {
                DayOfWeek.Sunday => "SUN",
                DayOfWeek.Monday => "MON",
                DayOfWeek.Tuesday => "TUE",
                DayOfWeek.Wednesday => "WED",
                DayOfWeek.Thursday => "THU",
                DayOfWeek.Friday => "FRI",
                DayOfWeek.Saturday => "SAT",
                _ => string.Empty
            };
        }

        public static string ToShortDayOfWeekLookup(this DateTime date)
        {
            return ShortDateLookup[(int)date.DayOfWeek];
        }
    }

    [MemoryDiagnoser]
    [DisassemblyDiagnoser]
    public class Benchmarks
    {
        private List<DateTime> _days;

        [Params(1000)]
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            _days = new List<DateTime>();
            var r = new Random();

            for (int i = 0; i < Count; i++)
            {
                _days.Add(DateTime.Now.AddDays(r.Next(501)));
            }
        }

        [Benchmark]
        public long GetDayOfWeekSubstring()
        {
            var result = 0L;
            foreach (var day in _days)
            {
                result += day.ToShortDayOfWeekSubstring().Length;
            }

            return result;
        }

        [Benchmark]
        public long GetDayOfWeekSwitchExpression()
        {
            var result = 0L;

            foreach (var day in _days)
            {
                result += day.ToShortDayOfWeekSwitchExpression().Length;
            }

            return result;
        }

        [Benchmark]
        public long GetDayOfWeekSwitchExpressionNoThrow()
        {
            var result = 0L;

            foreach (var day in _days)
            {
                result += day.ToShortDayOfWeekSwitchExpressionNoThrow().Length;
            }

            return result;
        }

        [Benchmark(Baseline = true)]
        public long GetDayOfWeekLookup()
        {
            var result = 0L;

            foreach (var day in _days)
            {
                result += day.ToShortDayOfWeekLookup().Length;
            }

            return result;
        }
    }
}
