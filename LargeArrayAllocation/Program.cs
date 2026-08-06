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

        var managed = b.AllocateManagedArrays();
        b.Cleanup();
        var uninitialized = b.AllocateUninitializedManagedArrays();
        b.Cleanup();
        var nativeAddress = b.AllocateNativeBuffers();
        b.Cleanup();
        Console.WriteLine($"{managed.Length}, {uninitialized.Length}, {nativeAddress != 0}");
#endif
    }
}