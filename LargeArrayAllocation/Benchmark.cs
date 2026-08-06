namespace Test;

using System;
using System.Runtime.InteropServices;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;

[RunOncePerIterationJob]
public class Benchmark
{
    private const int AllocationsPerInvoke = 8;
    private readonly byte[][] _managedArrays = new byte[AllocationsPerInvoke][];
    private readonly nint[] _nativeBuffers = new nint[AllocationsPerInvoke];

    [Params(1_048_576, 16_777_216)]
    public int Size { get; set; }

    [Benchmark(Baseline = true, OperationsPerInvoke = AllocationsPerInvoke)]
    public byte[] AllocateManagedArrays()
    {
        for (var i = 0; i < _managedArrays.Length; i++)
        {
            _managedArrays[i] = new byte[Size];
        }

        return _managedArrays[^1];
    }

    [Benchmark(OperationsPerInvoke = AllocationsPerInvoke)]
    public byte[] AllocateUninitializedManagedArrays()
    {
        for (var i = 0; i < _managedArrays.Length; i++)
        {
            _managedArrays[i] = GC.AllocateUninitializedArray<byte>(Size);
        }

        return _managedArrays[^1];
    }

    [Benchmark(OperationsPerInvoke = AllocationsPerInvoke)]
    public unsafe nint AllocateNativeBuffers()
    {
        for (var i = 0; i < _nativeBuffers.Length; i++)
        {
            _nativeBuffers[i] = (nint)NativeMemory.Alloc((nuint)Size);
        }

        return _nativeBuffers[^1];
    }

    [IterationCleanup]
    public unsafe void Cleanup()
    {
        Array.Clear(_managedArrays);

        for (var i = 0; i < _nativeBuffers.Length; i++)
        {
            NativeMemory.Free((void*)_nativeBuffers[i]);
            _nativeBuffers[i] = 0;
        }
    }
}

public class RunOncePerIterationJobAttribute : JobConfigBaseAttribute
{
    public RunOncePerIterationJobAttribute()
        : base(Job.Default
            .WithRuntime(CoreRuntime.Core10_0)
            .RunOncePerIteration())
    {
    }
}
