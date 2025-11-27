# Initializing Multidimensional vs. Jagged arrays.





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                           | Job       | Runtime   | Size | Mean        | Error     | StdDev     |
|--------------------------------- |---------- |---------- |----- |------------:|----------:|-----------:|
| **InitJaggedRandomValues**           | **.NET 10.0** | **.NET 10.0** | **100**  |    **53.56 μs** |  **0.796 μs** |   **0.745 μs** |
| InitMultidimensionalRandomValues | .NET 10.0 | .NET 10.0 | 100  |    53.81 μs |  0.682 μs |   0.638 μs |
| InitJaggedFixedValue             | .NET 10.0 | .NET 10.0 | 100  |    45.03 μs |  0.396 μs |   0.370 μs |
| InitMultidimensionalFixedValue   | .NET 10.0 | .NET 10.0 | 100  |    21.12 μs |  0.190 μs |   0.178 μs |
| InitJaggedRandomValues           | .NET 9.0  | .NET 9.0  | 100  |    54.06 μs |  0.807 μs |   0.755 μs |
| InitMultidimensionalRandomValues | .NET 9.0  | .NET 9.0  | 100  |    56.65 μs |  0.631 μs |   0.590 μs |
| InitJaggedFixedValue             | .NET 9.0  | .NET 9.0  | 100  |    44.71 μs |  0.503 μs |   0.471 μs |
| InitMultidimensionalFixedValue   | .NET 9.0  | .NET 9.0  | 100  |    21.02 μs |  0.188 μs |   0.167 μs |
| **InitJaggedRandomValues**           | **.NET 10.0** | **.NET 10.0** | **1024** | **8,760.84 μs** | **41.840 μs** |  **39.137 μs** |
| InitMultidimensionalRandomValues | .NET 10.0 | .NET 10.0 | 1024 | 9,110.26 μs | 20.194 μs |  15.766 μs |
| InitJaggedFixedValue             | .NET 10.0 | .NET 10.0 | 1024 | 2,398.34 μs | 47.659 μs | 116.009 μs |
| InitMultidimensionalFixedValue   | .NET 10.0 | .NET 10.0 | 1024 | 2,586.75 μs | 17.697 μs |  16.554 μs |
| InitJaggedRandomValues           | .NET 9.0  | .NET 9.0  | 1024 | 8,741.74 μs | 23.393 μs |  19.534 μs |
| InitMultidimensionalRandomValues | .NET 9.0  | .NET 9.0  | 1024 | 9,115.20 μs | 24.669 μs |  23.076 μs |
| InitJaggedFixedValue             | .NET 9.0  | .NET 9.0  | 1024 | 2,302.59 μs | 45.552 μs | 116.766 μs |
| InitMultidimensionalFixedValue   | .NET 9.0  | .NET 9.0  | 1024 | 2,582.25 μs | 15.937 μs |  14.907 μs |
