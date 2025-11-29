namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using System;
using System.Buffers;
using System.Collections.Generic;
using BenchmarkDotNet.Jobs;

[MemoryDiagnoser]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    [Params(10, 1000)]
    public int Count { get; set; }

    private List<string> _values;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _values = new List<string>(Count);

        for (int i = 0; i < Count; i++)
        {
            if (i % 7 == 0)
            {
                _values.Add($"Some Value {i} - Deck");
            }
            else if (i % 8 == 0)
            {
                _values.Add($"Some Value {i} - deck");
            }
            else
            {
                _values.Add($"Some Value {i}");
            }
        }
    }

    [Benchmark(Baseline = true)]
    public long CountUsingTwoChecks()
    {
        long total = 0;

        for (int i = 0; i < Count; i++)
        {
            if (_values[i].Contains("Deck") || _values[i].Contains("deck"))
            {
                total++;
            }
        }

        return total;
    }

    [Benchmark]
    public long CountKuinox()
    {
        long total = 0;

        for (int i = 0; i < Count; i++)
        {
            if (DoesStringContainDeck(_values[i]))
            {
                total++;
            }
        }

        return total;

        static bool DoesStringContainDeck(string theString)
        {
            var reader = new SequenceReader<char>(new ReadOnlySequence<char>(theString.AsMemory()));

            while (!reader.End)
            {
                if (!reader.TryAdvanceToAny("dD")) return false;
                var unread = reader.UnreadSpan[0..3];
                if (unread.SequenceEqual("eck")) return true;
            }
            return false;
        }
    }

    [Benchmark]
    public long CountKuinoxSecondVersion()
    {
        long total = 0;

        for (int i = 0; i < Count; i++)
        {
            if (DoesStringContainDeck2(_values[i]))
            {
                total++;
            }
        }

        return total;

        bool DoesStringContainDeck2(string theString)
        {
            var reader = new SequenceReader<char>(new ReadOnlySequence<char>(theString.AsMemory()));

            while (!reader.End)
            {
                if (!reader.TryAdvanceTo('e')) return false;
                var previousChar = reader.CurrentSpan[(int)reader.Consumed - 1];
                if (previousChar != 'd' && previousChar != 'D') continue;
                var unread = reader.UnreadSpan[0..2];
                if (unread.SequenceEqual("ck")) return true;
            }
            return false;
        }
    }

    [Benchmark]
    public long CountUsingOrdinalIgnoreCase()
    {
        long total = 0;

        for (int i = 0; i < Count; i++)
        {
            if (_values[i].Contains("Deck", StringComparison.OrdinalIgnoreCase))
            {
                total++;
            }
        }

        return total;
    }

    [Benchmark]
    public long CountUsingInvariantCultureIgnoreCase()
    {
        long total = 0;

        for (int i = 0; i < Count; i++)
        {
            if (_values[i].Contains("Deck", StringComparison.InvariantCultureIgnoreCase))
            {
                total++;
            }
        }

        return total;
    }

    [Benchmark]
    public long CountUsingCurrentCultureIgnoreCase()
    {
        long total = 0;

        for (int i = 0; i < Count; i++)
        {
            if (_values[i].Contains("Deck", StringComparison.CurrentCultureIgnoreCase))
            {
                total++;
            }
        }

        return total;
    }
}
