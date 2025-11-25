# Initializing Multidimensional vs. Jagged arrays.



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                           | Size | Mean        | Error     | StdDev     |
|--------------------------------- |----- |------------:|----------:|-----------:|
| **InitJaggedRandomValues**           | **100**  |    **51.83 μs** |  **0.984 μs** |   **2.118 μs** |
| InitMultidimensionalRandomValues | 100  |    58.36 μs |  1.160 μs |   2.910 μs |
| InitJaggedFixedValue             | 100  |    45.01 μs |  0.642 μs |   0.600 μs |
| InitMultidimensionalFixedValue   | 100  |    21.08 μs |  0.143 μs |   0.127 μs |
| **InitJaggedRandomValues**           | **1024** | **8,615.43 μs** | **50.792 μs** |  **45.025 μs** |
| InitMultidimensionalRandomValues | 1024 | 9,179.39 μs | 36.193 μs |  32.084 μs |
| InitJaggedFixedValue             | 1024 | 2,293.24 μs | 51.074 μs | 150.593 μs |
| InitMultidimensionalFixedValue   | 1024 | 2,619.70 μs | 14.330 μs |  13.404 μs |
