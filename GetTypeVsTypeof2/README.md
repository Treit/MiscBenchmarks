# Getting the type







```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method              | Job       | Runtime   | Count   | Mean     | Error   | StdDev  | Ratio | Allocated | Alloc Ratio |
|-------------------- |---------- |---------- |-------- |---------:|--------:|--------:|------:|----------:|------------:|
| UsingTypeof         | .NET 10.0 | .NET 10.0 | 1000000 | 315.1 μs | 3.23 μs | 2.87 μs |  1.00 |         - |          NA |
| UsingThisDotGetType | .NET 10.0 | .NET 10.0 | 1000000 | 313.6 μs | 2.94 μs | 2.75 μs |  1.00 |         - |          NA |
| UsingCachedType     | .NET 10.0 | .NET 10.0 | 1000000 | 314.2 μs | 2.31 μs | 2.16 μs |  1.00 |         - |          NA |
|                     |           |           |         |          |         |         |       |           |             |
| UsingTypeof         | .NET 9.0  | .NET 9.0  | 1000000 | 314.2 μs | 2.68 μs | 2.37 μs |  1.00 |       6 B |        1.00 |
| UsingThisDotGetType | .NET 9.0  | .NET 9.0  | 1000000 | 314.1 μs | 3.00 μs | 2.81 μs |  1.00 |         - |        0.00 |
| UsingCachedType     | .NET 9.0  | .NET 9.0  | 1000000 | 314.1 μs | 2.97 μs | 2.78 μs |  1.00 |         - |        0.00 |
