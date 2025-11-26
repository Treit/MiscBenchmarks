# Getting the string representations of many items by calling ToString() vs. caching the string value.




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                      | Count   | Mean         | Error      | StdDev     | Ratio | RatioSD | Gen0      | Allocated  | Alloc Ratio |
|---------------------------- |-------- |-------------:|-----------:|-----------:|------:|--------:|----------:|-----------:|------------:|
| **ProcessDataWithToString**     | **10000**   |    **278.99 μs** |   **2.346 μs** |   **1.959 μs** |  **1.00** |    **0.01** |   **32.7148** |   **550416 B** |        **1.00** |
| ProcessDataWithCachedString | 10000   |     70.54 μs |   0.569 μs |   0.504 μs |  0.25 |    0.00 |         - |          - |        0.00 |
|                             |         |              |            |            |       |         |           |            |             |
| **ProcessDataWithToString**     | **1000000** | **32,041.09 μs** | **400.995 μs** | **375.091 μs** |  **1.00** |    **0.02** | **3750.0000** | **63192230 B** |        **1.00** |
| ProcessDataWithCachedString | 1000000 |  7,570.75 μs |  20.230 μs |  17.933 μs |  0.24 |    0.00 |         - |          - |        0.00 |
