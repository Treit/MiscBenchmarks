namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using Miz.Util.IntExtensions;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Numerics;

[MemoryDiagnoser]
public class Benchmark
{
    [Params(100, 1000, 100_000)]
    public int Count { get; set; }

    private List<int> _values;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _values = new List<int>(Count);
        var r = new Random(1234);

        for (int i = 0; i < Count; i++)
        {
            _values.Add(r.Next());
        }
    }

    [Benchmark(Baseline = true)]
    public int CountDigitsUsingMath()
    {
        int total = 0;

        for (int i = 0; i < _values.Count; i++)
        {
            total += NumDigitsUsingMath(_values[i]);
        }

        return total;
    }

    [Benchmark]
    public int CountDigitsUsingMathIncludingFloor()
    {
        int total = 0;

        for (int i = 0; i < _values.Count; i++)
        {
            total += NumDigitsUsingMathIncludingFloor(_values[i]);
        }

        return total;
    }

    [Benchmark]
    public int CountDigitsUsingString()
    {
        int total = 0;

        for (int i = 0; i < _values.Count; i++)
        {
            total += NumDigtsUsingStr(_values[i]);
        }

        return total;
    }

    [Benchmark]
    public int CountDigitsUsingMaxMahem()
    {
        int total = 0;

        for (int i = 0; i < _values.Count; i++)
        {
            // DigitsInLong code written by MaxMahem from the C# discord server.
            total += DigitsInLong(_values[i]);
        }

        return total;
    }

    [Benchmark]
    public int CountDigitsUsingMaxMahemDigitsLengthConditonalLookup()
    {
        int total = 0;

        for (int i = 0; i < _values.Count; i++)
        {
            total += _values[i].DigitsLengthConditonalLookup();
        }

        return total;
    }

    [Benchmark]
    public int CountDigitsUsingLookupTable()
    {
        int total = 0;

        for (int i = 0; i < _values.Count; i++)
        {
            total += NumDigtsUsingLookup(_values[i]);
        }

        return total;
    }

    static int NumDigitsUsingMath(int number)
    {
        return (int)Math.Log10(Math.Abs(number)) + 1;
    }

    static int NumDigitsUsingMathIncludingFloor(int number)
    {
        return (int)Math.Floor(Math.Log10(Math.Abs(number))) + 1;
    }

    static int NumDigtsUsingStr(int number)
    {
        return Math.Abs(number).ToString().Length;
    }

    static int NumDigtsUsingLookup(int number)
    {
        return number.DigitsLength();
    }

    // if lookup for digits in long via binary search.
    static int DigitsInLong(long number)
    {
        number = Math.Abs(number);

        // binary search to find the index indicating the magnitude of number.
        int lowIndex = 0;
        int highIndex = LongDigitPowers.PowersOfTen.Count - 1;

        while (lowIndex <= highIndex)
        {
            // calculate the median (middle) value.
            int median = lowIndex + (highIndex - lowIndex >> 1);

            // compare the number to the index value. If equal (0), it is the index value.
            // if the median index value is less than the number (negative) then the value is above it,
            //   set the low index to the next value beyond the median.
            // if the median index value is greater than the number (positive) then the value is above it,
            //   set the high index to the next value below the median.
            int comparison = LongDigitPowers.PowersOfTen[median].CompareTo(number);
            if (comparison == 0)
                return median + 1;
            if (comparison < 0)
                lowIndex = median + 1;
            else
                highIndex = median - 1;
        }

        return lowIndex;
    }

    public static int CountDigits(uint value)
    {
        int digits = 1;
        if (value >= 100000)
        {
            value /= 100000;
            digits += 5;
        }

        if (value < 10)
        {
            // no-op
        }
        else if (value < 100)
        {
            digits++;
        }
        else if (value < 1000)
        {
            digits += 2;
        }
        else if (value < 10000)
        {
            digits += 3;
        }
        else
        {
            Debug.Assert(value < 100000);
            digits += 4;
        }

        return digits;
    }
}

public static class IntExtensions
{
    public static int DigitsLength(this uint number)
        => (int)((number + Lookups[BitOperations.Log2(number)]) >> 32);

    public static int DigitsLength(this int number)
    {
        if (number >= 0)
        {
            return ((uint)number).DigitsLength();
        }
        else
        {
            return ((uint)-number).DigitsLength() + 1;
        }
    }

    static ulong[] Lookups = {
      4294967296,  8589934582,  8589934582,  8589934582,  12884901788,
      12884901788, 12884901788, 17179868184, 17179868184, 17179868184,
      21474826480, 21474826480, 21474826480, 21474826480, 25769703776,
      25769703776, 25769703776, 30063771072, 30063771072, 30063771072,
      34349738368, 34349738368, 34349738368, 34349738368, 38554705664,
      38554705664, 38554705664, 41949672960, 41949672960, 41949672960,
      42949672960, 42949672960
    };
}

// helper class for holding the value of digit's value times its position, and doing math on it.
// Since these values are constant and not very numerous, it makes sense to cache them.
// They could be statically initialized, but would again defeate the point of the excersize.
internal static class LongDigitPowers
{
    // list of all the digit powers. Should be 190 of them for long.
    // key is 10^(digitPosition-1) + digit, value is digit^position.
    public static IReadOnlyList<long> Values { get; }

    public static IReadOnlyList<long> PowersOfTen { get; }
        = Enumerable.Range(0, MaxLongDigitLength).Select(n => IntPow(10, n)).ToImmutableArray();

    // static constructor. Initializes values for the digit powers.
    static LongDigitPowers()
    {
        // since we know the number of entries we want to produce and are returning an array no point in using Span here.
        long[] digitPowers = new long[MaxLongDigitLength * 10];

        // loop through all digits of a length, calculating digit^digitPosition
        // digitPosition goes from 1 to maxDigitLength,
        // digitIndex goes from 0 to MaxLongDigitLength * 10 - 1
        // unsure if this is faster or doing a Parallel.ForEach or something would be faster.
        for (int digitPosition = 1, digitIndex = 0; digitPosition <= MaxLongDigitLength; digitPosition++)
        {
            digitPowers[digitIndex + 0] = 0;  // power of digit 0 to any power is 0.
            digitPowers[digitIndex + 1] = 1;  // power of digit 1 to any power is 1.
            digitPowers[digitIndex + 2] = IntPow(2, digitPosition);
            digitPowers[digitIndex + 3] = IntPow(3, digitPosition);
            digitPowers[digitIndex + 4] = IntPow(4, digitPosition);
            digitPowers[digitIndex + 5] = IntPow(5, digitPosition);
            digitPowers[digitIndex + 6] = IntPow(6, digitPosition);
            digitPowers[digitIndex + 7] = IntPow(7, digitPosition);
            digitPowers[digitIndex + 8] = IntPow(8, digitPosition);
            digitPowers[digitIndex + 9] = IntPow(9, digitPosition);
            digitIndex = digitPosition * 10;
        }

        Values = digitPowers.ToImmutableArray();
    }

    // faster method for pow of ints.
    public static long IntPow(int value, int pow)
    {
        long result = 1;
        long longValue = value;
        while (pow != 0)
        {
            if ((pow & 1) == 1) result *= longValue;
            longValue *= longValue;
            pow >>= 1;
        }
        return result;
    }

    // the maxium digit length of a long.
    private const int MaxLongDigitLength = 19;
}
