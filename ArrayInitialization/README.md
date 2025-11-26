# Initializing Multidimensional vs. Jagged arrays.




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                           | Size | Mean        | Error     | StdDev     | Median      |
|--------------------------------- |----- |------------:|----------:|-----------:|------------:|
| **InitJaggedRandomValues**           | **100**  |    **51.68 μs** |  **0.971 μs** |   **2.559 μs** |    **50.56 μs** |
| InitMultidimensionalRandomValues | 100  |    54.20 μs |  1.152 μs |   3.286 μs |    53.09 μs |
| InitJaggedFixedValue             | 100  |    44.91 μs |  0.674 μs |   0.631 μs |    45.10 μs |
| InitMultidimensionalFixedValue   | 100  |    20.77 μs |  0.096 μs |   0.080 μs |    20.80 μs |
| **InitJaggedRandomValues**           | **1024** | **8,598.25 μs** | **31.725 μs** |  **28.124 μs** | **8,591.06 μs** |
| InitMultidimensionalRandomValues | 1024 | 9,182.16 μs | 36.893 μs |  34.510 μs | 9,174.75 μs |
| InitJaggedFixedValue             | 1024 | 2,103.14 μs | 83.414 μs | 245.949 μs | 2,114.27 μs |
| InitMultidimensionalFixedValue   | 1024 | 2,624.90 μs | 13.757 μs |  12.868 μs | 2,630.70 μs |
