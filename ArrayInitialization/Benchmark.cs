namespace Test;
using BenchmarkDotNet.Attributes;
using System;
using System.Runtime.InteropServices;

public class Benchmark
{
    private byte[,] _mdim;
    private byte[][] _jagged;

    [Params(100, 1024)]
    public int Size { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
    }

    [Benchmark]
    public void InitJaggedRandomValues()
    {
        var r = new Random(Size);

        _jagged = new byte[Size][];

        for (int i = 0; i < Size; i++)
        {
            _jagged[i] = new byte[Size];

            for (int j = 0; j < Size; j++)
            {
                byte b = (byte)r.Next(256);
                _jagged[i][j] = b;
            }
        }
    }

    [Benchmark]
    public void InitMultidimensionalRandomValues()
    {
        var r = new Random(Size);

        _mdim = new byte[Size, Size];

        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
            {
                byte b = (byte)r.Next(256);
                _mdim[i, j] = b;
            }
        }
    }

    [Benchmark]
    public void InitJaggedFixedValue()
    {
        _jagged = new byte[Size][];

        for (int i = 0; i < Size; i++)
        {
            _jagged[i] = new byte[Size];

            for (int j = 0; j < Size; j++)
            {
                _jagged[i][j] = 0xFF;
            }
        }
    }

    [Benchmark]
    public void InitMultidimensionalFixedValue()
    {
        _mdim = new byte[Size, Size];

        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
            {
                _mdim[i, j] = 0xFF;
            }
        }
    }
}
