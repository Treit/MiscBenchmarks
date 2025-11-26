# MemoryStream with and without 'using'





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                     | Mean     | Error     | StdDev    | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|--------------------------- |---------:|----------:|----------:|------:|--------:|-------:|----------:|------------:|
| WriteMemoryStream          | 2.199 μs | 0.0682 μs | 0.2012 μs |  1.01 |    0.13 | 0.1755 |   2.91 KB |        1.00 |
| WriteMemoryStreamWithUsing | 2.232 μs | 0.0567 μs | 0.1664 μs |  1.02 |    0.12 | 0.1755 |   2.91 KB |        1.00 |
