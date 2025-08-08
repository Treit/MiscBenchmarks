namespace StringSwitchVsDictionary
{
    using BenchmarkDotNet.Running;
    using System;

    internal class Program
    {
        static void Main(string[] args)
        {
#if RELEASE
            BenchmarkRunner.Run<Benchmark>();
#else
            // Debug mode: Test benchmark methods and compare results
            Benchmark b = new Benchmark();
            b.IterationCount = 100; // Small count for debug testing
            b.GlobalSetup();

            // Test each benchmark method
            var switchResult = b.StringSwitchWithToLowerInvariant();
            b.GlobalSetup();
            var dictionaryResult = b.CaseInsensitiveDictionary();
            b.GlobalSetup();
            var frozenDictionaryResult = b.CaseInsensitiveFrozenDictionary();

            // Output results for comparison
            Console.WriteLine($"String Switch with ToLowerInvariant: {switchResult}");
            Console.WriteLine($"Case-Insensitive Dictionary: {dictionaryResult}");
            Console.WriteLine($"Case-Insensitive FrozenDictionary: {frozenDictionaryResult}");

            // Verify results are equivalent
            Console.WriteLine($"All results equal: {switchResult == dictionaryResult && dictionaryResult == frozenDictionaryResult}");
#endif
        }
    }
}
