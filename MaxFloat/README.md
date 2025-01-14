# Finding max value of a series of floats



```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27774.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100
  [Host]     : .NET 8.0.11 (8.0.1124.51707), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.11 (8.0.1124.51707), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method              | IterationCount | Mean       | Error    | StdDev   | Median     | Ratio | RatioSD | Allocated | Alloc Ratio |
|-------------------- |--------------- |-----------:|---------:|---------:|-----------:|------:|--------:|----------:|------------:|
| OrdinaryMax         | 1000000        | 2,403.3 μs | 36.66 μs | 34.29 μs | 2,407.8 μs |  1.00 |    0.00 |       2 B |        1.00 |
| LinqMax             | 1000000        |   599.2 μs | 15.50 μs | 43.71 μs |   578.8 μs |  0.25 |    0.02 |         - |        0.00 |
| TensorPrimitivesMax | 1000000        |   378.5 μs |  6.15 μs |  5.45 μs |   377.5 μs |  0.16 |    0.00 |         - |        0.00 |
| IfMax               | 1000000        |   425.9 μs |  7.25 μs | 11.28 μs |   426.5 μs |  0.18 |    0.01 |         - |        0.00 |
| TernaryMax          | 1000000        |   425.2 μs |  7.98 μs |  7.47 μs |   424.4 μs |  0.18 |    0.00 |         - |        0.00 |
| VectorMax           | 1000000        |   174.5 μs |  3.44 μs |  7.41 μs |   173.2 μs |  0.07 |    0.00 |         - |        0.00 |
