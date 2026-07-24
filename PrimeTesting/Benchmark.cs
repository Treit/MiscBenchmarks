using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System.Text.RegularExpressions;

namespace Test;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net10_0)]
public partial class Benchmark
{
    private static readonly int[] s_millerRabinBases = [2, 3, 5, 7, 11];
    private int[] _numbers = [];

    [Params(InputKind.Primes, InputKind.Composites)]
    public InputKind Input { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        var primes = SievePrimes(100);
        _numbers = Input == InputKind.Primes ? primes : CreateCompositeControls(primes);
    }

    [Benchmark]
    public int TrialDivision()
    {
        var primeCount = 0;
        foreach (var number in _numbers)
        {
            if (IsPrimeByTrialDivision(number))
            {
                primeCount++;
            }
        }

        return primeCount;
    }

    [Benchmark]
    public int OddTrialDivision()
    {
        var primeCount = 0;
        foreach (var number in _numbers)
        {
            if (IsPrimeByOddTrialDivision(number))
            {
                primeCount++;
            }
        }

        return primeCount;
    }

    [Benchmark(Baseline = true)]
    public int WheelTrialDivision()
    {
        var primeCount = 0;
        foreach (var number in _numbers)
        {
            if (IsPrimeByWheelTrialDivision(number))
            {
                primeCount++;
            }
        }

        return primeCount;
    }

    [Benchmark]
    public int MillerRabin()
    {
        var primeCount = 0;
        foreach (var number in _numbers)
        {
            if (IsPrimeByMillerRabin(number))
            {
                primeCount++;
            }
        }

        return primeCount;
    }

    [Benchmark]
    public int UnaryRegex()
    {
        var primeCount = 0;
        foreach (var number in _numbers)
        {
            if (number > 1 && !CompositeNumberRegex().IsMatch(new string('1', number)))
            {
                primeCount++;
            }
        }

        return primeCount;
    }

    private static int[] SievePrimes(int count)
    {
        var upperBound = 600;
        var compositeOdds = new bool[(upperBound - 1) / 2];
        for (var candidate = 3; candidate <= upperBound / candidate; candidate += 2)
        {
            if (compositeOdds[(candidate - 3) / 2])
            {
                continue;
            }

            for (var composite = candidate * candidate; composite <= upperBound; composite += 2 * candidate)
            {
                compositeOdds[(composite - 3) / 2] = true;
            }
        }

        var primes = new int[count];
        primes[0] = 2;
        var index = 1;
        for (var candidate = 3; index < primes.Length; candidate += 2)
        {
            if (!compositeOdds[(candidate - 3) / 2])
            {
                primes[index++] = candidate;
            }
        }

        return primes;
    }

    private static int[] CreateCompositeControls(int[] primes)
    {
        var composites = new int[primes.Length];
        for (var index = 0; index < composites.Length; index++)
        {
            composites[index] = primes[index] == 2 ? 4 : primes[index] + 1;
        }

        return composites;
    }

    private static bool IsPrimeByTrialDivision(int number)
    {
        if (number < 2)
        {
            return false;
        }

        for (var divisor = 2; divisor <= number / divisor; divisor++)
        {
            if (number % divisor == 0)
            {
                return false;
            }
        }

        return true;
    }

    private static bool IsPrimeByOddTrialDivision(int number)
    {
        if (number < 2)
        {
            return false;
        }

        if (number % 2 == 0)
        {
            return number == 2;
        }

        for (var divisor = 3; divisor <= number / divisor; divisor += 2)
        {
            if (number % divisor == 0)
            {
                return false;
            }
        }

        return true;
    }

    private static bool IsPrimeByWheelTrialDivision(int number)
    {
        if (number < 2)
        {
            return false;
        }

        if (number % 2 == 0)
        {
            return number == 2;
        }

        if (number % 3 == 0)
        {
            return number == 3;
        }

        for (var divisor = 5; divisor <= number / divisor; divisor += 6)
        {
            if (number % divisor == 0 || number % (divisor + 2) == 0)
            {
                return false;
            }
        }

        return true;
    }

    private static bool IsPrimeByMillerRabin(int number)
    {
        if (number < 2)
        {
            return false;
        }

        if (number % 2 == 0)
        {
            return number == 2;
        }

        var oddFactor = number - 1;
        var powersOfTwo = 0;
        while (oddFactor % 2 == 0)
        {
            oddFactor /= 2;
            powersOfTwo++;
        }

        foreach (var basis in s_millerRabinBases)
        {
            if (basis >= number)
            {
                continue;
            }

            var value = ModularExponentiation(basis, oddFactor, number);
            if (value == 1 || value == number - 1)
            {
                continue;
            }

            var passed = false;
            for (var power = 1; power < powersOfTwo; power++)
            {
                value = value * value % number;
                if (value == number - 1)
                {
                    passed = true;
                    break;
                }
            }

            if (!passed)
            {
                return false;
            }
        }

        return true;
    }

    private static long ModularExponentiation(long basis, int exponent, int modulus)
    {
        var result = 1L;
        var factor = basis % modulus;
        while (exponent > 0)
        {
            if (exponent % 2 != 0)
            {
                result = result * factor % modulus;
            }

            factor = factor * factor % modulus;
            exponent /= 2;
        }

        return result;
    }

    [GeneratedRegex(@"^1?$|^(11+?)\1+$", RegexOptions.CultureInvariant, matchTimeoutMilliseconds: 1_000)]
    private static partial Regex CompositeNumberRegex();
}

public enum InputKind
{
    Primes,
    Composites
}
