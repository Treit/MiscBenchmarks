namespace StringSwitchVsDictionary
{
    using BenchmarkDotNet.Attributes;
    using System;
    using System.Collections.Frozen;
    using System.Collections.Generic;

    [MemoryDiagnoser]
    public class Benchmark
    {
        private static readonly Dictionary<string, TestEnum> TestEnumDictionary = 
            new Dictionary<string, TestEnum>(StringComparer.OrdinalIgnoreCase)
            {
                { "testvaluea", TestEnum.TestValueA },
                { "testvalueb", TestEnum.TestValueB },
                { "testvaluec", TestEnum.TestValueC },
                { "testvalued", TestEnum.TestValueD },
                { "testvaluee", TestEnum.TestValueE },
                { "testvaluef", TestEnum.TestValueF },
                { "testvalueg", TestEnum.TestValueG },
                { "testvalueh", TestEnum.TestValueH },
                { "testvaluei", TestEnum.TestValueI },
                { "testvaluej", TestEnum.TestValueJ },
                { "testvaluek", TestEnum.TestValueK },
                { "testvaluel", TestEnum.TestValueL },
                { "testvaluem", TestEnum.TestValueM },
                { "testvaluen", TestEnum.TestValueN },
                { "testvalueo", TestEnum.TestValueO },
                { "testvaluep", TestEnum.TestValueP },
                { "testvalueq", TestEnum.TestValueQ },
                { "testvaluer", TestEnum.TestValueR }
            };

        private static readonly FrozenDictionary<string, TestEnum> TestEnumFrozenDictionary = 
            new Dictionary<string, TestEnum>(StringComparer.OrdinalIgnoreCase)
            {
                { "testvaluea", TestEnum.TestValueA },
                { "testvalueb", TestEnum.TestValueB },
                { "testvaluec", TestEnum.TestValueC },
                { "testvalued", TestEnum.TestValueD },
                { "testvaluee", TestEnum.TestValueE },
                { "testvaluef", TestEnum.TestValueF },
                { "testvalueg", TestEnum.TestValueG },
                { "testvalueh", TestEnum.TestValueH },
                { "testvaluei", TestEnum.TestValueI },
                { "testvaluej", TestEnum.TestValueJ },
                { "testvaluek", TestEnum.TestValueK },
                { "testvaluel", TestEnum.TestValueL },
                { "testvaluem", TestEnum.TestValueM },
                { "testvaluen", TestEnum.TestValueN },
                { "testvalueo", TestEnum.TestValueO },
                { "testvaluep", TestEnum.TestValueP },
                { "testvalueq", TestEnum.TestValueQ },
                { "testvaluer", TestEnum.TestValueR }
            }.ToFrozenDictionary(StringComparer.OrdinalIgnoreCase);

        private string[] _testStrings = null!;

        [Params(1000, 10000)]
        public int IterationCount { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            // Mix of valid and invalid strings, with various casing to test case-insensitive lookup
            _testStrings = new[]
            {
                "TestValueA", "TESTVALUEB", "testvaluec", "TestValueD",
                "TESTVALUEE", "testvaluef", "TestValueG", "TESTVALUEH",
                "testvaluei", "TestValueJ", "TESTVALUEK", "testvaluel",
                "TestValueM", "TESTVALUEN", "testvalueo", "TestValueP",
                "TESTVALUEQ", "testvaluer",
                // Some invalid values to test the default case
                "invalidvalue", "another", "test", "notfound"
            };
        }

        [Benchmark(Baseline = true)]
        public int StringSwitchWithToLowerInvariant()
        {
            int count = 0;
            for (int i = 0; i < IterationCount; i++)
            {
                foreach (var testString in _testStrings)
                {
                    var result = ToTestEnumSwitchPattern(testString);
                    if (result != null)
                        count++;
                }
            }
            return count;
        }

        [Benchmark]
        public int CaseInsensitiveDictionary()
        {
            int count = 0;
            for (int i = 0; i < IterationCount; i++)
            {
                foreach (var testString in _testStrings)
                {
                    var result = ToTestEnumDictionaryPattern(testString);
                    if (result != null)
                        count++;
                }
            }
            return count;
        }

        [Benchmark]
        public int CaseInsensitiveFrozenDictionary()
        {
            int count = 0;
            for (int i = 0; i < IterationCount; i++)
            {
                foreach (var testString in _testStrings)
                {
                    var result = ToTestEnumFrozenDictionaryPattern(testString);
                    if (result != null)
                        count++;
                }
            }
            return count;
        }

        // Original switch pattern (with ToLowerInvariant allocation)
        private static TestEnum? ToTestEnumSwitchPattern(string value) => value.ToLowerInvariant() switch
        {
            "testvaluea" => TestEnum.TestValueA,
            "testvalueb" => TestEnum.TestValueB,
            "testvaluec" => TestEnum.TestValueC,
            "testvalued" => TestEnum.TestValueD,
            "testvaluee" => TestEnum.TestValueE,
            "testvaluef" => TestEnum.TestValueF,
            "testvalueg" => TestEnum.TestValueG,
            "testvalueh" => TestEnum.TestValueH,
            "testvaluei" => TestEnum.TestValueI,
            "testvaluej" => TestEnum.TestValueJ,
            "testvaluek" => TestEnum.TestValueK,
            "testvaluel" => TestEnum.TestValueL,
            "testvaluem" => TestEnum.TestValueM,
            "testvaluen" => TestEnum.TestValueN,
            "testvalueo" => TestEnum.TestValueO,
            "testvaluep" => TestEnum.TestValueP,
            "testvalueq" => TestEnum.TestValueQ,
            "testvaluer" => TestEnum.TestValueR,
            _ => null
        };

        // Dictionary pattern (case-insensitive, no allocation)
        private static TestEnum? ToTestEnumDictionaryPattern(string value)
        {
            return TestEnumDictionary.TryGetValue(value, out var result) ? result : null;
        }

        // FrozenDictionary pattern (case-insensitive, no allocation, optimized for read-only scenarios)
        private static TestEnum? ToTestEnumFrozenDictionaryPattern(string value)
        {
            return TestEnumFrozenDictionary.TryGetValue(value, out var result) ? result : null;
        }
    }
}
