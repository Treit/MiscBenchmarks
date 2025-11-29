# MemoryStream with and without 'using'






```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                     | Job       | Runtime   | Mean     | Error     | StdDev    | Median   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|--------------------------- |---------- |---------- |---------:|----------:|----------:|---------:|------:|--------:|-------:|----------:|------------:|
| WriteMemoryStream          | .NET 10.0 | .NET 10.0 | 2.043 μs | 0.0522 μs | 0.1513 μs | 1.956 μs |  1.01 |    0.10 | 0.1755 |   2.91 KB |        1.00 |
| WriteMemoryStreamWithUsing | .NET 10.0 | .NET 10.0 | 2.058 μs | 0.0449 μs | 0.1324 μs | 1.991 μs |  1.01 |    0.09 | 0.1755 |   2.91 KB |        1.00 |
|                            |           |           |          |           |           |          |       |         |        |           |             |
| WriteMemoryStream          | .NET 9.0  | .NET 9.0  | 2.054 μs | 0.0566 μs | 0.1652 μs | 1.958 μs |  1.01 |    0.11 | 0.1755 |   2.91 KB |        1.00 |
| WriteMemoryStreamWithUsing | .NET 9.0  | .NET 9.0  | 2.024 μs | 0.0423 μs | 0.1229 μs | 1.949 μs |  0.99 |    0.09 | 0.1755 |   2.91 KB |        1.00 |
