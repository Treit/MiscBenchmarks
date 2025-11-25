# Building Guids by getting the array either via stackalloc, ArrayPool.Rent or plain old new byte[].



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                          | Size | Mean       | Error     | StdDev    | Gen0   | Gen1   | Allocated |
|-------------------------------- |----- |-----------:|----------:|----------:|-------:|-------:|----------:|
| **TestBuildingGuidsWithStackAlloc** | **4**    |   **1.776 μs** | **0.0327 μs** | **0.0290 μs** | **0.0267** |      **-** |     **448 B** |
| TestBuildingGuidsWithArrayPool  | 4    |   1.887 μs | 0.0189 μs | 0.0168 μs | 0.0267 |      - |     448 B |
| TestBuildingGuidsWithNewArray   | 4    |   1.775 μs | 0.0083 μs | 0.0073 μs | 0.0362 |      - |     608 B |
| **TestBuildingGuidsWithStackAlloc** | **100**  |  **45.421 μs** | **0.2374 μs** | **0.2104 μs** | **0.6714** |      **-** |   **11792 B** |
| TestBuildingGuidsWithArrayPool  | 100  |  49.128 μs | 0.2858 μs | 0.2387 μs | 0.6714 |      - |   11792 B |
| TestBuildingGuidsWithNewArray   | 100  |  45.390 μs | 0.2951 μs | 0.2760 μs | 0.9155 |      - |   15792 B |
| **TestBuildingGuidsWithStackAlloc** | **1024** | **475.094 μs** | **1.1170 μs** | **0.8721 μs** | **6.3477** |      **-** |  **111304 B** |
| TestBuildingGuidsWithArrayPool  | 1024 | 513.878 μs | 7.3071 μs | 6.8351 μs | 5.8594 |      - |  111304 B |
| TestBuildingGuidsWithNewArray   | 1024 | 472.191 μs | 1.7989 μs | 1.5947 μs | 8.7891 | 0.4883 |  152264 B |
