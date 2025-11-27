# Hex string to bytes





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                    | Job       | Runtime   | HexStringLength | Mean      | Error     | StdDev   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------------------------ |---------- |---------- |---------------- |----------:|----------:|---------:|------:|--------:|-------:|----------:|------------:|
| **HexStringToBytesUsingConvert**              | **.NET 10.0** | **.NET 10.0** | **6**               |  **10.23 ns** |  **0.095 ns** | **0.089 ns** |  **1.00** |    **0.01** | **0.0019** |      **32 B** |        **1.00** |
| HexStringToBytesUsingCustomImplementation | .NET 10.0 | .NET 10.0 | 6               |  11.36 ns |  0.289 ns | 0.665 ns |  1.11 |    0.07 | 0.0019 |      32 B |        1.00 |
|                                           |           |           |                 |           |           |          |       |         |        |           |             |
| HexStringToBytesUsingConvert              | .NET 9.0  | .NET 9.0  | 6               |  10.48 ns |  0.232 ns | 0.206 ns |  1.00 |    0.03 | 0.0019 |      32 B |        1.00 |
| HexStringToBytesUsingCustomImplementation | .NET 9.0  | .NET 9.0  | 6               |  11.19 ns |  0.290 ns | 0.694 ns |  1.07 |    0.07 | 0.0019 |      32 B |        1.00 |
|                                           |           |           |                 |           |           |          |       |         |        |           |             |
| **HexStringToBytesUsingConvert**              | **.NET 10.0** | **.NET 10.0** | **50**              |  **44.67 ns** |  **0.235 ns** | **0.220 ns** |  **1.00** |    **0.01** | **0.0033** |      **56 B** |        **1.00** |
| HexStringToBytesUsingCustomImplementation | .NET 10.0 | .NET 10.0 | 50              |  45.91 ns |  0.401 ns | 0.375 ns |  1.03 |    0.01 | 0.0033 |      56 B |        1.00 |
|                                           |           |           |                 |           |           |          |       |         |        |           |             |
| HexStringToBytesUsingConvert              | .NET 9.0  | .NET 9.0  | 50              |  44.73 ns |  0.544 ns | 0.483 ns |  1.00 |    0.01 | 0.0033 |      56 B |        1.00 |
| HexStringToBytesUsingCustomImplementation | .NET 9.0  | .NET 9.0  | 50              |  45.50 ns |  0.487 ns | 0.455 ns |  1.02 |    0.01 | 0.0033 |      56 B |        1.00 |
|                                           |           |           |                 |           |           |          |       |         |        |           |             |
| **HexStringToBytesUsingConvert**              | **.NET 10.0** | **.NET 10.0** | **1000**            | **606.92 ns** |  **6.073 ns** | **5.681 ns** |  **1.00** |    **0.01** | **0.0315** |     **528 B** |        **1.00** |
| HexStringToBytesUsingCustomImplementation | .NET 10.0 | .NET 10.0 | 1000            | 903.05 ns | 10.077 ns | 9.426 ns |  1.49 |    0.02 | 0.0315 |     528 B |        1.00 |
|                                           |           |           |                 |           |           |          |       |         |        |           |             |
| HexStringToBytesUsingConvert              | .NET 9.0  | .NET 9.0  | 1000            | 602.58 ns |  5.508 ns | 5.152 ns |  1.00 |    0.01 | 0.0315 |     528 B |        1.00 |
| HexStringToBytesUsingCustomImplementation | .NET 9.0  | .NET 9.0  | 1000            | 894.49 ns |  9.262 ns | 8.663 ns |  1.48 |    0.02 | 0.0315 |     528 B |        1.00 |
