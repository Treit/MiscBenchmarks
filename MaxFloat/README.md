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
| OrdinaryMax         | 1000000        | 2,181.4 μs | 12.47 μs | 11.67 μs |  1.00 |         - |          NA |
| LinqMax             | 1000000        |   630.6 μs |  4.47 μs |  3.96 μs |  0.29 |         - |          NA |
| TensorPrimitivesMax | 1000000        |   199.7 μs |  0.89 μs |  0.83 μs |  0.09 |         - |          NA |
| IfMax               | 1000000        |   334.6 μs |  1.79 μs |  1.67 μs |  0.15 |         - |          NA |
| TernaryMax          | 1000000        |   315.8 μs |  1.88 μs |  1.67 μs |  0.14 |         - |          NA |
| VectorMax           | 1000000        |   274.6 μs |  1.47 μs |  1.38 μs |  0.13 |         - |          NA |
