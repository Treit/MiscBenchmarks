# Test dictionary lookups using string interpolation vs. ToString()






```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2

OutlierMode=DontRemove  MemoryRandomization=True  

```
| Method                   | Job       | Runtime   | Count | Mean     | Error   | StdDev  | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------- |---------- |---------- |------ |---------:|--------:|--------:|------:|--------:|-------:|----------:|------------:|
| LookupUsingToString      | .NET 10.0 | .NET 10.0 | 5000  | 101.5 μs | 1.82 μs | 1.71 μs |  1.00 |    0.02 | 8.9111 | 146.88 KB |        1.00 |
| LookupUsingInterpolation | .NET 10.0 | .NET 10.0 | 5000  | 177.3 μs | 1.76 μs | 1.64 μs |  1.75 |    0.03 | 9.5215 | 156.17 KB |        1.06 |
|                          |           |           |       |          |         |         |       |         |        |           |             |
| LookupUsingToString      | .NET 9.0  | .NET 9.0  | 5000  | 102.7 μs | 1.47 μs | 1.38 μs |  1.00 |    0.02 | 8.9111 | 146.88 KB |        1.00 |
| LookupUsingInterpolation | .NET 9.0  | .NET 9.0  | 5000  | 179.2 μs | 2.41 μs | 2.26 μs |  1.75 |    0.03 | 9.5215 | 156.17 KB |        1.06 |
