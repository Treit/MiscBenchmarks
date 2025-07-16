namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Numerics.Tensors;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[MemoryDiagnoser]
public class Benchmark
{
    private double[] _vec1;
    private double[] _vec2;

    [Params(1000)]
    public int Iterations { get; set; }

    [Params(2, 8, 100, 1024)]
    public int VectorLength { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        _vec1 = Enumerable.Range(0, VectorLength).Select(o => (double)o).ToArray();
        _vec2 = Enumerable.Range(0, VectorLength).Select(o => (double)o).ToArray();
    }

    [Benchmark]
    public double ComputeDistanceLINQ()
    {
        var distance = 0.0D;

        for (int i = 0; i < Iterations; i++)
        {
            distance = ComputeDistance(_vec1, _vec2);
        }

        return distance;
    }

    [Benchmark]
    public double ComputeDistanceNonVectorized()
    {
        var distance = 0.0D;

        for (int i = 0; i < Iterations; i++)
        {
            distance = ComputeDistancePorted(_vec1, _vec2, VectorLength);
        }

        return distance;
    }

    [Benchmark]
    public double ComputeDistanceVectorizedMTreit()
    {
        var distance = 0.0D;

        for (int i = 0; i < Iterations; i++)
        {
            distance = ComputeDistanceVectorized(_vec1, _vec2);
        }

        return distance;
    }

    [Benchmark]
    public double ComputeDistanceVectorizedAaron()
    {
        var distance = 0.0D;

        for (int i = 0; i < Iterations; i++)
        {
            distance = ComputeDistanceVectorizedAaron(_vec1, _vec2);
        }

        return distance;
    }

    [Benchmark(Baseline = true)]
    public double ComputeDistanceVectorizedAaron2()
    {
        var distance = 0.0D;

        for (int i = 0; i < Iterations; i++)
        {
            distance = ComputeDistanceVectorizedAaron2(_vec1, _vec2);
        }

        return distance;
    }

    [Benchmark]
    public double ComputeDistanceTensorPrimitives()
    {
        var distance = 0.0D;

        for (int i = 0; i < Iterations; i++)
        {
            distance = ComputeDistanceTensorPrimitives(_vec1, _vec2);
        }

        return distance;
    }

    public static double ComputeDistance(IList<double> x, IList<double> y)
    {
        var sumXY = x.Zip(y, (o1, o2) => o1 * o2).Sum();
        var sumXX = x.Select(o => o * o).Sum();
        var sumYY = y.Select(o => o * o).Sum();
        return (double)(1 - sumXY / (Math.Sqrt(sumXX) * Math.Sqrt(sumYY) + double.Epsilon));
    }

    double DotProduct(double[] vec1, double[] vec2, int len)
    {
        double dot = 0;
        for (int i = 0; i < len; i++)
        {
            dot += vec1[i] * vec2[i];
        }
        return dot;
    }

    double DotProductWithVectors(double[] vec1, double[] vec2)
    {
        int length = vec1.Length;

        int vectorSize = Vector<double>.Count;
        double dot = 0;

        int i;

        for (i = 0; i <= length - vectorSize; i += vectorSize)
        {
            var v1 = new Vector<double>(vec1, i);
            var v2 = new Vector<double>(vec2, i);
            dot += Vector.Dot(v1, v2);
        }

        for (; i < length; i++)
        {
            dot += vec1[i] * vec2[i];
        }

        return dot;
    }

    double Magnitude(double[] vec, int len)
    {
        double mag = 0;
        for (int i = 0; i < len; i++)
        {
            mag += vec[i] * vec[i];
        }

        return Math.Sqrt(mag);
    }

    public static double MagnitudeWithVectors(double[] vec)
    {
        int len = vec.Length;
        double mag = 0;
        int vectorSize = Vector<double>.Count;
        int i;
        Vector<double> sumVector = Vector<double>.Zero;

        for (i = 0; i <= len - vectorSize; i += vectorSize)
        {
            var v = new Vector<double>(vec, i);
            sumVector += v * v;
        }

        for (int j = 0; j < vectorSize; j++)
        {
            mag += sumVector[j];
        }

        for (; i < len; i++)
        {
            mag += vec[i] * vec[i];
        }

        return Math.Sqrt(mag);
    }

    double ComputeDistancePorted(double[] vec1, double[] vec2, int len)
    {
        double dot = DotProduct(vec1, vec2, len);
        double mag1 = Magnitude(vec1, len);
        double mag2 = Magnitude(vec2, len);
        double distance_const = 1;

        return distance_const - dot / (mag1 * mag2 + 4.94065645841247E-324);
    }

