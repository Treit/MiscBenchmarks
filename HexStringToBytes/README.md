# Hex string to bytes



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                    | HexStringLength | Mean       | Error      | StdDev     | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------------------------ |---------------- |-----------:|-----------:|-----------:|------:|--------:|-------:|----------:|------------:|
| **HexStringToBytesUsingConvert**              | **6**               |   **9.980 ns** |  **0.1542 ns** |  **0.1443 ns** |  **1.00** |    **0.02** | **0.0019** |      **32 B** |        **1.00** |
| HexStringToBytesUsingCustomImplementation | 6               |  10.193 ns |  0.2550 ns |  0.2385 ns |  1.02 |    0.03 | 0.0019 |      32 B |        1.00 |
|                                           |                 |            |            |            |       |         |        |           |             |
| **HexStringToBytesUsingConvert**              | **50**              |  **43.849 ns** |  **0.3446 ns** |  **0.3223 ns** |  **1.00** |    **0.01** | **0.0033** |      **56 B** |        **1.00** |
| HexStringToBytesUsingCustomImplementation | 50              |  44.693 ns |  0.3455 ns |  0.3232 ns |  1.02 |    0.01 | 0.0033 |      56 B |        1.00 |
|                                           |                 |            |            |            |       |         |        |           |             |
| **HexStringToBytesUsingConvert**              | **1000**            | **596.873 ns** |  **6.5035 ns** |  **6.0834 ns** |  **1.00** |    **0.01** | **0.0315** |     **528 B** |        **1.00** |
| HexStringToBytesUsingCustomImplementation | 1000            | 871.334 ns | 12.8622 ns | 12.0313 ns |  1.46 |    0.02 | 0.0315 |     528 B |        1.00 |
