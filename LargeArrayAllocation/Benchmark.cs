namespace Test;

using System;
using System.Runtime.InteropServices;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;

[RunOncePerIterationJob]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[CategoriesColumn]
public class Benchmark
{
    private const int AllocationsPerInvoke = 8;
    private readonly byte[][] _byteArrays = new byte[AllocationsPerInvoke][];
    private readonly object[][] _referenceArrays = new object[AllocationsPerInvoke][];
    private readonly nint[] _nativeBuffers = new nint[AllocationsPerInvoke];

    [Params(1_048_576, 16_777_216)]
    public int Size { get; set; }

    [Benchmark(Baseline = true, OperationsPerInvoke = AllocationsPerInvoke)]
    [BenchmarkCategory("Byte")]
    public byte[] AllocateByteArrays()
    {
        for (var i = 0; i < _byteArrays.Length; i++)
        {
            _byteArrays[i] = new byte[Size];
        }

        return _byteArrays[^1];
    }

    [Benchmark(OperationsPerInvoke = AllocationsPerInvoke)]
    [BenchmarkCategory("Byte")]
    public byte[] AllocateUninitializedByteArrays()
    {
        for (var i = 0; i < _byteArrays.Length; i++)
        {
            _byteArrays[i] = GC.AllocateUninitializedArray<byte>(Size);
        }

        return _byteArrays[^1];
    }

    [Benchmark(OperationsPerInvoke = AllocationsPerInvoke)]
    [BenchmarkCategory("Byte")]
    public unsafe nint AllocateNativeBuffers()
    {
        for (var i = 0; i < _nativeBuffers.Length; i++)
        {
            _nativeBuffers[i] = (nint)NativeMemory.Alloc((nuint)Size);
        }

        return _nativeBuffers[^1];
    }

    [Benchmark(Baseline = true, OperationsPerInvoke = AllocationsPerInvoke)]
    [BenchmarkCategory("Reference")]
    public object[] AllocateReferenceArrays()
    {
        var elementCount = Size / IntPtr.Size;

        for (var i = 0; i < _referenceArrays.Length; i++)
        {
            _referenceArrays[i] = new object[elementCount];
        }

        return _referenceArrays[^1];
    }

    [Benchmark(OperationsPerInvoke = AllocationsPerInvoke)]
    [BenchmarkCategory("Reference")]
    public object[] AllocateUninitializedReferenceArrays()
    {
        var elementCount = Size / IntPtr.Size;

        for (var i = 0; i < _referenceArrays.Length; i++)
        {
            _referenceArrays[i] = GC.AllocateUninitializedArray<object>(elementCount);
        }

        return _referenceArrays[^1];
    }

    [IterationCleanup]
    public unsafe void Cleanup()
    {
        Array.Clear(_byteArrays);
        Array.Clear(_referenceArrays);

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
