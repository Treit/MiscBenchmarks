# Distance calculation for two vectors of double


```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26085.1)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.202
  [Host]     : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                          | Iterations | VectorLength | Mean        | Error     | StdDev    | Ratio | RatioSD | Gen0    | Allocated | Alloc Ratio |
|-------------------------------- |----------- |------------- |------------:|----------:|----------:|------:|--------:|--------:|----------:|------------:|
| ComputeDistanceLINQ             | 1000       | 1024         | 24,160.0 μs | 450.21 μs | 535.94 μs | 77.36 |    2.02 | 31.2500 |  256012 B |          NA |
| ComputeDistanceNonVectorized    | 1000       | 1024         |  3,295.8 μs |  17.54 μs |  14.65 μs | 10.51 |    0.05 |       - |       2 B |          NA |
| ComputeDistanceVectorizedMTreit | 1000       | 1024         |  1,335.2 μs |   6.75 μs |   6.31 μs |  4.26 |    0.03 |       - |       1 B |          NA |
| ComputeDistanceVectorizedAaron  | 1000       | 1024         |    848.0 μs |   1.76 μs |   1.56 μs |  2.71 |    0.02 |       - |         - |          NA |
| ComputeDistanceVectorizedAaron2 | 1000       | 1024         |    313.3 μs |   1.64 μs |   1.53 μs |  1.00 |    0.00 |       - |         - |          NA |
| ComputeDistanceTensorPrimitives | 1000       | 1024         |    843.0 μs |   2.12 μs |   1.98 μs |  2.69 |    0.02 |       - |         - |          NA |
