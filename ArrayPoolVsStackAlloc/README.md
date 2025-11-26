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
| **TestBuildingGuidsWithStackAlloc** | **4**    |   **1.782 μs** | **0.0071 μs** | **0.0063 μs** | **0.0267** |      **-** |     **448 B** |
| TestBuildingGuidsWithArrayPool  | 4    |   1.993 μs | 0.0147 μs | 0.0130 μs | 0.0267 |      - |     448 B |
| TestBuildingGuidsWithNewArray   | 4    |   1.797 μs | 0.0141 μs | 0.0125 μs | 0.0362 |      - |     608 B |
| **TestBuildingGuidsWithStackAlloc** | **100**  |  **45.361 μs** | **0.4033 μs** | **0.3773 μs** | **0.6714** |      **-** |   **11792 B** |
| TestBuildingGuidsWithArrayPool  | 100  |  48.421 μs | 0.2864 μs | 0.2392 μs | 0.6714 |      - |   11792 B |
| TestBuildingGuidsWithNewArray   | 100  |  44.292 μs | 0.3317 μs | 0.2770 μs | 0.9155 |      - |   15792 B |
| **TestBuildingGuidsWithStackAlloc** | **1024** | **473.171 μs** | **0.7288 μs** | **0.5690 μs** | **6.3477** |      **-** |  **111304 B** |
| TestBuildingGuidsWithArrayPool  | 1024 | 524.509 μs | 6.0345 μs | 5.6447 μs | 5.8594 |      - |  111304 B |
| TestBuildingGuidsWithNewArray   | 1024 | 486.822 μs | 3.9270 μs | 3.4812 μs | 8.7891 | 0.4883 |  152264 B |
