# Making HashSets



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method           | Mean     | Error     | StdDev    | Ratio | Gen0     | Gen1     | Gen2     | Allocated | Alloc Ratio |
|----------------- |---------:|----------:|----------:|------:|---------:|---------:|---------:|----------:|------------:|
| ToCharArray      | 4.734 ms | 0.0608 ms | 0.0507 ms |  1.00 | 500.0000 | 500.0000 | 500.0000 |    2.8 MB |        1.00 |
| ValueSpanToArray | 4.643 ms | 0.0471 ms | 0.0418 ms |  0.98 | 382.8125 | 382.8125 | 382.8125 |   1.87 MB |        0.67 |
