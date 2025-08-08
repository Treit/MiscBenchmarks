# StringSwitchVsDictionary



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.27919.1000)
Unknown processor
.NET SDK 10.0.100-preview.6.25358.103
  [Host]     : .NET 10.0.0 (10.0.25.35903), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 10.0.0 (10.0.25.35903), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                           | IterationCount | Mean        | Error     | StdDev    | Median      | Ratio | RatioSD | Gen0      | Allocated | Alloc Ratio |
|--------------------------------- |--------------- |------------:|----------:|----------:|------------:|------:|--------:|----------:|----------:|------------:|
| **StringSwitchWithToLowerInvariant** | **1000**           |    **571.3 μs** |  **13.40 μs** |  **38.67 μs** |    **564.8 μs** |  **2.28** |    **0.21** |  **132.8125** |  **576000 B** |          **NA** |
| CaseInsensitiveDictionary        | 1000           |    473.5 μs |  10.06 μs |  29.35 μs |    467.4 μs |  1.89 |    0.17 |         - |         - |          NA |
| CaseInsensitiveFrozenDictionary  | 1000           |    251.5 μs |   5.92 μs |  16.69 μs |    249.0 μs |  1.00 |    0.09 |         - |         - |          NA |
| EnumTryParseIgnoreCase           | 1000           |  1,895.8 μs |  37.50 μs |  78.27 μs |  1,881.9 μs |  7.57 |    0.58 |         - |       3 B |          NA |
|                                  |                |             |           |           |             |       |         |           |           |             |
| **StringSwitchWithToLowerInvariant** | **10000**          |  **5,234.7 μs** | **128.18 μs** | **361.53 μs** |  **5,108.9 μs** |  **2.17** |    **0.18** | **1328.1250** | **5760000 B** |          **NA** |
| CaseInsensitiveDictionary        | 10000          |  4,746.5 μs | 142.57 μs | 404.44 μs |  4,633.4 μs |  1.97 |    0.19 |         - |         - |          NA |
| CaseInsensitiveFrozenDictionary  | 10000          |  2,414.9 μs |  47.19 μs | 126.78 μs |  2,376.2 μs |  1.00 |    0.07 |         - |         - |          NA |
| EnumTryParseIgnoreCase           | 10000          | 17,781.7 μs | 348.94 μs | 489.17 μs | 17,608.0 μs |  7.38 |    0.42 |         - |      42 B |          NA |
