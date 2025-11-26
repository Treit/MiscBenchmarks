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
| ToCharArray      | 4.656 ms | 0.0531 ms | 0.0471 ms |  1.00 | 523.4375 | 523.4375 | 523.4375 |    2.8 MB |        1.00 |
| ValueSpanToArray | 4.993 ms | 0.0401 ms | 0.0375 ms |  1.07 | 359.3750 | 359.3750 | 359.3750 |   1.87 MB |        0.67 |
