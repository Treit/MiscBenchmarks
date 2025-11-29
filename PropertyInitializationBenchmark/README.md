Comparing the performance of two different property syntax patterns for accessing environment variables



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                      | Job       | Runtime   | Count  | Mean            | Error        | StdDev       | Ratio  | RatioSD | Gen0     | Allocated | Alloc Ratio |
|---------------------------- |---------- |---------- |------- |----------------:|-------------:|-------------:|-------:|--------:|---------:|----------:|------------:|
| **ExpressionBodiedProperty**    | **.NET 10.0** | **.NET 10.0** | **10**     |      **1,315.2 ns** |      **6.51 ns** |      **6.09 ns** |  **10.11** |    **0.09** |   **0.0381** |     **640 B** |       **10.00** |
| AutoPropertyWithInitializer | .NET 10.0 | .NET 10.0 | 10     |        130.2 ns |      1.23 ns |      1.03 ns |   1.00 |    0.01 |   0.0038 |      64 B |        1.00 |
|                             |           |           |        |                 |              |              |        |         |          |           |             |
| ExpressionBodiedProperty    | .NET 9.0  | .NET 9.0  | 10     |      1,286.0 ns |      2.68 ns |      2.24 ns |   9.89 |    0.04 |   0.0381 |     640 B |       10.00 |
| AutoPropertyWithInitializer | .NET 9.0  | .NET 9.0  | 10     |        130.0 ns |      0.50 ns |      0.47 ns |   1.00 |    0.00 |   0.0038 |      64 B |        1.00 |
|                             |           |           |        |                 |              |              |        |         |          |           |             |
| **ExpressionBodiedProperty**    | **.NET 10.0** | **.NET 10.0** | **100000** | **12,727,463.5 ns** | **23,841.98 ns** | **18,614.25 ns** | **407.41** |    **1.16** | **375.0000** | **6400193 B** |   **98,464.51** |
| AutoPropertyWithInitializer | .NET 10.0 | .NET 10.0 | 100000 |     31,240.5 ns |     90.42 ns |     80.15 ns |   1.00 |    0.00 |        - |      65 B |        1.00 |
|                             |           |           |        |                 |              |              |        |         |          |           |             |
| ExpressionBodiedProperty    | .NET 9.0  | .NET 9.0  | 100000 | 12,765,321.0 ns | 50,631.72 ns | 47,360.95 ns | 409.23 |    1.58 | 375.0000 | 6400000 B |  100,000.00 |
| AutoPropertyWithInitializer | .NET 9.0  | .NET 9.0  | 100000 |     31,193.6 ns |     50.60 ns |     44.86 ns |   1.00 |    0.00 |        - |      64 B |        1.00 |
