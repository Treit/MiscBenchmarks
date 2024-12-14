# Filtering dictionary entries

```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.4602/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK 9.0.101
  [Host]     : .NET 8.0.11 (8.0.1124.51707), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.11 (8.0.1124.51707), X64 RyuJIT AVX2


```
| Method                              | Count | Mean             | Error          | StdDev         | Ratio     | RatioSD | Gen0       | Gen1      | Allocated   | Alloc Ratio |
|------------------------------------ |------ |-----------------:|---------------:|---------------:|----------:|--------:|-----------:|----------:|------------:|------------:|
| **FilterUsingConvolutedLinq**           | **100**   |       **109.940 μs** |      **0.8011 μs** |      **0.7102 μs** |    **106.17** |    **1.28** |     **3.2959** |         **-** |     **55992 B** |       **70.70** |
| FilterUsingCleanedUpPatternMatching | 100   |         1.036 μs |      0.0084 μs |      0.0079 μs |      1.00 |    0.00 |     0.0458 |         - |       792 B |        1.00 |
|                                     |       |                  |                |                |           |         |            |           |             |             |
| **FilterUsingConvolutedLinq**           | **10000** | **1,066,174.820 μs** | **12,449.5955 μs** | **11,645.3594 μs** | **10,274.10** |  **237.15** | **19000.0000** | **1000.0000** | **332375056 B** |    **6,044.06** |
| FilterUsingCleanedUpPatternMatching | 10000 |       103.787 μs |      1.9483 μs |      1.9135 μs |      1.00 |    0.00 |     3.1738 |    0.2441 |     54992 B |        1.00 |
