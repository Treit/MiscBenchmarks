# Building Guids by getting the array either via stackalloc, ArrayPool.Rent or plain old new byte[].


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                          Method | Size |       Mean |     Error |    StdDev |   Gen0 |   Gen1 | Allocated |
|-------------------------------- |----- |-----------:|----------:|----------:|-------:|-------:|----------:|
| **TestBuildingGuidsWithStackAlloc** |    **4** |   **1.852 μs** | **0.0034 μs** | **0.0032 μs** | **0.0267** |      **-** |     **448 B** |
|  TestBuildingGuidsWithArrayPool |    4 |   1.950 μs | 0.0115 μs | 0.0108 μs | 0.0267 |      - |     448 B |
|   TestBuildingGuidsWithNewArray |    4 |   1.880 μs | 0.0040 μs | 0.0032 μs | 0.0362 |      - |     608 B |
| **TestBuildingGuidsWithStackAlloc** |  **100** |  **47.187 μs** | **0.0850 μs** | **0.0795 μs** | **0.6714** |      **-** |   **11792 B** |
|  TestBuildingGuidsWithArrayPool |  100 |  48.855 μs | 0.0675 μs | 0.0598 μs | 0.6714 |      - |   11792 B |
|   TestBuildingGuidsWithNewArray |  100 |  47.445 μs | 0.0680 μs | 0.0531 μs | 0.9155 |      - |   15792 B |
| **TestBuildingGuidsWithStackAlloc** | **1024** | **502.383 μs** | **1.5862 μs** | **1.4837 μs** | **5.8594** |      **-** |  **111304 B** |
|  TestBuildingGuidsWithArrayPool | 1024 | 519.085 μs | 0.8720 μs | 0.7730 μs | 5.8594 |      - |  111304 B |
|   TestBuildingGuidsWithNewArray | 1024 | 495.620 μs | 1.3672 μs | 1.2788 μs | 8.7891 | 0.9766 |  152264 B |
