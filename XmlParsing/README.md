# Parsing XML




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                       | Count | Mean         | Error       | StdDev      | Ratio | RatioSD |
|----------------------------- |------ |-------------:|------------:|------------:|------:|--------:|
| **CountElementsWithXDocument**   | **10**    |     **144.1 μs** |     **2.87 μs** |     **3.07 μs** |  **1.03** |    **0.03** |
| CountElementsWithXmlDocument | 10    |     158.2 μs |     2.94 μs |     2.75 μs |  1.14 |    0.02 |
| CountElementsWithXmlReader   | 10    |     139.3 μs |     2.45 μs |     2.05 μs |  1.00 |    0.02 |
|                              |       |              |             |             |       |         |
| **CountElementsWithXDocument**   | **1000**  | **364,812.2 μs** | **7,270.70 μs** | **7,140.80 μs** |  **2.22** |    **0.05** |
| CountElementsWithXmlDocument | 1000  | 492,573.9 μs | 8,475.13 μs | 7,512.98 μs |  3.00 |    0.05 |
| CountElementsWithXmlReader   | 1000  | 164,240.4 μs | 1,459.65 μs | 1,293.94 μs |  1.00 |    0.01 |
