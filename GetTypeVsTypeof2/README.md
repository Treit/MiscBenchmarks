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
| UsingTypeof         | 1000000 | 313.1 μs | 3.00 μs | 2.81 μs |  1.00 |         - |          NA |
| UsingThisDotGetType | 1000000 | 312.8 μs | 1.71 μs | 1.52 μs |  1.00 |         - |          NA |
| UsingCachedType     | 1000000 | 312.2 μs | 1.75 μs | 1.64 μs |  1.00 |         - |          NA |
