# Checking if any one of a series of values is null


```

BenchmarkDotNet v0.15.1, Windows 11 (10.0.27876.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.300
  [Host]     : .NET 9.0.5 (9.0.525.21509), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 9.0.5 (9.0.525.21509), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method             | Scenario   | Iterations | Mean         | Error        | StdDev       | Median       | Ratio | RatioSD | Gen0     | Allocated | Alloc Ratio |
|------------------- |----------- |----------- |-------------:|-------------:|-------------:|-------------:|------:|--------:|---------:|----------:|------------:|
| **ExplicitNullChecks** | **AllNonNull** | **1000**       |   **3,555.8 ns** |    **113.49 ns** |    **331.07 ns** |   **3,461.5 ns** |  **1.01** |    **0.13** |        **-** |         **-** |          **NA** |
| LinqAnyWithArray   | AllNonNull | 1000       |  39,209.0 ns |    994.73 ns |  2,789.34 ns |  38,645.3 ns | 11.12 |    1.25 |  24.1089 |  104000 B |          NA |
|                    |            |            |              |              |              |              |       |         |          |           |             |
| **ExplicitNullChecks** | **AllNonNull** | **10000**      |  **33,580.2 ns** |    **757.67 ns** |  **2,161.66 ns** |  **33,090.0 ns** |  **1.00** |    **0.09** |        **-** |         **-** |          **NA** |
| LinqAnyWithArray   | AllNonNull | 10000      | 394,686.8 ns | 10,347.50 ns | 29,521.99 ns | 389,429.0 ns | 11.80 |    1.13 | 240.7227 | 1040000 B |          NA |
|                    |            |            |              |              |              |              |       |         |          |           |             |
| **ExplicitNullChecks** | **LastNull**   | **1000**       |   **3,179.8 ns** |     **61.69 ns** |     **75.77 ns** |   **3,174.8 ns** |  **1.00** |    **0.03** |        **-** |         **-** |          **NA** |
| LinqAnyWithArray   | LastNull   | 1000       |  42,912.5 ns |  1,991.04 ns |  5,839.37 ns |  41,566.9 ns | 13.50 |    1.86 |  24.1089 |  104000 B |          NA |
|                    |            |            |              |              |              |              |       |         |          |           |             |
| **ExplicitNullChecks** | **LastNull**   | **10000**      |  **33,824.1 ns** |    **799.77 ns** |  **2,255.78 ns** |  **33,217.1 ns** |  **1.00** |    **0.09** |        **-** |         **-** |          **NA** |
| LinqAnyWithArray   | LastNull   | 10000      | 415,523.6 ns | 10,839.67 ns | 31,619.82 ns | 408,420.1 ns | 12.34 |    1.21 | 240.7227 | 1040000 B |          NA |
|                    |            |            |              |              |              |              |       |         |          |           |             |
| **ExplicitNullChecks** | **OneNull**    | **1000**       |     **618.5 ns** |     **12.42 ns** |     **34.20 ns** |     **609.5 ns** |  **1.00** |    **0.08** |        **-** |         **-** |          **NA** |
| LinqAnyWithArray   | OneNull    | 1000       |  36,042.3 ns |    982.21 ns |  2,865.14 ns |  35,457.3 ns | 58.44 |    5.56 |  24.1089 |  104000 B |          NA |
|                    |            |            |              |              |              |              |       |         |          |           |             |
| **ExplicitNullChecks** | **OneNull**    | **10000**      |   **6,092.1 ns** |    **120.06 ns** |    **275.86 ns** |   **6,001.7 ns** |  **1.00** |    **0.06** |        **-** |         **-** |          **NA** |
| LinqAnyWithArray   | OneNull    | 10000      | 373,406.4 ns | 11,664.45 ns | 33,467.50 ns | 365,904.2 ns | 61.41 |    6.09 | 240.2344 | 1040000 B |          NA |
