# LargeArrayAllocation

Compares three ways to allocate large byte buffers:

- `new byte[...]`
- `GC.AllocateUninitializedArray<byte>`
- `NativeMemory.Alloc`

The benchmark measures allocation latency without reading or writing the allocated memory. It uses 1 MiB and 16 MiB buffers. Each benchmark method allocates eight buffers and retains them until iteration cleanup. BenchmarkDotNet reports the result per allocation through `OperationsPerInvoke`.

`IterationCleanup` frees the native allocations outside the measured operation and releases references to the managed arrays. The job runs each benchmark method once per iteration, so cleanup handles every allocation. BenchmarkDotNet forces a garbage collection after each invocation by default. The garbage collection and native deallocation occur outside the measured operation.

The benchmark answers how quickly each API returns a large buffer when the caller does not require initialized contents. It does not measure the later cost of touching memory pages. `new byte[...]` must return zero-filled memory. `GC.AllocateUninitializedArray<byte>` and `NativeMemory.Alloc` can defer that work.

The run-once-per-iteration configuration is necessary because BenchmarkDotNet has no per-invocation cleanup hook. It also prevents BenchmarkDotNet from automatically increasing the invocation count to reach its recommended 100 ms iteration time. Expect a short-iteration warning. Use the error and standard deviation columns when interpreting close results; differences much larger than their uncertainty remain meaningful.

Run `dotnet run -c Release` to execute the benchmarks.

```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.7376/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.302
  [Host]     : .NET 10.0.10 (10.0.1026.32716), X64 RyuJIT AVX2
  Job-ILQBPD : .NET 10.0.10 (10.0.1026.32716), X64 RyuJIT AVX2

Runtime=.NET 10.0  InvocationCount=1  UnrollFactor=1  

```
| Method                             | Size     | Mean         | Error      | StdDev     | Median       | Ratio | RatioSD |
|----------------------------------- |--------- |-------------:|-----------:|-----------:|-------------:|------:|--------:|
| **AllocateManagedArrays**              | **1048576**  |    **23.493 μs** |  **0.7831 μs** |  **2.1700 μs** |    **22.850 μs** |  **1.01** |    **0.13** |
| AllocateUninitializedManagedArrays | 1048576  |    23.631 μs |  0.6859 μs |  1.9459 μs |    23.238 μs |  1.01 |    0.12 |
| AllocateNativeBuffers              | 1048576  |     5.143 μs |  0.2111 μs |  0.5849 μs |     4.888 μs |  0.22 |    0.03 |
|                                    |          |              |            |            |              |       |         |
| **AllocateManagedArrays**              | **16777216** | **1,096.688 μs** | **21.6794 μs** | **46.6672 μs** | **1,106.644 μs** | **1.002** |    **0.06** |
| AllocateUninitializedManagedArrays | 16777216 |    39.900 μs |  1.1412 μs |  3.2560 μs |    39.619 μs | 0.036 |    0.00 |
| AllocateNativeBuffers              | 16777216 |     6.265 μs |  0.2978 μs |  0.8640 μs |     5.912 μs | 0.006 |    0.00 |