    double ComputeDistanceVectorized(double[] vec1, double[] vec2)
    {
        double dot = DotProductWithVectors(vec1, vec2);
        double mag1 = MagnitudeWithVectors(vec1);
        double mag2 = MagnitudeWithVectors(vec2);
        double distance_const = 1;

        return distance_const - dot / (mag1 * mag2 + 4.94065645841247E-324);
    }

    double ComputeDistanceVectorizedAaron(double[] vec1, double[] vec2)
    {
        double dot = DotProductAaron(vec1, vec2);
        double mag1 = MagnitudeAaron(vec1);
        double mag2 = MagnitudeAaron(vec2);
        double distance_const = 1;

        return distance_const - dot / (mag1 * mag2 + 4.94065645841247E-324);
    }

    private static double MagnitudeAaron(ReadOnlySpan<double> vec)
    {
        ref var first = ref MemoryMarshal.GetReference(vec);
        nint vecLength = vec.Length - vec.Length % Vector<double>.Count;
        var magnitudeV = Vector<double>.Zero;
        nint i;
        for (i = 0; i < vecLength; i += Vector<double>.Count)
        {
            var v = Vector.LoadUnsafe(ref Unsafe.Add(ref first, i));
            magnitudeV += v * v;
        }
        var magnitude = Vector.Sum(magnitudeV);
        for (; i < vec.Length; i++)
        {
            var e = Unsafe.Add(ref first, i);
            magnitude += e * e;
        }
        return double.Sqrt(magnitude);
    }

    private static double DotProductAaron(ReadOnlySpan<double> vec1, ReadOnlySpan<double> vec2)
    {
        ref var first = ref MemoryMarshal.GetReference(vec1);
        ref var second = ref MemoryMarshal.GetReference(vec2);
        nint vecLength = vec2.Length - vec2.Length % Vector<double>.Count;
        var dotV = Vector<double>.Zero;
        nint i;
        for (i = 0; i < vecLength; i += Vector<double>.Count)
        {
            var v1 = Vector.LoadUnsafe(ref Unsafe.Add(ref first, i));
            var v2 = Vector.LoadUnsafe(ref Unsafe.Add(ref second, i));
            dotV += v1 * v2;
        }
        var dot = Vector.Sum(dotV);
        for (; i < vec1.Length; i++)
        {
            var e = Unsafe.Add(ref first, i);
            dot += e * e;
        }
        return dot;
    }

    private static double ComputeDistanceVectorizedAaron2(ReadOnlySpan<double> vec1, ReadOnlySpan<double> vec2)
    {
        ref var first1 = ref MemoryMarshal.GetReference(vec1);
        ref var first2 = ref MemoryMarshal.GetReference(vec2);
        nint vecLength = vec1.Length - vec1.Length % Vector<double>.Count;
        var magnitudeV1 = Vector<double>.Zero;
        var magnitudeV2 = Vector<double>.Zero;
        var dotV = Vector<double>.Zero;
        nint i;
        for (i = 0; i < vecLength; i += Vector<double>.Count)
        {
            var v1 = Vector.LoadUnsafe(ref Unsafe.Add(ref first1, i));
            var v2 = Vector.LoadUnsafe(ref Unsafe.Add(ref first2, i));
            magnitudeV1 += v1 * v1;
            magnitudeV2 += v2 * v2;
            dotV += v1 * v2;
        }
        var magnitude1 = Vector.Sum(magnitudeV1);
        var magnitude2 = Vector.Sum(magnitudeV2);
        var dot = Vector.Sum(dotV);
        for (; i < vec1.Length; i++)
        {
            var e1 = Unsafe.Add(ref first1, i);
            var e2 = Unsafe.Add(ref first2, i);
            magnitude1 += e1 * e1;
            magnitude2 += e2 * e2;
            dot += e1 * e2;
        }

        return 1d - dot / (double.Sqrt(magnitude1) * double.Sqrt(magnitude2) + double.Epsilon);
    }
    private static double ComputeDistanceTensorPrimitives(ReadOnlySpan<double> vec1, ReadOnlySpan<double> vec2)
    {
        var dot = TensorPrimitives.Dot(vec1, vec2);
        var magA = double.Sqrt(TensorPrimitives.SumOfSquares(vec1));
        var magB = double.Sqrt(TensorPrimitives.SumOfSquares(vec2));

        return 1 - dot / (magA * magB + double.Epsilon);
    }
}
