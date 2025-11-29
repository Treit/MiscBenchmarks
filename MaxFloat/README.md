# Finding max value of a series of floats






```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method              | Job       | Runtime   | IterationCount | Mean       | Error   | StdDev  | Ratio | Allocated | Alloc Ratio |
|-------------------- |---------- |---------- |--------------- |-----------:|--------:|--------:|------:|----------:|------------:|
| OrdinaryMax         | .NET 10.0 | .NET 10.0 | 1000000        | 2,168.9 μs | 1.32 μs | 1.24 μs |  1.00 |         - |          NA |
| LinqMax             | .NET 10.0 | .NET 10.0 | 1000000        |   627.2 μs | 2.92 μs | 2.59 μs |  0.29 |         - |          NA |
| TensorPrimitivesMax | .NET 10.0 | .NET 10.0 | 1000000        |   198.6 μs | 0.39 μs | 0.33 μs |  0.09 |         - |          NA |
| IfMax               | .NET 10.0 | .NET 10.0 | 1000000        |   337.9 μs | 1.30 μs | 1.09 μs |  0.16 |         - |          NA |
| TernaryMax          | .NET 10.0 | .NET 10.0 | 1000000        |   314.5 μs | 0.48 μs | 0.45 μs |  0.14 |         - |          NA |
| VectorMax           | .NET 10.0 | .NET 10.0 | 1000000        |   273.2 μs | 0.48 μs | 0.43 μs |  0.13 |         - |          NA |
|                     |           |           |                |            |         |         |       |           |             |
| OrdinaryMax         | .NET 9.0  | .NET 9.0  | 1000000        | 2,169.5 μs | 1.10 μs | 0.98 μs |  1.00 |         - |          NA |
| LinqMax             | .NET 9.0  | .NET 9.0  | 1000000        |   626.1 μs | 1.13 μs | 1.00 μs |  0.29 |         - |          NA |
| TensorPrimitivesMax | .NET 9.0  | .NET 9.0  | 1000000        |   198.1 μs | 0.29 μs | 0.27 μs |  0.09 |         - |          NA |
| IfMax               | .NET 9.0  | .NET 9.0  | 1000000        |   331.9 μs | 2.23 μs | 1.98 μs |  0.15 |         - |          NA |
| TernaryMax          | .NET 9.0  | .NET 9.0  | 1000000        |   314.4 μs | 0.63 μs | 0.50 μs |  0.14 |         - |          NA |
| VectorMax           | .NET 9.0  | .NET 9.0  | 1000000        |   273.5 μs | 0.57 μs | 0.53 μs |  0.13 |         - |          NA |
