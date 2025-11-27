# Using unnecessary Select calls like `.Select(x => x)`






```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                           | Job       | Runtime   | Count  | Mean           | Error        | StdDev       | Ratio | RatioSD | Gen0     | Gen1     | Gen2     | Allocated | Alloc Ratio |
|--------------------------------- |---------- |---------- |------- |---------------:|-------------:|-------------:|------:|--------:|---------:|---------:|---------:|----------:|------------:|
| **FilterWithJustWhere**              | **.NET 10.0** | **.NET 10.0** | **10**     |       **110.8 ns** |      **0.79 ns** |      **0.74 ns** |  **1.00** |    **0.01** |   **0.0124** |        **-** |        **-** |     **208 B** |        **1.00** |
| FilterWithUnnecessarySelectFirst | .NET 10.0 | .NET 10.0 | 10     |       158.0 ns |      1.44 ns |      1.35 ns |  1.43 |    0.01 |   0.0157 |        - |        - |     264 B |        1.27 |
|                                  |           |           |        |                |              |              |       |         |          |          |          |           |             |
| FilterWithJustWhere              | .NET 9.0  | .NET 9.0  | 10     |       111.3 ns |      1.45 ns |      1.35 ns |  1.00 |    0.02 |   0.0124 |        - |        - |     208 B |        1.00 |
| FilterWithUnnecessarySelectFirst | .NET 9.0  | .NET 9.0  | 10     |       161.4 ns |      3.02 ns |      2.67 ns |  1.45 |    0.03 |   0.0157 |        - |        - |     264 B |        1.27 |
|                                  |           |           |        |                |              |              |       |         |          |          |          |           |             |
| **FilterWithJustWhere**              | **.NET 10.0** | **.NET 10.0** | **100000** |   **922,485.7 ns** |  **7,192.75 ns** |  **6,728.11 ns** |  **1.00** |    **0.01** | **204.1016** | **204.1016** | **199.2188** |  **802856 B** |        **1.00** |
| FilterWithUnnecessarySelectFirst | .NET 10.0 | .NET 10.0 | 100000 | 1,062,860.9 ns | 10,853.94 ns | 10,152.78 ns |  1.15 |    0.01 | 207.0313 | 207.0313 | 197.2656 |  803843 B |        1.00 |
|                                  |           |           |        |                |              |              |       |         |          |          |          |           |             |
| FilterWithJustWhere              | .NET 9.0  | .NET 9.0  | 100000 |   920,755.2 ns |  6,907.59 ns |  6,461.36 ns |  1.00 |    0.01 | 204.1016 | 204.1016 | 199.2188 |  802863 B |        1.00 |
| FilterWithUnnecessarySelectFirst | .NET 9.0  | .NET 9.0  | 100000 | 1,086,363.9 ns |  7,689.05 ns |  6,816.14 ns |  1.18 |    0.01 | 207.0313 | 207.0313 | 197.2656 |  803829 B |        1.00 |
