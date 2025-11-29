# StringSwitchVsDictionary





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                           | Job       | Runtime   | IterationCount | Mean        | Error     | StdDev    | Ratio | RatioSD | Gen0     | Allocated | Alloc Ratio |
|--------------------------------- |---------- |---------- |--------------- |------------:|----------:|----------:|------:|--------:|---------:|----------:|------------:|
| **StringSwitchWithToLowerInvariant** | **.NET 10.0** | **.NET 10.0** | **1000**           |    **447.7 μs** |   **6.57 μs** |   **6.15 μs** |  **1.26** |    **0.02** |  **34.1797** |  **576000 B** |          **NA** |
| CaseInsensitiveDictionary        | .NET 10.0 | .NET 10.0 | 1000           |    668.1 μs |   1.27 μs |   1.13 μs |  1.88 |    0.00 |        - |         - |          NA |
| CaseInsensitiveFrozenDictionary  | .NET 10.0 | .NET 10.0 | 1000           |    356.3 μs |   0.46 μs |   0.41 μs |  1.00 |    0.00 |        - |         - |          NA |
| EnumTryParseIgnoreCase           | .NET 10.0 | .NET 10.0 | 1000           |  3,587.3 μs |   4.31 μs |   3.60 μs | 10.07 |    0.01 |        - |       5 B |          NA |
|                                  |           |           |                |             |           |           |       |         |          |           |             |
| StringSwitchWithToLowerInvariant | .NET 9.0  | .NET 9.0  | 1000           |    429.8 μs |   5.14 μs |   4.56 μs |  1.19 |    0.01 |  34.1797 |  576000 B |          NA |
| CaseInsensitiveDictionary        | .NET 9.0  | .NET 9.0  | 1000           |    677.8 μs |   1.59 μs |   1.33 μs |  1.87 |    0.01 |        - |         - |          NA |
| CaseInsensitiveFrozenDictionary  | .NET 9.0  | .NET 9.0  | 1000           |    361.6 μs |   1.95 μs |   1.73 μs |  1.00 |    0.01 |        - |         - |          NA |
| EnumTryParseIgnoreCase           | .NET 9.0  | .NET 9.0  | 1000           |  3,552.2 μs |  11.84 μs |  11.07 μs |  9.82 |    0.05 |        - |       5 B |          NA |
|                                  |           |           |                |             |           |           |       |         |          |           |             |
| **StringSwitchWithToLowerInvariant** | **.NET 10.0** | **.NET 10.0** | **10000**          |  **4,410.5 μs** |  **74.50 μs** |  **69.69 μs** |  **1.23** |    **0.02** | **343.7500** | **5760000 B** |          **NA** |
| CaseInsensitiveDictionary        | .NET 10.0 | .NET 10.0 | 10000          |  6,524.9 μs |  12.88 μs |  12.05 μs |  1.82 |    0.00 |        - |         - |          NA |
| CaseInsensitiveFrozenDictionary  | .NET 10.0 | .NET 10.0 | 10000          |  3,580.5 μs |   3.08 μs |   2.41 μs |  1.00 |    0.00 |        - |         - |          NA |
| EnumTryParseIgnoreCase           | .NET 10.0 | .NET 10.0 | 10000          | 35,186.3 μs | 194.77 μs | 172.66 μs |  9.83 |    0.05 |        - |      89 B |          NA |
|                                  |           |           |                |             |           |           |       |         |          |           |             |
| StringSwitchWithToLowerInvariant | .NET 9.0  | .NET 9.0  | 10000          |  4,454.2 μs |  61.84 μs |  57.85 μs |  1.25 |    0.02 | 343.7500 | 5760000 B |          NA |
| CaseInsensitiveDictionary        | .NET 9.0  | .NET 9.0  | 10000          |  6,672.5 μs |  14.18 μs |  13.26 μs |  1.87 |    0.00 |        - |         - |          NA |
| CaseInsensitiveFrozenDictionary  | .NET 9.0  | .NET 9.0  | 10000          |  3,564.6 μs |   2.38 μs |   1.99 μs |  1.00 |    0.00 |        - |         - |          NA |
| EnumTryParseIgnoreCase           | .NET 9.0  | .NET 9.0  | 10000          | 35,189.5 μs |  98.39 μs |  87.22 μs |  9.87 |    0.02 |        - |      89 B |          NA |
