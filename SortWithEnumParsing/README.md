# EnumPropertyParsing

Benchmarking how often an enum value is parsed when sorting records whose `Holiday` property either re-parses via an expression-bodied member or caches the parsed value in a read-only auto-property initializer.



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                 | Count | Mean       | Error    | StdDev   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|----------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
| **ExpressionPropertySort** | **5**     |   **199.8 ns** |  **1.15 ns** |  **1.07 ns** |  **1.94** |    **0.02** | **0.0257** |     **432 B** |        **1.00** |
| CachedPropertySort     | 5     |   103.1 ns |  0.96 ns |  0.85 ns |  1.00 |    0.01 | 0.0257 |     432 B |        1.00 |
|                        |       |            |          |          |       |         |        |           |             |
| **ExpressionPropertySort** | **100**   | **3,738.2 ns** | **32.33 ns** | **30.24 ns** |  **1.97** |    **0.02** | **0.1602** |    **2704 B** |        **1.00** |
| CachedPropertySort     | 100   | 1,901.2 ns | 19.36 ns | 18.11 ns |  1.00 |    0.01 | 0.1602 |    2704 B |        1.00 |
