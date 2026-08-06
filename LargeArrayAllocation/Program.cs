namespace Test;

using System;
using BenchmarkDotNet.Running;

internal class Program
{
    private static void Main()
    {
#if RELEASE
        BenchmarkRunner.Run<Benchmark>();
#else
        var b = new Benchmark
        {
            Size = 1_048_576
        };

        var bytes = b.AllocateByteArrays();
        b.Cleanup();
        var uninitializedBytes = b.AllocateUninitializedByteArrays();
        b.Cleanup();
        var nativeAddress = b.AllocateNativeBuffers();
        b.Cleanup();
        var references = b.AllocateReferenceArrays();
        b.Cleanup();
        var uninitializedReferences = b.AllocateUninitializedReferenceArrays();
        b.Cleanup();
        Console.WriteLine(
            $"{bytes.Length}, {uninitializedBytes.Length}, {nativeAddress != 0}, " +
            $"{references.Length}, {uninitializedReferences.Length}");
#endif
    }
}