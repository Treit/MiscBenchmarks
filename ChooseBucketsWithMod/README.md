# Handling negative hash codes when using mod to choose a bucket


```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26257.5000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.6.24328.19
  [Host]     : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                             | BucketCount | Mean     | Error     | StdDev    | Ratio | RatioSD | Allocated | Alloc Ratio |
|----------------------------------- |------------ |---------:|----------:|----------:|------:|--------:|----------:|------------:|
| IndexViaAdditionAndTwoMods         | 100         | 1.944 μs | 0.0104 μs | 0.0097 μs |  1.43 |    0.02 |         - |          NA |
| IndexViaMathAbs                    | 100         | 1.509 μs | 0.0084 μs | 0.0075 μs |  1.11 |    0.01 |         - |          NA |
| IndexViaHandlingNegativeExplicitly | 100         | 1.527 μs | 0.0295 μs | 0.0493 μs |  1.13 |    0.04 |         - |          NA |
| IndexViaBitwiseAnd                 | 100         | 1.362 μs | 0.0169 μs | 0.0142 μs |  1.00 |    0.00 |         - |          NA |
