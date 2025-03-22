namespace Test
{
    using System;
    using System.Buffers;
    using System.Collections.Frozen;
    using System.Collections.Generic;
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;

    public interface IFilters
    {
        bool TryGetValue(string key, out string value);
    }

    public interface IVariants : IFilters
    {
        bool TryAdd(string name, string value);


        bool HasDynamicVariants();
    }

    public class Filters : IVariants
    {
        private readonly Dictionary<string, string> _filters = new();

        public bool TryGetValue(string key, out string value)
        {
            return _filters.TryGetValue(key, out value);
        }

        public bool TryAdd(string name, string value)
        {
            if (_filters.ContainsKey(name))
            {
                return false;
            }

            _filters[name] = value;
            return true;
        }

        public bool HasDynamicVariants()
        {
            return false;
        }
    }

    public static class VariantsExtensions
    {
        static readonly SearchValues<string> _truthyValueStrings = SearchValues.Create(["true", "1"], StringComparison.OrdinalIgnoreCase);
        static readonly FrozenSet<string> _truthyValues = FrozenSet.Create(StringComparer.OrdinalIgnoreCase, ["true", "1"]);

        private const string IsTrueStr = "1";
        public static bool GetTrueBool(this IVariants variants, string variantName)
        {
            var boolTrue = variants.TryGetValue(variantName, out var isBoolVariant) && (bool.TryParse(isBoolVariant, out bool variantTrue) && variantTrue);

            return boolTrue || string.Equals(IsTrueStr, isBoolVariant);
        }

        public static bool GetTrueBool2(this IVariants variants, string variantName)
        {
            if (!variants.TryGetValue(variantName, out var variant))
            {
                return false;
            }

            if (variant.Equals("true", StringComparison.OrdinalIgnoreCase) ||
                variant.Equals("1"))
            {
                return true;
            }

            return false;
        }

        public static bool GetTrueBool3(this IVariants variants, string variantName) =>
            variants.TryGetValue(variantName, out var variant) && _truthyValueStrings.Contains(variant);

        public static bool GetTrueBool4(this IVariants variants, string variantName) =>
            variants.TryGetValue(variantName, out var variant) && _truthyValues.Contains(variant);
    }

    [MemoryDiagnoser]
    public class Benchmark
    {
        private Filters _filters;

        [Params(1000)]
        public int Count { get; set; } = 1000;

        [GlobalSetup]
        public void GlobalSetup()
        {
            var random = new Random(Count);

            _filters = new Filters();
            for (int i = 0; i < Count; i++)
            {
                var tmp = random.Next();
                if (tmp % 2 == 0)
                {
                    _filters.TryAdd($"key{i}", $"1");
                }
                else if (tmp % 3 == 0)
                {
                    _filters.TryAdd($"key{i}", $"true");
                }
                else if (tmp % 5 == 0)
                {
                    _filters.TryAdd($"key{i}", $"TRUE");
                }
                else if (tmp % 7 == 0)
                {
                    _filters.TryAdd($"key{i}", $"false");
                }
                else
                {
                    _filters.TryAdd($"key{i}", $"value{i}");
                }
            }
        }

        [Benchmark]
        public long CheckWithTryParse()
        {
            var sum = 0L;

            for (int i = 0; i < Count; i++)
            {
                var variantName = $"key{i}";
                var result = _filters.GetTrueBool(variantName);
                if (result)
                {
                    sum += i;
                }
            }

            return sum;
        }

        [Benchmark(Baseline = true)]
        public long CheckWithStringCompare()
        {
            var sum = 0L;

            for (int i = 0; i < Count; i++)
            {
                var variantName = $"key{i}";
                var result = _filters.GetTrueBool2(variantName);
                if (result)
                {
                    sum += i;
                }
            }

            return sum;
        }

        [Benchmark]
        public long CheckWithStringCompareAaronSearchValues()
        {
            var sum = 0L;

            for (int i = 0; i < Count; i++)
            {
                var variantName = $"key{i}";
                var result = _filters.GetTrueBool3(variantName);
                if (result)
                {
                    sum += i;
                }
            }

            return sum;
        }

        [Benchmark]
        public long CheckWithStringCompareAaronFrozenSet()
        {
            var sum = 0L;

            for (int i = 0; i < Count; i++)
            {
                var variantName = $"key{i}";
                var result = _filters.GetTrueBool4(variantName);
                if (result)
                {
                    sum += i;
                }
            }

            return sum;
        }
    }
}
