# Getting the type






```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method              | Count   | Mean     | Error   | StdDev  | Ratio | Allocated | Alloc Ratio |
|-------------------- |-------- |---------:|--------:|--------:|------:|----------:|------------:|
| UsingTypeof         | 1000000 | 313.9 μs | 3.14 μs | 2.94 μs |  1.00 |         - |          NA |
| UsingThisDotGetType | 1000000 | 313.1 μs | 2.21 μs | 1.84 μs |  1.00 |         - |          NA |
| UsingCachedType     | 1000000 | 312.6 μs | 2.15 μs | 2.01 μs |  1.00 |         - |          NA |
