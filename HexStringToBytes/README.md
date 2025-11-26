# Hex string to bytes




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                    | HexStringLength | Mean      | Error    | StdDev   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------------------------ |---------------- |----------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
| **HexStringToBytesUsingConvert**              | **6**               |  **10.01 ns** | **0.123 ns** | **0.115 ns** |  **1.00** |    **0.02** | **0.0019** |      **32 B** |        **1.00** |
| HexStringToBytesUsingCustomImplementation | 6               |  10.64 ns | 0.269 ns | 0.350 ns |  1.06 |    0.04 | 0.0019 |      32 B |        1.00 |
|                                           |                 |           |          |          |       |         |        |           |             |
| **HexStringToBytesUsingConvert**              | **50**              |  **43.53 ns** | **0.393 ns** | **0.368 ns** |  **1.00** |    **0.01** | **0.0033** |      **56 B** |        **1.00** |
| HexStringToBytesUsingCustomImplementation | 50              |  45.27 ns | 0.549 ns | 0.487 ns |  1.04 |    0.01 | 0.0033 |      56 B |        1.00 |
|                                           |                 |           |          |          |       |         |        |           |             |
| **HexStringToBytesUsingConvert**              | **1000**            | **596.18 ns** | **4.293 ns** | **3.584 ns** |  **1.00** |    **0.01** | **0.0315** |     **528 B** |        **1.00** |
| HexStringToBytesUsingCustomImplementation | 1000            | 895.93 ns | 9.711 ns | 8.109 ns |  1.50 |    0.02 | 0.0315 |     528 B |        1.00 |
