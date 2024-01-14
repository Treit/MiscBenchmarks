# Parsing XML


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                       Method | Count |          Mean |        Error |        StdDev |        Median | Ratio | RatioSD |
|----------------------------- |------ |--------------:|-------------:|--------------:|--------------:|------:|--------:|
|   **CountElementsWithXDocument** |    **10** |     **113.64 μs** |     **2.235 μs** |      **2.744 μs** |     **114.19 μs** |  **1.14** |    **0.07** |
| CountElementsWithXmlDocument |    10 |     130.24 μs |     2.578 μs |      4.968 μs |     131.41 μs |  1.31 |    0.09 |
|   CountElementsWithXmlReader |    10 |      98.69 μs |     1.952 μs |      5.005 μs |      96.67 μs |  1.00 |    0.00 |
|                              |       |               |              |               |               |       |         |
|   **CountElementsWithXDocument** |  **1000** | **431,411.90 μs** | **8,220.632 μs** | **20,774.587 μs** | **429,212.40 μs** |  **2.17** |    **0.07** |
| CountElementsWithXmlDocument |  1000 | 561,201.03 μs | 9,967.270 μs | 19,203.545 μs | 562,053.15 μs |  2.97 |    0.09 |
|   CountElementsWithXmlReader |  1000 | 193,739.09 μs | 2,737.681 μs |  2,137.402 μs | 194,289.52 μs |  1.00 |    0.00 |
