// Copied from https://github.com/MizMahem/Miz.Util.IntExtensions
namespace Miz.Util.IntExtensions;

public static partial class IntExtensions
{
    public static int DigitsLengthLinearSearch(this int number)
    {
        if (number >= 0)
        {
            if (number < 10) return 1;
            if (number < 100) return 2;
            if (number < 1000) return 3;
            if (number < 10000) return 4;
            if (number < 100000) return 5;
            if (number < 1000000) return 6;
            if (number < 10000000) return 7;
            if (number < 100000000) return 8;
            if (number < 1000000000) return 9;
            return 10;
        }
        else
        {
            if (number > -10) return 1;
            if (number > -100) return 2;
            if (number > -1000) return 3;
            if (number > -10000) return 4;
            if (number > -100000) return 5;
            if (number > -1000000) return 6;
            if (number > -10000000) return 7;
            if (number > -100000000) return 8;
            if (number > -1000000000) return 9;
            return 10;
        }
    }

    public static int DigitsLengthBinarySearch(this int number)
    {
        if (number >= 0)
            if (number <= 9999)             // 0 .. 9999
                if (number <= 99)           // 0 .. 99
                    return (number <= 9) ? 1 : 2;
                else                        // 100 .. 9999
                    return (number <= 999) ? 3 : 4;
            else                            // 10000 .. int.MaxValue
                if (number <= 9_999_999)    // 10000 .. 9,999,999
                if (number <= 99_999)
                    return 5;
                else if (number <= 999_999)
                    return 6;
                else
                    return 7;
            else                        // 10,000,000 .. int.MaxValue
                    if (number <= 99_999_999)
                return 8;
            else if (number <= 999_999_999)
                return 9;
            else
                return 10;
        else
            if (number >= -9999)            // -9999 .. -1
            if (number >= -99)          // -99 .. -1
                return (number >= -9) ? 1 : 2;
            else                        // -9999 .. -100
                return (number >= -999) ? 3 : 4;
        else                            // int.MinValue .. -10000
                if (number >= -9_999_999)   // -9,999,999 .. -10000
            if (number >= -99_999)
                return 5;
            else if (number >= -999_999)
                return 6;
            else
                return 7;
        else                        // int.MinValue .. -10,000,000
                    if (number >= -99_999_999)
            return 8;
        else if (number >= -999_999_999)
            return 9;
        else
            return 10;
    }

    public static int DigitsLengthSwitch(this int number) => number switch
    {
        < 10 and > -10 => 1,
        < 100 and > -100 => 2,
        < 1000 and > -1000 => 3,
        < 10000 and > -10000 => 4,
        < 100000 and > -100000 => 5,
        < 1000000 and > -1000000 => 6,
        < 10000000 and > -10000000 => 7,
        < 100000000 and > -100000000 => 8,
        < 1000000000 and > -1000000000 => 9,
        _ => 10
    };
}