# MemoryStream with and without 'using'




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                     | Mean     | Error     | StdDev    | Median   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|--------------------------- |---------:|----------:|----------:|---------:|------:|--------:|-------:|----------:|------------:|
| WriteMemoryStream          | 2.156 μs | 0.0763 μs | 0.2238 μs | 2.062 μs |  1.01 |    0.14 | 0.1755 |   2.91 KB |        1.00 |
| WriteMemoryStreamWithUsing | 2.262 μs | 0.0722 μs | 0.2130 μs | 2.259 μs |  1.06 |    0.14 | 0.1755 |   2.91 KB |        1.00 |
