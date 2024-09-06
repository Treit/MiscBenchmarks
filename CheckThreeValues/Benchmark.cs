namespace Test
{
    using System;
    using System.Collections.Generic;
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;

    record UserProfile(string Name, string Culture);

    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(1000)]
        public int Count { get; set; }

        private static List<UserProfile> s_userProfiles;

        private static readonly string[] s_cultures =
        {
            "en-us", "en-gb", "fr-fr", "de-de", "es-es", "it-it",
            "zh-cn", "ja-jp", "ko-kr", "pt-br", "ru-ru", "tr-tr"

        };

        [GlobalSetup]
        public void GlobalSetup()
        {
            s_userProfiles = new List<UserProfile>(Count);
            var random = new Random(Count);

            for (int i = 0; i < Count; i++)
            {
                s_userProfiles.Add(new UserProfile($"User{i}", s_cultures[random.Next(s_cultures.Length)]));
            }
        }

        [Benchmark]
        public int CheckWithArray()
        {
            var matches = 0;
            var cultures = new string[] { "zh-cn", "ja-jp", "ko-kr" };

            foreach (var userProfile in s_userProfiles)
            {
                if (Array.Exists(cultures, c => string.Equals(c, userProfile.Culture, StringComparison.OrdinalIgnoreCase)))
                {
                    matches++;
                }
            }

            return matches;
        }

        [Benchmark(Baseline = true)]
        public int CheckWithSimpleIf()
        {
            var matches = 0;

            foreach (var userProfile in s_userProfiles)
            {
                if (userProfile.Culture.Equals("zh-cn", StringComparison.OrdinalIgnoreCase)
                    || userProfile.Culture.Equals("ja-jp", StringComparison.OrdinalIgnoreCase)
                    || userProfile.Culture.Equals("ko-kr", StringComparison.OrdinalIgnoreCase))
                {
                    matches++;
                }
            }

            return matches;
        }
    }
}
