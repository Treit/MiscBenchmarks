# Parsing XML

``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25921.1010)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.306
  [Host]     : .NET 6.0.20 (6.0.2023.32017), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.20 (6.0.2023.32017), X64 RyuJIT AVX2


```
|                       Method | Count |         Mean |        Error |       StdDev |       Median | Ratio | RatioSD |
|----------------------------- |------ |-------------:|-------------:|-------------:|-------------:|------:|--------:|
|   **CountElementsWithXDocument** |    **10** |     **156.2 μs** |      **4.12 μs** |     **12.14 μs** |     **153.5 μs** |  **1.18** |    **0.12** |
| CountElementsWithXmlDocument |    10 |     175.2 μs |      3.92 μs |     11.37 μs |     171.0 μs |  1.32 |    0.11 |
|   CountElementsWithXmlReader |    10 |     133.3 μs |      2.84 μs |      8.16 μs |     131.7 μs |  1.00 |    0.00 |
|                              |       |              |              |              |              |       |         |
|   **CountElementsWithXDocument** |  **1000** | **553,551.6 μs** | **10,724.73 μs** | **17,318.45 μs** | **556,198.8 μs** |  **2.07** |    **0.14** |
| CountElementsWithXmlDocument |  1000 | 742,844.1 μs | 13,379.10 μs | 20,431.30 μs | 740,757.7 μs |  2.79 |    0.14 |
|   CountElementsWithXmlReader |  1000 | 265,611.0 μs |  5,296.82 μs | 13,385.74 μs | 261,031.5 μs |  1.00 |    0.00 |
