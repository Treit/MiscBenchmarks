namespace StringToEnumConversion
{
    using BenchmarkDotNet.Attributes;
    using System;

    public enum PodcastKind
    {
        Friendcast,
        Infocast
    }

    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(100, 10_000)]
        public int Count { get; set; } = 100;

        private string[] _testStrings = null!;
        private Random _random = null!;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _random = new Random(42); // Fixed seed for consistent results
            _testStrings = new string[Count];

            // Create test data with various formats to test both approaches
            string[] baseValues = { "friendcast", "infocast", "FRIENDCAST", "INFOCAST",
                                  "FriendCast", "InfoCast", " friendcast ", "  INFOCAST  ",
                                  "unknown", "", "podcasts", "friend", "info" };

            for (int i = 0; i < Count; i++)
            {
                _testStrings[i] = baseValues[i % baseValues.Length];
            }
        }

        [Benchmark]
        public int ToLowerApproach()
        {
            int friendcastCount = 0;

            for (int i = 0; i < _testStrings.Length; i++)
            {
                var result = ToInternalWithToLower(_testStrings[i]);
                if (result == PodcastKind.Friendcast)
                    friendcastCount++;
            }

            return friendcastCount;
        }

        [Benchmark(Baseline = true)]
        public int SpanApproach()
        {
            int friendcastCount = 0;

            for (int i = 0; i < _testStrings.Length; i++)
            {
                var result = ToInternalWithSpan(_testStrings[i]);
                if (result == PodcastKind.Friendcast)
                    friendcastCount++;
            }

            return friendcastCount;
        }

        [Benchmark]
        public int SpanApproachWithSwitch()
        {
            int friendcastCount = 0;

            for (int i = 0; i < _testStrings.Length; i++)
            {
                var result = ToInternalWithSpanSwitch(_testStrings[i]);
                if (result == PodcastKind.Friendcast)
                    friendcastCount++;
            }

            return friendcastCount;
        }

        [Benchmark]
        public int TryParseApproach()
        {
            int friendcastCount = 0;

            for (int i = 0; i < _testStrings.Length; i++)
            {
                var result = ToInternalWithTryParse(_testStrings[i]);
                if (result == PodcastKind.Friendcast)
                    friendcastCount++;
            }

            return friendcastCount;
        }

        [Benchmark]
        public int TryParseSpanApproach()
        {
            int friendcastCount = 0;

            for (int i = 0; i < _testStrings.Length; i++)
            {
                var result = ToInternalWithTryParseSpan(_testStrings[i]);
                if (result == PodcastKind.Friendcast)
                    friendcastCount++;
            }

            return friendcastCount;
        }

        private static PodcastKind ToInternalWithToLower(string? value) => value?.Trim().ToLowerInvariant() switch
        {
            "friendcast" => PodcastKind.Friendcast,
            "infocast" => PodcastKind.Infocast,
            _ => PodcastKind.Infocast
        };

        private static PodcastKind ToInternalWithSpan(string? value)
        {
            if (value == null)
                return PodcastKind.Infocast;

            var span = value.AsSpan().Trim();

            if (span.Equals("friendcast", StringComparison.OrdinalIgnoreCase))
                return PodcastKind.Friendcast;

            if (span.Equals("infocast", StringComparison.OrdinalIgnoreCase))
                return PodcastKind.Infocast;

            return PodcastKind.Infocast;
        }

    private static PodcastKind ToInternalWithSpanSwitch(string? value)
    {
        if (value == null)
            return PodcastKind.Infocast;

        var span = value.AsSpan().Trim();

        return span switch
        {
            var s when s.Equals("friendcast", StringComparison.OrdinalIgnoreCase) => PodcastKind.Friendcast,
            var s when s.Equals("infocast", StringComparison.OrdinalIgnoreCase) => PodcastKind.Infocast,
            _ => PodcastKind.Infocast
        };
    }

        private static PodcastKind ToInternalWithTryParse(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return PodcastKind.Infocast;

            if (Enum.TryParse<PodcastKind>(value.Trim(), ignoreCase: true, out var result))
                return result;

            return PodcastKind.Infocast;
        }

        private static PodcastKind ToInternalWithTryParseSpan(string? value)
        {
            if (value == null)
                return PodcastKind.Infocast;

            var span = value.AsSpan().Trim();

            if (span.IsEmpty)
                return PodcastKind.Infocast;

            if (Enum.TryParse<PodcastKind>(span, ignoreCase: true, out var result))
                return result;

            return PodcastKind.Infocast;
        }

    }
}
