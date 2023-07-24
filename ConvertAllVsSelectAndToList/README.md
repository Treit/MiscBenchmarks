# Converting list values

``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25910.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.300-preview.23179.2
  [Host]     : .NET 7.0.7 (7.0.723.27404), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.7 (7.0.723.27404), X64 RyuJIT AVX2


```
|          Method | Count |         Mean |        Error |       StdDev |       Median | Ratio | RatioSD |
|---------------- |------ |-------------:|-------------:|-------------:|-------------:|------:|--------:|
|      **ConvertAll** |    **10** |     **49.13 ns** |     **1.429 ns** |     **4.169 ns** |     **48.48 ns** |  **1.00** |    **0.00** |
| SelectAndToList |    10 |     85.92 ns |     2.748 ns |     7.972 ns |     84.87 ns |  1.76 |    0.22 |
|                 |       |              |              |              |              |       |         |
|      **ConvertAll** | **10000** | **31,708.31 ns** |   **881.158 ns** | **2,542.343 ns** | **31,521.33 ns** |  **1.00** |    **0.00** |
| SelectAndToList | 10000 | 37,314.01 ns | 1,781.994 ns | 5,226.281 ns | 35,764.59 ns |  1.19 |    0.19 |
