# Distance calculation for two vectors of double

```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26085.1)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.202
  [Host]     : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                          | Iterations | VectorLength | Mean        | Error    | StdDev   | Gen0    | Allocated |
|-------------------------------- |----------- |------------- |------------:|---------:|---------:|--------:|----------:|
| ComputeDistanceLINQ             | 1000       | 1024         | 15,302.9 μs | 71.52 μs | 63.40 μs | 31.2500 |  256012 B |
| ComputeDistanceNonVectorized    | 1000       | 1024         |  3,259.1 μs | 38.62 μs | 34.24 μs |       - |       2 B |
| ComputeDistanceVectorizedMTreit | 1000       | 1024         |  1,321.4 μs | 13.34 μs | 11.14 μs |       - |       1 B |
| ComputeDistanceVectorizedAaron  | 1000       | 1024         |    839.1 μs |  2.76 μs |  2.44 μs |       - |         - |
| ComputeDistanceTensorPrimitives | 1000       | 1024         |    835.1 μs |  1.48 μs |  1.23 μs |       - |         - |
