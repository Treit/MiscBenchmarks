# Parsing XML



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                       | Count | Mean         | Error        | StdDev       | Ratio | RatioSD |
|----------------------------- |------ |-------------:|-------------:|-------------:|------:|--------:|
| **CountElementsWithXDocument**   | **10**    |     **149.1 μs** |      **2.83 μs** |      **2.78 μs** |  **1.09** |    **0.02** |
| CountElementsWithXmlDocument | 10    |     161.1 μs |      2.34 μs |      1.96 μs |  1.18 |    0.02 |
| CountElementsWithXmlReader   | 10    |     136.6 μs |      1.64 μs |      1.54 μs |  1.00 |    0.02 |
|                              |       |              |              |              |       |         |
| **CountElementsWithXDocument**   | **1000**  | **393,703.7 μs** |  **7,863.50 μs** | **20,577.42 μs** |  **2.28** |    **0.12** |
| CountElementsWithXmlDocument | 1000  | 522,425.3 μs | 10,327.00 μs | 20,624.14 μs |  3.03 |    0.13 |
| CountElementsWithXmlReader   | 1000  | 172,593.1 μs |  3,070.83 μs |  2,872.46 μs |  1.00 |    0.02 |
