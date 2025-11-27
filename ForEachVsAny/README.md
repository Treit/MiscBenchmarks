# ForEach vs. Any






```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method             | Job       | Runtime   | Count  | Mean     | Error    | StdDev   | Ratio | Allocated | Alloc Ratio |
|------------------- |---------- |---------- |------- |---------:|---------:|---------:|------:|----------:|------------:|
| SearchUsingAny     | .NET 10.0 | .NET 10.0 | 100000 | 31.64 μs | 0.381 μs | 0.338 μs |  0.50 |         - |          NA |
| SearchUsingForEach | .NET 10.0 | .NET 10.0 | 100000 | 63.11 μs | 0.676 μs | 0.632 μs |  1.00 |         - |          NA |
|                    |           |           |        |          |          |          |       |           |             |
| SearchUsingAny     | .NET 9.0  | .NET 9.0  | 100000 | 31.54 μs | 0.297 μs | 0.278 μs |  0.50 |         - |          NA |
| SearchUsingForEach | .NET 9.0  | .NET 9.0  | 100000 | 62.86 μs | 0.635 μs | 0.594 μs |  1.00 |         - |          NA |
