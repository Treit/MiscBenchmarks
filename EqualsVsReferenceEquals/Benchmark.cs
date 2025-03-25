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
        static Dictionary<string, string> dict1;
        static Dictionary<string, string> dict2;
        static Dictionary<string, string> dict3;
        static Dictionary<string, string> dict4;
        static Dictionary<string, string> dict5;
        static Dictionary<string, string> dict6;
        static Dictionary<string, string> dict7;
        static FrozenDictionary<string, string> dict8;
        static ImmutableDictionary<string, string> dict9;
        static ConcurrentDictionary<string, string> dict10;
        static ReadOnlyDictionary<string, string> dict11;

        [GlobalSetup]
        public void GlobalSetup()
        {
            dict1 = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            dict2 = new Dictionary<string, string>();
            dict3 = new Dictionary<string, string>(StringComparer.Ordinal);
            dict4 = new Dictionary<string, string>(StringComparer.CurrentCultureIgnoreCase);
            dict5 = new Dictionary<string, string>(StringComparer.CurrentCulture);
            dict6 = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
            dict7 = new Dictionary<string, string>(StringComparer.InvariantCulture);
            dict8 = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase).ToFrozenDictionary();
            dict9 = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase).ToImmutableDictionary();
            dict10 = new ConcurrentDictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            dict11 = new ReadOnlyDictionary<string, string>(new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase));
        }

        [Benchmark(Baseline = true)]
        public bool Equals()
        {
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
