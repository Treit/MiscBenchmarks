# ListSpreadVsReadOnly

```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.28000.1199)
Unknown processor
.NET SDK 10.0.100-preview.6.25358.103
  [Host]     : .NET 9.0.10 (9.0.1025.47515), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 9.0.10 (9.0.1025.47515), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                       | Count | Mean       | Error     | StdDev      | Median     | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|----------------------------- |------ |-----------:|----------:|------------:|-----------:|------:|--------:|-------:|----------:|------------:|
| **UsingExpressionBodyEmptyList** | **10**    | **1,036.7 ns** |  **39.70 ns** |   **116.44 ns** | **1,021.5 ns** |  **1.01** |    **0.16** | **0.6304** |   **2.66 KB** |        **1.00** |
| UsingReadOnlyListField       | 10    |   730.6 ns |  23.66 ns |    67.50 ns |   718.1 ns |  0.71 |    0.10 | 0.4072 |   1.72 KB |        0.65 |
|                              |       |            |           |             |            |       |         |        |           |             |
| **UsingExpressionBodyEmptyList** | **100**   | **9,951.1 ns** | **429.32 ns** | **1,224.88 ns** | **9,553.9 ns** |  **1.01** |    **0.17** | **6.2866** |  **26.56 KB** |        **1.00** |
| UsingReadOnlyListField       | 100   | 7,148.9 ns | 141.17 ns |   206.93 ns | 7,168.5 ns |  0.73 |    0.09 | 4.0741 |  17.19 KB |        0.65 |
