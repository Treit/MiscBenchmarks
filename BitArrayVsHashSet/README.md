## Looking up integer values in a bit array vs. a HashSet








```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method              | Job       | Runtime   | Mean       | Error    | StdDev   | Ratio | RatioSD |
|-------------------- |---------- |---------- |-----------:|---------:|---------:|------:|--------:|
| LookupUsingHashSet  | .NET 10.0 | .NET 10.0 | 1,310.2 ns | 13.58 ns | 11.34 ns |  2.07 |    0.03 |
| LookupUsingBitArray | .NET 10.0 | .NET 10.0 |   633.6 ns |  7.43 ns |  6.59 ns |  1.00 |    0.01 |
|                     |           |           |            |          |          |       |         |
| LookupUsingHashSet  | .NET 9.0  | .NET 9.0  | 1,301.2 ns |  8.54 ns |  7.99 ns |  2.10 |    0.04 |
| LookupUsingBitArray | .NET 9.0  | .NET 9.0  |   620.1 ns | 11.21 ns | 12.46 ns |  1.00 |    0.03 |
