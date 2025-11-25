# Getting the string representations of many items by calling ToString() vs. caching the string value.



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                      | Count   | Mean         | Error      | StdDev     | Ratio | Gen0      | Allocated  | Alloc Ratio |
|---------------------------- |-------- |-------------:|-----------:|-----------:|------:|----------:|-----------:|------------:|
| **ProcessDataWithToString**     | **10000**   |    **267.04 μs** |   **2.445 μs** |   **2.168 μs** |  **1.00** |   **32.7148** |   **550416 B** |        **1.00** |
| ProcessDataWithCachedString | 10000   |     71.21 μs |   0.807 μs |   0.755 μs |  0.27 |         - |          - |        0.00 |
|                             |         |              |            |            |       |           |            |             |
| **ProcessDataWithToString**     | **1000000** | **31,102.77 μs** | **146.649 μs** | **137.176 μs** |  **1.00** | **3750.0000** | **63192215 B** |        **1.00** |
| ProcessDataWithCachedString | 1000000 |  7,604.31 μs |   7.383 μs |   6.545 μs |  0.24 |         - |          - |        0.00 |
