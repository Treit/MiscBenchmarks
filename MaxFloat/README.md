# Finding max value of a series of floats




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method              | IterationCount | Mean       | Error    | StdDev   | Ratio | Allocated | Alloc Ratio |
|-------------------- |--------------- |-----------:|---------:|---------:|------:|----------:|------------:|
| OrdinaryMax         | 1000000        | 2,180.7 μs | 11.43 μs | 10.69 μs |  1.00 |         - |          NA |
| LinqMax             | 1000000        |   630.1 μs |  3.24 μs |  3.03 μs |  0.29 |         - |          NA |
| TensorPrimitivesMax | 1000000        |   199.1 μs |  0.63 μs |  0.56 μs |  0.09 |         - |          NA |
| IfMax               | 1000000        |   336.5 μs |  6.55 μs |  6.73 μs |  0.15 |         - |          NA |
| TernaryMax          | 1000000        |   315.8 μs |  2.13 μs |  1.66 μs |  0.14 |         - |          NA |
| VectorMax           | 1000000        |   275.2 μs |  1.45 μs |  1.36 μs |  0.13 |         - |          NA |
