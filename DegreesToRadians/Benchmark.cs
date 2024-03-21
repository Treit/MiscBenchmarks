namespace Test;

using BenchmarkDotNet.Attributes;
using System;
using System.Linq;
using System.Threading;

[MemoryDiagnoser]
public class Benchmark
{
    [Params(10, 100, 10_000)]
    public int IterationCount { get; set; } = 100_000;

    CancellationTokenSource _cts;

    Random _rnd;
    double[] _numbers;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _cts = new CancellationTokenSource();
        _rnd = new Random(1);
        _numbers = new double[IterationCount];
        for (var i = 0; i < IterationCount; i++)
        {
            _numbers[i] = _rnd.NextDouble();
        }
    }

    [Benchmark]
    public double DegreesToRadiansMultiplyFirst()
    {
        var result = 0D;
        foreach (var num in _numbers)
        {
            result += ToRadiansA(num);
        }

        return result;
    }

    [Benchmark(Baseline = true)]
    public double DegreesToRadiansDivideFirst()
    {
        var result = 0D;
        foreach (var num in _numbers)
        {
            result += ToRadiansB(num);
        }

        return result;
    }

    // How .NET does it. More precise. See https://source.dot.net/#System.Private.CoreLib/src/libraries/System.Private.CoreLib/src/System/Numerics/ITrigonometricFunctions.cs,63
    private double ToRadiansA(double degrees)
    {
        return (degrees * Math.PI) / 180.0;
    }

    // Alternative, but less precise. Probably shouldn't be used unless you are really trying to shave cycles.
    private double ToRadiansB(double degrees)
    {
        return degrees * (Math.PI / 180);
    }
}