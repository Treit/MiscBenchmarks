# StringSwitchVsDictionary




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                           | IterationCount | Mean        | Error     | StdDev    | Ratio | RatioSD | Gen0     | Allocated | Alloc Ratio |
|--------------------------------- |--------------- |------------:|----------:|----------:|------:|--------:|---------:|----------:|------------:|
| **StringSwitchWithToLowerInvariant** | **1000**           |    **454.0 μs** |   **8.95 μs** |   **9.19 μs** |  **1.26** |    **0.03** |  **34.1797** |  **576000 B** |          **NA** |
| CaseInsensitiveDictionary        | 1000           |    671.0 μs |   4.54 μs |   4.25 μs |  1.86 |    0.02 |        - |         - |          NA |
| CaseInsensitiveFrozenDictionary  | 1000           |    360.4 μs |   2.78 μs |   2.60 μs |  1.00 |    0.01 |        - |         - |          NA |
| EnumTryParseIgnoreCase           | 1000           |  3,550.9 μs |  18.92 μs |  17.69 μs |  9.85 |    0.08 |        - |       5 B |          NA |
|                                  |                |             |           |           |       |         |          |           |             |
| **StringSwitchWithToLowerInvariant** | **10000**          |  **4,561.3 μs** |  **65.55 μs** |  **61.31 μs** |  **1.27** |    **0.02** | **343.7500** | **5760000 B** |          **NA** |
| CaseInsensitiveDictionary        | 10000          |  6,562.2 μs |  28.61 μs |  23.89 μs |  1.83 |    0.01 |        - |         - |          NA |
| CaseInsensitiveFrozenDictionary  | 10000          |  3,585.0 μs |  12.85 μs |  10.73 μs |  1.00 |    0.00 |        - |         - |          NA |
| EnumTryParseIgnoreCase           | 10000          | 35,319.6 μs | 221.40 μs | 207.10 μs |  9.85 |    0.06 |        - |      89 B |          NA |
