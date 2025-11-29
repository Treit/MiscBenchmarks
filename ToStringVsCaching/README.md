# Getting the string representations of many items by calling ToString() vs. caching the string value.





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                      | Job       | Runtime   | Count   | Mean         | Error      | StdDev     | Ratio | Gen0      | Allocated  | Alloc Ratio |
|---------------------------- |---------- |---------- |-------- |-------------:|-----------:|-----------:|------:|----------:|-----------:|------------:|
| **ProcessDataWithToString**     | **.NET 10.0** | **.NET 10.0** | **10000**   |    **266.14 μs** |   **2.098 μs** |   **1.963 μs** |  **1.00** |   **32.7148** |   **550416 B** |        **1.00** |
| ProcessDataWithCachedString | .NET 10.0 | .NET 10.0 | 10000   |     70.35 μs |   0.090 μs |   0.070 μs |  0.26 |         - |          - |        0.00 |
|                             |           |           |         |              |            |            |       |           |            |             |
| ProcessDataWithToString     | .NET 9.0  | .NET 9.0  | 10000   |    281.37 μs |   3.020 μs |   2.825 μs |  1.00 |   32.7148 |   550416 B |        1.00 |
| ProcessDataWithCachedString | .NET 9.0  | .NET 9.0  | 10000   |     70.33 μs |   0.232 μs |   0.206 μs |  0.25 |         - |          - |        0.00 |
|                             |           |           |         |              |            |            |       |           |            |             |
| **ProcessDataWithToString**     | **.NET 10.0** | **.NET 10.0** | **1000000** | **30,816.55 μs** | **111.224 μs** | **104.039 μs** |  **1.00** | **3750.0000** | **63192215 B** |        **1.00** |
| ProcessDataWithCachedString | .NET 10.0 | .NET 10.0 | 1000000 |  7,164.44 μs |  11.827 μs |  11.063 μs |  0.23 |         - |          - |        0.00 |
|                             |           |           |         |              |            |            |       |           |            |             |
| ProcessDataWithToString     | .NET 9.0  | .NET 9.0  | 1000000 | 30,860.46 μs | 106.256 μs |  94.194 μs |  1.00 | 3750.0000 | 63192215 B |        1.00 |
| ProcessDataWithCachedString | .NET 9.0  | .NET 9.0  | 1000000 |  8,276.64 μs |  24.047 μs |  20.080 μs |  0.27 |         - |          - |        0.00 |
