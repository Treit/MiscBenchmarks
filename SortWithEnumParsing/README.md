# EnumPropertyParsing

Benchmarking how often an enum value is parsed when sorting records whose `Holiday` property either re-parses via an expression-bodied member or caches the parsed value in a read-only auto-property initializer.


```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.28000.1199)
Unknown processor
.NET SDK 10.0.100-preview.6.25358.103
  [Host]     : .NET 9.0.10 (9.0.1025.47515), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 9.0.10 (9.0.1025.47515), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                 | Count   | Mean             | Error           | StdDev           | Median           | Ratio | RatioSD | Gen0     | Gen1     | Gen2     | Allocated  | Alloc Ratio |
|----------------------- |-------- |-----------------:|----------------:|-----------------:|-----------------:|------:|--------:|---------:|---------:|---------:|-----------:|------------:|
| **ExpressionPropertySort** | **10**      |       **1,165.8 ns** |        **41.09 ns** |        **119.85 ns** |       **1,133.5 ns** |  **3.18** |    **0.39** |   **0.1297** |        **-** |        **-** |      **560 B** |        **1.00** |
| CachedPropertySort     | 10      |         368.2 ns |         9.46 ns |         27.14 ns |         364.0 ns |  1.01 |    0.10 |   0.1297 |        - |        - |      560 B |        1.00 |
|                        |         |                  |                 |                  |                  |       |         |          |          |          |            |             |
| **ExpressionPropertySort** | **1000000** | **332,603,015.5 ns** | **6,637,314.68 ns** | **14,144,659.79 ns** | **331,459,350.0 ns** |  **1.64** |    **0.10** |        **-** |        **-** |        **-** | **20000772 B** |        **1.00** |
| CachedPropertySort     | 1000000 | 202,890,287.4 ns | 4,000,943.25 ns |  9,030,796.35 ns | 203,425,800.0 ns |  1.00 |    0.06 | 333.3333 | 333.3333 | 333.3333 | 20000472 B |        1.00 |
