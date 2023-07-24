# Converting list values

``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25910.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.300-preview.23179.2
  [Host]     : .NET 6.0.18 (6.0.1823.26907), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.18 (6.0.1823.26907), X64 RyuJIT AVX2


```
|          Method | Count |         Mean |        Error |       StdDev | Ratio | RatioSD |
|---------------- |------ |-------------:|-------------:|-------------:|------:|--------:|
|      **ConvertAll** |    **10** |     **51.96 ns** |     **2.608 ns** |     **7.648 ns** |  **1.00** |    **0.00** |
| SelectAndToList |    10 |     88.96 ns |     3.216 ns |     9.381 ns |  1.75 |    0.28 |
|                 |       |              |              |              |       |         |
|      **ConvertAll** | **10000** | **34,813.83 ns** | **1,236.704 ns** | **3,607.524 ns** |  **1.00** |    **0.00** |
| SelectAndToList | 10000 | 42,109.20 ns | 1,917.517 ns | 5,623.746 ns |  1.22 |    0.21 |
