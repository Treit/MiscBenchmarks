using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using System;

namespace ShortDayOfWeek
{
    public class Program
    {
        public static void Main(string[] args)
        {
#if RELEASE
            var config = DefaultConfig.Instance;
            var summary = BenchmarkRunner.Run<Benchmarks>(config, args);
#else
            var b = new Benchmarks();
            b.Count = 1000;
            b.GlobalSetup();
            var first = b.GetDayOfWeekSubstring();
            var second = b.GetDayOfWeekArrayLookup();
            var third = b.GetDayOfWeekSwitchExpression();
            Console.WriteLine($"Substring: {first}, Lookup: {second}, SwitchExpression: {third}");
#endif
        }
    }
}