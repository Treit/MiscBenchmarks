Comparing the performance of two different property syntax patterns for accessing environment variables


```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                      | Count  | Mean            | Error        | StdDev       | Ratio  | RatioSD | Gen0     | Allocated | Alloc Ratio |
|---------------------------- |------- |----------------:|-------------:|-------------:|-------:|--------:|---------:|----------:|------------:|
| **ExpressionBodiedProperty**    | **10**     |      **1,304.8 ns** |      **8.65 ns** |      **8.09 ns** |   **9.90** |    **0.09** |   **0.0381** |     **640 B** |       **10.00** |
| AutoPropertyWithInitializer | 10     |        131.8 ns |      0.90 ns |      0.85 ns |   1.00 |    0.01 |   0.0038 |      64 B |        1.00 |
|                             |        |                 |              |              |        |         |          |           |             |
| **ExpressionBodiedProperty**    | **100000** | **12,857,184.5 ns** | **78,880.95 ns** | **65,869.16 ns** | **409.28** |    **4.17** | **375.0000** | **6400000 B** |  **100,000.00** |
| AutoPropertyWithInitializer | 100000 |     31,416.8 ns |    309.53 ns |    289.54 ns |   1.00 |    0.01 |        - |      64 B |        1.00 |
