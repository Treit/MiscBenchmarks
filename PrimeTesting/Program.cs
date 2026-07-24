using BenchmarkDotNet.Running;
using System;

namespace Test;

internal static class Program
{
    private static void Main()
    {
#if RELEASE
        BenchmarkRunner.Run<Benchmark>();
#else
        var benchmark = new Benchmark();
        foreach (var input in Enum.GetValues<InputKind>())
        {
            benchmark.Input = input;
            benchmark.GlobalSetup();
            var expectedPrimeCount = input == InputKind.Primes ? 100 : 0;
            if (benchmark.TrialDivision() != expectedPrimeCount ||
                benchmark.OddTrialDivision() != expectedPrimeCount ||
                benchmark.WheelTrialDivision() != expectedPrimeCount ||
                benchmark.MillerRabin() != expectedPrimeCount ||
                benchmark.UnaryRegex() != expectedPrimeCount)
            {
                throw new InvalidOperationException($"Prime tests disagreed for {input}.");
            }
        }
#endif
    }
}
