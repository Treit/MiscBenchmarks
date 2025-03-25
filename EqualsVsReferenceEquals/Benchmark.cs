namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using System;
    using System.Linq;
    using System.Collections.Concurrent;
    using System.Collections.Frozen;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Collections.ObjectModel;

    public static class CollectionUtils
    {
        public static bool IsCaseInsensitive<TValue>(IDictionary<string, TValue> dict)
        {
            return dict switch
            {
                Dictionary<string, TValue> d => IsCaseInsensitiveComparer(d.Comparer),
                ConcurrentDictionary<string, TValue> cd => IsCaseInsensitiveComparer(cd.Comparer),
                FrozenDictionary<string, TValue> fd => IsCaseInsensitiveComparer(fd.Comparer),
                ImmutableDictionary<string, TValue> imd => IsCaseInsensitiveComparer(imd.KeyComparer),
                ReadOnlyDictionary<string, TValue> => false, // ¯\_(ツ)_/¯ - ReadOnlyDictionary doesn't expose its comparer.
                _ => false
            };

            static bool IsCaseInsensitiveComparer(IEqualityComparer<string> comparer)
            {
                return comparer.Equals(StringComparer.OrdinalIgnoreCase)
                    || comparer.Equals(StringComparer.InvariantCultureIgnoreCase)
                    || comparer.Equals(StringComparer.CurrentCultureIgnoreCase);
            }
        }

        public static bool IsCaseInsensitiveReferenceEquals<TValue>(IDictionary<string, TValue> dict)
        {
            return dict switch
            {
                Dictionary<string, TValue> d => IsCaseInsensitiveComparer(d.Comparer),
                ConcurrentDictionary<string, TValue> cd => IsCaseInsensitiveComparer(cd.Comparer),
                FrozenDictionary<string, TValue> fd => IsCaseInsensitiveComparer(fd.Comparer),
                ImmutableDictionary<string, TValue> imd => IsCaseInsensitiveComparer(imd.KeyComparer),
                ReadOnlyDictionary<string, TValue> => false, // ¯\_(ツ)_/¯ - ReadOnlyDictionary doesn't expose its comparer.
                _ => false
            };

            static bool IsCaseInsensitiveComparer(IEqualityComparer<string> comparer)
            {
                return ReferenceEquals(comparer, StringComparer.OrdinalIgnoreCase)
                    || ReferenceEquals(comparer, StringComparer.InvariantCultureIgnoreCase)
                    || comparer.Equals(StringComparer.CurrentCultureIgnoreCase);
            }
        }
    }


    [MemoryDiagnoser]
    public class Benchmark
    {
        [GlobalSetup]
        public void GlobalSetup()
        {
        }

        [Benchmark(Baseline = true)]
        public bool Equals()
        {
            var dict1 = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            var dict2 = new Dictionary<string, string>();
            var dict3 = new Dictionary<string, string>(StringComparer.Ordinal);
            var dict4 = new Dictionary<string, string>(StringComparer.CurrentCultureIgnoreCase);
            var dict5 = new Dictionary<string, string>(StringComparer.CurrentCulture);
            var dict6 = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
            var dict7 = new Dictionary<string, string>(StringComparer.InvariantCulture);
            var dict8 = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase).ToFrozenDictionary();
            var dict9 = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase).ToImmutableDictionary();
            var dict10 = new ConcurrentDictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            var dict11 = new ReadOnlyDictionary<string, string>(new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase));

            return CollectionUtils.IsCaseInsensitive(dict1) &&
                   CollectionUtils.IsCaseInsensitive(dict2) &&
                   CollectionUtils.IsCaseInsensitive(dict3) &&
                   CollectionUtils.IsCaseInsensitive(dict4) &&
                   CollectionUtils.IsCaseInsensitive(dict5) &&
                   CollectionUtils.IsCaseInsensitive(dict6) &&
                   CollectionUtils.IsCaseInsensitive(dict7) &&
                   CollectionUtils.IsCaseInsensitive(dict8) &&
                   CollectionUtils.IsCaseInsensitive(dict9) &&
                   CollectionUtils.IsCaseInsensitive(dict10) &&
                   CollectionUtils.IsCaseInsensitive(dict11);
        }

        [Benchmark]
        public bool ReferenceEquals()
        {
            var dict1 = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            var dict2 = new Dictionary<string, string>();
            var dict3 = new Dictionary<string, string>(StringComparer.Ordinal);
            var dict4 = new Dictionary<string, string>(StringComparer.CurrentCultureIgnoreCase);
            var dict5 = new Dictionary<string, string>(StringComparer.CurrentCulture);
            var dict6 = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
            var dict7 = new Dictionary<string, string>(StringComparer.InvariantCulture);
            var dict8 = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase).ToFrozenDictionary();
            var dict9 = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase).ToImmutableDictionary();
            var dict10 = new ConcurrentDictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            var dict11 = new ReadOnlyDictionary<string, string>(new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase));

            return CollectionUtils.IsCaseInsensitiveReferenceEquals(dict1) &&
                   CollectionUtils.IsCaseInsensitiveReferenceEquals(dict2) &&
                   CollectionUtils.IsCaseInsensitiveReferenceEquals(dict3) &&
                   CollectionUtils.IsCaseInsensitiveReferenceEquals(dict4) &&
                   CollectionUtils.IsCaseInsensitiveReferenceEquals(dict5) &&
                   CollectionUtils.IsCaseInsensitiveReferenceEquals(dict6) &&
                   CollectionUtils.IsCaseInsensitiveReferenceEquals(dict7) &&
                   CollectionUtils.IsCaseInsensitiveReferenceEquals(dict8) &&
                   CollectionUtils.IsCaseInsensitiveReferenceEquals(dict9) &&
                   CollectionUtils.IsCaseInsensitiveReferenceEquals(dict10) &&
                   CollectionUtils.IsCaseInsensitiveReferenceEquals(dict11);
        }
    }
}
