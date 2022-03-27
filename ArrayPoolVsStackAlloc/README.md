# Building Guids by getting the array either via stackalloc, ArrayPool.Rent or plain old new byte[].

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22000
AMD Ryzen Threadripper 3960X, 1 CPU, 48 logical and 24 physical cores
.NET Core SDK=6.0.100-rc.2.21505.57
  [Host]     : .NET Core 6.0.0 (CoreCLR 6.0.21.48005, CoreFX 6.0.21.48005), X64 RyuJIT
  DefaultJob : .NET Core 6.0.0 (CoreCLR 6.0.21.48005, CoreFX 6.0.21.48005), X64 RyuJIT


```
|                          Method | Size |       Mean |     Error |    StdDev |   Gen 0 |  Gen 1 | Gen 2 | Allocated |
|-------------------------------- |----- |-----------:|----------:|----------:|--------:|-------:|------:|----------:|
| **TestBuildingGuidsWithStackAlloc** |    **4** |   **1.667 μs** | **0.0055 μs** | **0.0046 μs** |  **0.0534** |      **-** |     **-** |     **448 B** |
|  TestBuildingGuidsWithArrayPool |    4 |   1.757 μs | 0.0062 μs | 0.0058 μs |  0.0534 |      - |     - |     448 B |
|   TestBuildingGuidsWithNewArray |    4 |   1.663 μs | 0.0086 μs | 0.0081 μs |  0.0725 |      - |     - |     608 B |
| **TestBuildingGuidsWithStackAlloc** |  **100** |  **42.292 μs** | **0.4072 μs** | **0.3610 μs** |  **1.4038** |      **-** |     **-** |   **11792 B** |
|  TestBuildingGuidsWithArrayPool |  100 |  43.903 μs | 0.2123 μs | 0.1882 μs |  1.4038 |      - |     - |   11792 B |
|   TestBuildingGuidsWithNewArray |  100 |  42.502 μs | 0.2209 μs | 0.1958 μs |  1.8311 |      - |     - |   15792 B |
| **TestBuildingGuidsWithStackAlloc** | **1024** | **435.729 μs** | **1.6643 μs** | **1.4754 μs** | **13.1836** | **1.4648** |     **-** |  **111304 B** |
|  TestBuildingGuidsWithArrayPool | 1024 | 464.625 μs | 3.2301 μs | 2.8634 μs | 13.1836 | 1.4648 |     - |  111304 B |
|   TestBuildingGuidsWithNewArray | 1024 | 438.944 μs | 2.2311 μs | 1.9778 μs | 18.0664 | 1.9531 |     - |  152264 B |
