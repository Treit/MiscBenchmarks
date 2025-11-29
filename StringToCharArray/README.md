# Making HashSets





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method           | Job       | Runtime   | Mean     | Error     | StdDev    | Ratio | Gen0     | Gen1     | Gen2     | Allocated | Alloc Ratio |
|----------------- |---------- |---------- |---------:|----------:|----------:|------:|---------:|---------:|---------:|----------:|------------:|
| ToCharArray      | .NET 10.0 | .NET 10.0 | 4.624 ms | 0.0492 ms | 0.0460 ms |  1.00 | 515.6250 | 515.6250 | 515.6250 |    2.8 MB |        1.00 |
| ValueSpanToArray | .NET 10.0 | .NET 10.0 | 4.498 ms | 0.0248 ms | 0.0232 ms |  0.97 | 359.3750 | 359.3750 | 359.3750 |   1.87 MB |        0.67 |
|                  |           |           |          |           |           |       |          |          |          |           |             |
| ToCharArray      | .NET 9.0  | .NET 9.0  | 4.600 ms | 0.0309 ms | 0.0258 ms |  1.00 | 515.6250 | 515.6250 | 515.6250 |    2.8 MB |        1.00 |
| ValueSpanToArray | .NET 9.0  | .NET 9.0  | 4.483 ms | 0.0122 ms | 0.0102 ms |  0.97 | 359.3750 | 359.3750 | 359.3750 |   1.87 MB |        0.67 |
