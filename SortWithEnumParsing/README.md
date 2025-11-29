# EnumPropertyParsing

Benchmarking how often an enum value is parsed when sorting records whose `Holiday` property either re-parses via an expression-bodied member or caches the parsed value in a read-only auto-property initializer.




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                 | Job       | Runtime   | Count | Mean        | Error     | StdDev    | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|----------------------- |---------- |---------- |------ |------------:|----------:|----------:|------:|--------:|-------:|----------:|------------:|
| **ExpressionPropertySort** | **.NET 10.0** | **.NET 10.0** | **5**     |   **191.34 ns** |  **3.152 ns** |  **2.948 ns** |  **1.89** |    **0.08** | **0.0257** |     **432 B** |        **1.00** |
| CachedPropertySort     | .NET 10.0 | .NET 10.0 | 5     |   101.25 ns |  2.101 ns |  4.147 ns |  1.00 |    0.06 | 0.0257 |     432 B |        1.00 |
|                        |           |           |       |             |           |           |       |         |        |           |             |
| ExpressionPropertySort | .NET 9.0  | .NET 9.0  | 5     |   188.50 ns |  0.970 ns |  0.907 ns |  1.92 |    0.02 | 0.0257 |     432 B |        1.00 |
| CachedPropertySort     | .NET 9.0  | .NET 9.0  | 5     |    98.26 ns |  0.799 ns |  0.747 ns |  1.00 |    0.01 | 0.0257 |     432 B |        1.00 |
|                        |           |           |       |             |           |           |       |         |        |           |             |
| **ExpressionPropertySort** | **.NET 10.0** | **.NET 10.0** | **100**   | **3,727.95 ns** | **19.714 ns** | **18.440 ns** |  **1.89** |    **0.03** | **0.1602** |    **2704 B** |        **1.00** |
| CachedPropertySort     | .NET 10.0 | .NET 10.0 | 100   | 1,976.50 ns | 37.489 ns | 35.067 ns |  1.00 |    0.02 | 0.1602 |    2704 B |        1.00 |
|                        |           |           |       |             |           |           |       |         |        |           |             |
| ExpressionPropertySort | .NET 9.0  | .NET 9.0  | 100   | 3,722.14 ns | 26.889 ns | 25.152 ns |  1.89 |    0.03 | 0.1602 |    2704 B |        1.00 |
| CachedPropertySort     | .NET 9.0  | .NET 9.0  | 100   | 1,967.61 ns | 29.014 ns | 27.140 ns |  1.00 |    0.02 | 0.1602 |    2704 B |        1.00 |
