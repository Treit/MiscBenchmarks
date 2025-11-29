# Building Guids by getting the array either via stackalloc, ArrayPool.Rent or plain old new byte[].





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                          | Job       | Runtime   | Size | Mean       | Error     | StdDev    | Gen0   | Gen1   | Allocated |
|-------------------------------- |---------- |---------- |----- |-----------:|----------:|----------:|-------:|-------:|----------:|
| **TestBuildingGuidsWithStackAlloc** | **.NET 10.0** | **.NET 10.0** | **4**    |   **1.802 μs** | **0.0104 μs** | **0.0087 μs** | **0.0267** |      **-** |     **448 B** |
| TestBuildingGuidsWithArrayPool  | .NET 10.0 | .NET 10.0 | 4    |   1.925 μs | 0.0279 μs | 0.0261 μs | 0.0267 |      - |     448 B |
| TestBuildingGuidsWithNewArray   | .NET 10.0 | .NET 10.0 | 4    |   1.797 μs | 0.0084 μs | 0.0079 μs | 0.0362 |      - |     608 B |
| TestBuildingGuidsWithStackAlloc | .NET 9.0  | .NET 9.0  | 4    |   1.783 μs | 0.0104 μs | 0.0081 μs | 0.0267 |      - |     448 B |
| TestBuildingGuidsWithArrayPool  | .NET 9.0  | .NET 9.0  | 4    |   1.880 μs | 0.0084 μs | 0.0075 μs | 0.0267 |      - |     448 B |
| TestBuildingGuidsWithNewArray   | .NET 9.0  | .NET 9.0  | 4    |   1.785 μs | 0.0098 μs | 0.0091 μs | 0.0362 |      - |     608 B |
| **TestBuildingGuidsWithStackAlloc** | **.NET 10.0** | **.NET 10.0** | **100**  |  **45.269 μs** | **0.3313 μs** | **0.3099 μs** | **0.6714** |      **-** |   **11792 B** |
| TestBuildingGuidsWithArrayPool  | .NET 10.0 | .NET 10.0 | 100  |  49.150 μs | 0.2706 μs | 0.2399 μs | 0.6714 |      - |   11792 B |
| TestBuildingGuidsWithNewArray   | .NET 10.0 | .NET 10.0 | 100  |  44.989 μs | 0.3635 μs | 0.3222 μs | 0.9155 |      - |   15792 B |
| TestBuildingGuidsWithStackAlloc | .NET 9.0  | .NET 9.0  | 100  |  44.904 μs | 0.3282 μs | 0.2740 μs | 0.6714 |      - |   11792 B |
| TestBuildingGuidsWithArrayPool  | .NET 9.0  | .NET 9.0  | 100  |  49.246 μs | 0.3057 μs | 0.2553 μs | 0.6714 |      - |   11792 B |
| TestBuildingGuidsWithNewArray   | .NET 9.0  | .NET 9.0  | 100  |  44.772 μs | 0.2687 μs | 0.2244 μs | 0.9155 |      - |   15792 B |
| **TestBuildingGuidsWithStackAlloc** | **.NET 10.0** | **.NET 10.0** | **1024** | **473.843 μs** | **2.5173 μs** | **2.3547 μs** | **6.3477** |      **-** |  **111304 B** |
| TestBuildingGuidsWithArrayPool  | .NET 10.0 | .NET 10.0 | 1024 | 545.155 μs | 6.3635 μs | 5.9524 μs | 5.8594 |      - |  111304 B |
| TestBuildingGuidsWithNewArray   | .NET 10.0 | .NET 10.0 | 1024 | 477.413 μs | 1.6349 μs | 1.3653 μs | 8.7891 | 0.4883 |  152264 B |
| TestBuildingGuidsWithStackAlloc | .NET 9.0  | .NET 9.0  | 1024 | 479.195 μs | 2.0119 μs | 1.7835 μs | 6.3477 |      - |  111304 B |
| TestBuildingGuidsWithArrayPool  | .NET 9.0  | .NET 9.0  | 1024 | 525.034 μs | 8.0123 μs | 7.1027 μs | 5.8594 |      - |  111304 B |
| TestBuildingGuidsWithNewArray   | .NET 9.0  | .NET 9.0  | 1024 | 474.236 μs | 2.3388 μs | 1.9530 μs | 8.7891 | 0.4883 |  152264 B |
