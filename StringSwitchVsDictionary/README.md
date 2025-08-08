# StringSwitchVsDictionary

```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.27919.1000)
Unknown processor
.NET SDK 10.0.100-preview.6.25358.103
  [Host]     : .NET 10.0.0 (10.0.25.35903), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 10.0.0 (10.0.25.35903), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                           | IterationCount | Mean       | Error     | StdDev    | Median     | Ratio | RatioSD | Gen0      | Allocated | Alloc Ratio |
|--------------------------------- |--------------- |-----------:|----------:|----------:|-----------:|------:|--------:|----------:|----------:|------------:|
| **StringSwitchWithToLowerInvariant** | **1000**           |   **547.4 μs** |  **16.50 μs** |  **48.39 μs** |   **539.0 μs** |  **1.01** |    **0.12** |  **132.8125** |  **576000 B** |        **1.00** |
| CaseInsensitiveDictionary        | 1000           |   485.8 μs |  14.54 μs |  42.42 μs |   476.1 μs |  0.89 |    0.11 |         - |         - |        0.00 |
| CaseInsensitiveFrozenDictionary  | 1000           |   237.6 μs |   4.72 μs |   9.64 μs |   236.4 μs |  0.44 |    0.04 |         - |         - |        0.00 |
|                                  |                |            |           |           |            |       |         |           |           |             |
| **StringSwitchWithToLowerInvariant** | **10000**          | **5,251.2 μs** | **185.11 μs** | **519.06 μs** | **5,133.3 μs** |  **1.01** |    **0.14** | **1328.1250** | **5760000 B** |        **1.00** |
| CaseInsensitiveDictionary        | 10000          | 4,495.9 μs |  88.35 μs | 174.40 μs | 4,469.3 μs |  0.86 |    0.09 |         - |         - |        0.00 |
| CaseInsensitiveFrozenDictionary  | 10000          | 2,340.4 μs |  46.64 μs |  89.86 μs | 2,301.4 μs |  0.45 |    0.04 |         - |         - |        0.00 |
