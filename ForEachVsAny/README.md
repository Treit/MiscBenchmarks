# ForEach vs. Any





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method             | Count  | Mean     | Error    | StdDev   | Ratio | Allocated | Alloc Ratio |
|------------------- |------- |---------:|---------:|---------:|------:|----------:|------------:|
| SearchUsingAny     | 100000 | 31.48 μs | 0.303 μs | 0.283 μs |  0.50 |         - |          NA |
| SearchUsingForEach | 100000 | 62.93 μs | 0.568 μs | 0.532 μs |  1.00 |         - |          NA |
