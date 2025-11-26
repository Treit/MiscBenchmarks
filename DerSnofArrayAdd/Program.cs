using System;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Jobs;

public class ArraySumBenchmark
{
    private long[] _array;

    [GlobalSetup]
    public void Setup()
    {
        // Initialize a large array for benchmarking
        _array = new long[1_000_000];
        for (int i = 0; i < _array.Length; i++)
        {
            _array[i] = i;
        }
    }

    [Benchmark]
    public long DerSnofSumArrayManaged()
    {
        long sum = 0;
        for (int i = 0; i < _array.Length; i++)
        {
            sum += _array[i];
        }
        return sum;
    }
    
    [Benchmark]
    public unsafe long DerSnofSumArrayUnsafe()
    {
        long sum = 0;
        fixed (long* ptr = _array) // Pin the array in memory
        {
            long* current = ptr;
            for (int i = 0; i < _array.Length; i++)
            {
                sum += *current; // Dereference the pointer
                current++;       // Move to the next element
            }
        }
        return sum;
    }


    [Benchmark]
    public long ArraySumLinq()
    {
        return _array.Sum();
    }
}

class Program
{
    static void Main(string[] args)
    {
        var b = new ArraySumBenchmark();
        b.Setup();
        var first = b.ArraySumLinq();
        var second = b.DerSnofSumArrayManaged();
        var third = b.DerSnofSumArrayUnsafe();
        Console.WriteLine(first);
        Console.WriteLine(second);
        Console.WriteLine(third);
        // Run the benchmark
        BenchmarkRunner.Run<ArraySumBenchmark>();
    }
}