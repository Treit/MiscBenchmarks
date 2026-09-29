using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Test;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net11_0)]
public class Benchmark
{
    private byte[,] _multiDimensional;
    private byte[][] _jagged;
    private byte[] _flat;
    private byte[][] _compressedDiagonals;
    private int[] _diagonalOffsets;

    [Params(256, 4096)]
    public int Size { get; set; }

    [Params(8, 64)]
    public int DiagonalStride { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        _multiDimensional = new byte[Size, Size];
        _jagged = new byte[Size][];
        _flat = new byte[Size * Size];

        var random = new Random(42);

        for (var row = 0; row < Size; row++)
        {
            var jaggedRow = new byte[Size];
            _jagged[row] = jaggedRow;

            for (var column = 0; column < Size; column++)
            {
                var value = (byte)random.Next(256);
                _multiDimensional[row, column] = value;
                jaggedRow[column] = value;
                _flat[(row * Size) + column] = value;
            }
        }

        var offsets = new List<int>();
        for (var offset = 1; offset < Size; offset += DiagonalStride)
        {
            offsets.Add(offset);
        }

        _diagonalOffsets = offsets.ToArray();
        _compressedDiagonals = new byte[_diagonalOffsets.Length][];

        for (var diagonalIndex = 0; diagonalIndex < _diagonalOffsets.Length; diagonalIndex++)
        {
            var offset = _diagonalOffsets[diagonalIndex];
            var diagonal = new byte[Size - offset];
            _compressedDiagonals[diagonalIndex] = diagonal;

            for (var row = 0; row < diagonal.Length; row++)
            {
                diagonal[row] = _multiDimensional[row, row + offset];
            }
        }
    }

    [Benchmark(Baseline = true)]
    public long SumMultiDimensional()
    {
        var matrix = _multiDimensional;
        var offsets = _diagonalOffsets;
        var size = Size;
        long sum = 0;

        for (var diagonalIndex = 0; diagonalIndex < offsets.Length; diagonalIndex++)
        {
            var offset = offsets[diagonalIndex];
            var length = size - offset;

            for (var row = 0; row < length; row++)
            {
                sum += matrix[row, row + offset];
            }
        }

        return sum;
    }

    [Benchmark]
    public long SumJagged()
    {
        var matrix = _jagged;
        var offsets = _diagonalOffsets;
        var size = Size;
        long sum = 0;

        for (var diagonalIndex = 0; diagonalIndex < offsets.Length; diagonalIndex++)
        {
            var offset = offsets[diagonalIndex];
            var length = size - offset;

            for (var row = 0; row < length; row++)
            {
                sum += matrix[row][row + offset];
            }
        }

        return sum;
    }

    [Benchmark]
    public long SumFlat()
    {
        var matrix = _flat;
        var offsets = _diagonalOffsets;
        var size = Size;
        var indexStride = size + 1;
        long sum = 0;

        for (var diagonalIndex = 0; diagonalIndex < offsets.Length; diagonalIndex++)
        {
            var offset = offsets[diagonalIndex];
            var length = size - offset;
            var index = offset;

            for (var row = 0; row < length; row++)
            {
                sum += matrix[index];
                index += indexStride;
            }
        }

        return sum;
    }

    [Benchmark]
    public long SumCompressedDiagonals()
    {
        var diagonals = _compressedDiagonals;
        long sum = 0;

        for (var diagonalIndex = 0; diagonalIndex < diagonals.Length; diagonalIndex++)
        {
            var diagonal = diagonals[diagonalIndex];

            for (var index = 0; index < diagonal.Length; index++)
            {
                sum += diagonal[index];
            }
        }

        return sum;
    }
}
