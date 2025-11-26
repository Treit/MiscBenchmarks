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
| **CopyWithListConstructor** | **1000**    |       **175.8 ns** |      **3.54 ns** |       **4.35 ns** |       **177.4 ns** |  **1.00** |    **0.03** |
| CopyWithToList          | 1000    |       172.5 ns |      3.38 ns |       3.47 ns |       172.1 ns |  0.98 |    0.03 |
| CopyExplicitly          | 1000    |     1,544.2 ns |     20.17 ns |      18.87 ns |     1,540.1 ns |  8.79 |    0.24 |
|                         |         |                |              |               |                |       |         |
| **CopyWithListConstructor** | **100000**  |   **279,481.1 ns** |  **7,848.21 ns** |  **23,140.63 ns** |   **285,459.7 ns** |  **1.01** |    **0.15** |
| CopyWithToList          | 100000  |   280,122.7 ns |  3,340.23 ns |   3,124.46 ns |   279,823.0 ns |  1.01 |    0.12 |
| CopyExplicitly          | 100000  |   387,914.5 ns |  8,490.90 ns |  24,902.34 ns |   395,780.8 ns |  1.40 |    0.19 |
|                         |         |                |              |               |                |       |         |
| **CopyWithListConstructor** | **1000000** | **1,445,430.6 ns** | **38,543.39 ns** | **109,966.48 ns** | **1,437,911.1 ns** |  **1.01** |    **0.11** |
| CopyWithToList          | 1000000 | 1,442,604.6 ns | 33,086.82 ns |  90,574.66 ns | 1,443,024.4 ns |  1.00 |    0.10 |
| CopyExplicitly          | 1000000 | 2,426,773.3 ns | 31,838.19 ns |  28,223.73 ns | 2,431,627.7 ns |  1.69 |    0.13 |
