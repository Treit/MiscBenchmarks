# Parsing XML





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                       | Job       | Runtime   | Count | Mean         | Error       | StdDev       | Ratio | RatioSD |
|----------------------------- |---------- |---------- |------ |-------------:|------------:|-------------:|------:|--------:|
| **CountElementsWithXDocument**   | **.NET 10.0** | **.NET 10.0** | **10**    |     **151.6 μs** |     **1.51 μs** |      **1.18 μs** |  **1.13** |    **0.03** |
| CountElementsWithXmlDocument | .NET 10.0 | .NET 10.0 | 10    |     168.5 μs |     3.31 μs |      4.63 μs |  1.25 |    0.05 |
| CountElementsWithXmlReader   | .NET 10.0 | .NET 10.0 | 10    |     134.8 μs |     2.65 μs |      3.80 μs |  1.00 |    0.04 |
|                              |           |           |       |              |             |              |       |         |
| CountElementsWithXDocument   | .NET 9.0  | .NET 9.0  | 10    |     142.5 μs |     2.40 μs |      3.12 μs |  1.11 |    0.02 |
| CountElementsWithXmlDocument | .NET 9.0  | .NET 9.0  | 10    |     156.2 μs |     2.29 μs |      1.92 μs |  1.22 |    0.02 |
| CountElementsWithXmlReader   | .NET 9.0  | .NET 9.0  | 10    |     128.1 μs |     1.09 μs |      0.85 μs |  1.00 |    0.01 |
|                              |           |           |       |              |             |              |       |         |
| **CountElementsWithXDocument**   | **.NET 10.0** | **.NET 10.0** | **1000**  | **371,687.6 μs** | **7,382.31 μs** | **10,820.90 μs** |  **2.26** |    **0.07** |
| CountElementsWithXmlDocument | .NET 10.0 | .NET 10.0 | 1000  | 463,334.7 μs | 7,087.44 μs | 13,655.09 μs |  2.82 |    0.09 |
| CountElementsWithXmlReader   | .NET 10.0 | .NET 10.0 | 1000  | 164,537.2 μs | 2,346.33 μs |  2,194.76 μs |  1.00 |    0.02 |
|                              |           |           |       |              |             |              |       |         |
| CountElementsWithXDocument   | .NET 9.0  | .NET 9.0  | 1000  | 371,495.9 μs | 7,131.69 μs |  9,273.21 μs |  2.28 |    0.06 |
| CountElementsWithXmlDocument | .NET 9.0  | .NET 9.0  | 1000  | 476,081.8 μs | 8,543.80 μs |  7,573.86 μs |  2.92 |    0.05 |
| CountElementsWithXmlReader   | .NET 9.0  | .NET 9.0  | 1000  | 163,044.8 μs | 1,107.84 μs |  1,036.28 μs |  1.00 |    0.01 |
