# LargeArrayAllocation

Compares three ways to allocate large byte buffers:

- `new byte[...]`
- `GC.AllocateUninitializedArray<byte>`
- `NativeMemory.Alloc`

It also compares two ways to allocate arrays of references:

- `new object[...]`
- `GC.AllocateUninitializedArray<object>`

The benchmark measures allocation latency without reading or writing the allocated memory. It uses buffers with approximately 1 MiB and 16 MiB of element storage. Reference arrays divide the requested byte size by the native pointer size so their element storage matches the byte arrays. Each benchmark method allocates eight buffers and retains them until iteration cleanup. BenchmarkDotNet reports the result per allocation through `OperationsPerInvoke`.

`IterationCleanup` frees the native allocations outside the measured operation and releases references to the managed arrays. The job runs each benchmark method once per iteration, so cleanup handles every allocation. BenchmarkDotNet forces a garbage collection after each invocation by default. The garbage collection and native deallocation occur outside the measured operation.

The benchmark answers how quickly each API returns a large buffer when the caller does not require initialized contents. It does not measure the later cost of touching memory pages. `new byte[...]` must return zero-filled memory. `GC.AllocateUninitializedArray<byte>` and `NativeMemory.Alloc` can defer that work. Arrays containing references must remain zero-initialized so the garbage collector never observes invalid object references. For this reason, `GC.AllocateUninitializedArray<object>` does not skip initialization.

There is no native reference-array variant. Raw unmanaged memory does not provide managed array semantics and cannot safely store garbage-collected object references without a separate lifetime and pinning design.

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
| Method                               | Categories | Size     | Mean         | Error      | StdDev     | Ratio | RatioSD |
|------------------------------------- |----------- |--------- |-------------:|-----------:|-----------:|------:|--------:|
| **AllocateByteArrays**                   | **Byte**       | **1048576**  |    **23.336 μs** |  **0.6173 μs** |  **1.7309 μs** |  **1.01** |    **0.10** |
| AllocateUninitializedByteArrays      | Byte       | 1048576  |    22.778 μs |  0.6361 μs |  1.8045 μs |  0.98 |    0.10 |
| AllocateNativeBuffers                | Byte       | 1048576  |     4.823 μs |  0.0916 μs |  0.0715 μs |  0.21 |    0.02 |
|                                      |            |          |              |            |            |       |         |
| **AllocateByteArrays**                   | **Byte**       | **16777216** | **1,055.792 μs** | **21.0047 μs** | **37.8758 μs** | **1.001** |    **0.05** |
| AllocateUninitializedByteArrays      | Byte       | 16777216 |    40.698 μs |  1.4893 μs |  4.3206 μs | 0.039 |    0.00 |
| AllocateNativeBuffers                | Byte       | 16777216 |     6.125 μs |  0.1223 μs |  0.2860 μs | 0.006 |    0.00 |
|                                      |            |          |              |            |            |       |         |
| **AllocateReferenceArrays**              | **Reference**  | **1048576**  |   **185.995 μs** |  **6.0043 μs** | **17.4196 μs** |  **1.01** |    **0.13** |
| AllocateUninitializedReferenceArrays | Reference  | 1048576  |   192.667 μs |  3.8077 μs |  4.3849 μs |  1.05 |    0.10 |
|                                      |            |          |              |            |            |       |         |
| **AllocateReferenceArrays**              | **Reference**  | **16777216** | **2,186.622 μs** | **43.6099 μs** | **62.5440 μs** |  **1.00** |    **0.04** |
| AllocateUninitializedReferenceArrays | Reference  | 16777216 | 2,146.943 μs | 41.4396 μs | 50.8916 μs |  0.98 |    0.04 |
