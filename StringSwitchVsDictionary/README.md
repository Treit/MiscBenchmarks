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
| **StringSwitchWithToLowerInvariant** | **1000**           |    **591.8 μs** |  **25.86 μs** |  **73.79 μs** |    **574.3 μs** |  **1.01** |    **0.17** |  **132.8125** |  **576000 B** |       **1.000** |
| CaseInsensitiveDictionary        | 1000           |    469.2 μs |  10.83 μs |  30.71 μs |    465.1 μs |  0.80 |    0.11 |         - |         - |       0.000 |
| CaseInsensitiveFrozenDictionary  | 1000           |    229.9 μs |   4.50 μs |   6.31 μs |    230.4 μs |  0.39 |    0.05 |         - |         - |       0.000 |
| EnumTryParseIgnoreCase           | 1000           |  1,927.9 μs |  55.17 μs | 144.36 μs |  1,904.6 μs |  3.30 |    0.45 |         - |       3 B |       0.000 |
|                                  |                |             |           |           |             |       |         |           |           |             |
| **StringSwitchWithToLowerInvariant** | **10000**          |  **5,521.4 μs** | **230.65 μs** | **658.06 μs** |  **5,357.0 μs** |  **1.01** |    **0.16** | **1328.1250** | **5760000 B** |       **1.000** |
| CaseInsensitiveDictionary        | 10000          |  5,176.6 μs | 184.39 μs | 507.86 μs |  5,008.5 μs |  0.95 |    0.14 |         - |         - |       0.000 |
| CaseInsensitiveFrozenDictionary  | 10000          |  2,647.0 μs |  90.99 μs | 263.97 μs |  2,580.3 μs |  0.49 |    0.07 |         - |         - |       0.000 |
| EnumTryParseIgnoreCase           | 10000          | 18,975.8 μs | 371.08 μs | 397.05 μs | 18,991.1 μs |  3.48 |    0.39 |         - |      42 B |       0.000 |
