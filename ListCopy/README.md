# Copying lists



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                  | Count   | Mean           | Error        | StdDev        | Median         | Ratio | RatioSD |
|------------------------ |-------- |---------------:|-------------:|--------------:|---------------:|------:|--------:|
| **CopyWithListConstructor** | **1000**    |       **173.3 ns** |      **3.38 ns** |       **4.15 ns** |       **174.8 ns** |  **1.00** |    **0.03** |
| CopyWithToList          | 1000    |       171.4 ns |      3.40 ns |       3.18 ns |       172.2 ns |  0.99 |    0.03 |
| CopyExplicitly          | 1000    |     1,536.1 ns |     12.52 ns |      11.10 ns |     1,538.7 ns |  8.87 |    0.23 |
|                         |         |                |              |               |                |       |         |
| **CopyWithListConstructor** | **100000**  |   **283,937.8 ns** |  **4,586.93 ns** |   **4,290.62 ns** |   **283,579.3 ns** |  **1.00** |    **0.02** |
| CopyWithToList          | 100000  |   276,229.5 ns |  9,724.66 ns |  28,673.39 ns |   284,503.2 ns |  0.97 |    0.10 |
| CopyExplicitly          | 100000  |   385,449.6 ns |  8,509.28 ns |  24,686.96 ns |   393,034.5 ns |  1.36 |    0.09 |
|                         |         |                |              |               |                |       |         |
| **CopyWithListConstructor** | **1000000** | **1,490,732.8 ns** | **25,651.48 ns** |  **22,739.37 ns** | **1,484,667.2 ns** |  **1.00** |    **0.02** |
| CopyWithToList          | 1000000 | 1,434,536.5 ns | 43,206.64 ns | 119,725.41 ns | 1,427,999.4 ns |  0.96 |    0.08 |
| CopyExplicitly          | 1000000 | 2,414,431.1 ns | 38,403.80 ns |  32,068.91 ns | 2,417,714.6 ns |  1.62 |    0.03 |
